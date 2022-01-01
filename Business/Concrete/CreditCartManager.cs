using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CreditCartManager : ICreditCartService
    {
        ICreditCartDal _creditCartDal;

        public CreditCartManager(ICreditCartDal creditCartDal)
        {
            _creditCartDal = creditCartDal;
        }

        public IResult Add(CreditCart creditCart)
        {
            _creditCartDal.Add(creditCart);
            return new SuccessResult(Messages.CreditCartAdded);
        }

        public IDataResult<IList<CreditCart>> GetAll()
        {
            return new SuccessDataResult<IList<CreditCart>>(_creditCartDal.GetAll());
        }
    }
}
