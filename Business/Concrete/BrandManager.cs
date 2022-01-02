using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        //[SecuredOperation("brand.add,admin")]
        [ValidationAspect(typeof(BrandValidator),Priority =1)]
        public IResult Add(Brand brand)
        {
            var result = BusinessRules.Run(IsCheckNameExsist(brand));
            if (result != null)
            {
                return result;
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<Brand> Get(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(x => x.Id == brandId));
        }

        public IDataResult<IList<Brand>> GetAll()
        {
            return new SuccessDataResult<IList<Brand>>(_brandDal.GetAll().ToList());
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        public IResult IsCheckNameExsist(Brand brand)
        {
            var result = _brandDal.GetAll(b => b.Name == brand.Name).ToList();
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.BrandNameExsist);
            }
            return new SuccessResult();
        }
    }
}
