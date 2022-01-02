using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        IFindeksService _findeksService;
        ICarService _carService;
        public RentalManager(IRentalDal rentalDal, IFindeksService findeksService, ICarService carService)
        {
            _rentalDal = rentalDal;
            _findeksService = findeksService;
            _carService = carService;
        }

        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(IsCarReturned(rental.CarId, rental.RentDate), IsEnoughFindexPoint(rental.CustomerId,rental.CarId));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<Rental> Get(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.Id == rentalId));
        }

        public IDataResult<IList<Rental>> GetAll()
        {
            return new SuccessDataResult<IList<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<IList<RentalDetailDto>> GetListRentalsByBrand(int brandId)
        {
            return new SuccessDataResult<IList<RentalDetailDto>>(_rentalDal.GetListRentalDetailByBrand(brandId));
        }

        public IDataResult<IList<RentalDetailDto>> GetListRentalsByColor(int colorId)
        {
            return new SuccessDataResult<IList<RentalDetailDto>>(_rentalDal.GetListRentaDetailByColor(colorId));
        }

        public IDataResult<IList<RentalDetailDto>> GetListRentalsDetail()
        {
            return new SuccessDataResult<IList<RentalDetailDto>>(_rentalDal.GetListRentalDetail());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult IsCarReturned(int carId, DateTime rentDate)
        {
            var result = _rentalDal.GetAll(c => c.CarId == carId && c.ReturnDate >= rentDate);
            if (result.Count != 0)
            {
                return new ErrorResult(Messages.CarBusy);
            }
            return new SuccessResult();
        }

        public IResult IsEnoughFindexPoint(int customerId,int carId)
        {
            var getFindexforCustomer = _findeksService.GetFindeks(customerId).Data;
            var getFindexforCar = _carService.Get(carId).Data;            
            if (getFindexforCustomer != null && getFindexforCustomer.FindeksScore >= getFindexforCar.FindeksScore)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.FindeksScoreisNotEnough);
        }
    }
}
