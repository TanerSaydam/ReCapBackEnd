using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<IList<CarImage>> GetAll();
        IDataResult<IList<CarImage>> GetListByCarId(int carId);
        IDataResult<CarImage> GetById(int carImageId);
        IResult Add(IFormFile file,CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
    }
}
