﻿using Business.Abstract;
using Business.Constants;
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

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
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

        public IDataResult<IList<RentalDetailDto>> GetListRentalDetail()
        {
            return new SuccessDataResult<IList<RentalDetailDto>>(_rentalDal.GetListRentalDetail());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
