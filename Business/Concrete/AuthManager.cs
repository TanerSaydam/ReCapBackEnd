using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private ICustomerService _customerService;
        private IFindeksService _findeksService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, ICustomerService customerService, IFindeksService findeksService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _customerService = customerService;
            _findeksService = findeksService;
        }

        public IDataResult<UserLoginResultDto> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            UserLoginResultDto result = new UserLoginResultDto();
            result.accessToken = accessToken;
            result.user = user;
            return new SuccessDataResult<UserLoginResultDto>(result, Messages.AccessTokenCreated);
        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userService.GetById(userId);            
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPaswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePaswordHas(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);

            string companyName = user.FirstName + " " + user.LastName;
            Customer customer = new Customer { UserId = user.Id, CompanyName = companyName };
            _customerService.Add(customer);

            FindeksService findeks = new FindeksService()
            {
                CustomerId = customer.Id,
                FindeksScore = 1800
            };
            _findeksService.Add(findeks);

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult Update(User user)
        {
            _userService.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
