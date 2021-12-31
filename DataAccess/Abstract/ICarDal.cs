using Entities.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        IList<CarDetailDto> GetListCarDetail();
        IList<CarDetailDto> GetListCarDetailByBrandId(int brandId);
        IList<CarDetailDto> GetListCarDetailByColorId(int colorId);
        IList<CarDetailDto> GetListCarDetailwithBrandIdAndColorId(int branId, int colorId);
    }
}
