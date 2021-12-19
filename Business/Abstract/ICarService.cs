using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IList<Car> GetAll();
        IList<CarDetailDto> GetListCarDetail();
        Car Get(int carId);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
