using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<IList<Rental>> GetAll();
        IDataResult<IList<RentalDetailDto>> GetListRentalsDetail();
        IDataResult<IList<RentalDetailDto>> GetListRentalsByBrand(int brandId);
        IDataResult<IList<RentalDetailDto>> GetListRentalsByColor(int colorId);
        IDataResult<Rental> Get(int rentalId);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}
