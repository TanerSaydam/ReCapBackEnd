using DataAccess.Abstract;
using Entities.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.EntiyFramework.Context;
using Entities.DTOs;

namespace DataAccess.Concrete.EntiyFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {        
        private IList<CarDetailDto> CarDetailList()
        {
            using (var context = new RentACarContext())
            {
                var result = from x in context.Cars
                             join y in context.Brands
                             on x.BrandId equals y.Id
                             join z in context.Colors
                             on x.ColorId equals z.Id
                             select new CarDetailDto
                             {
                                 CarId = x.Id,
                                 CarName = x.Description,
                                 BrandId = x.BrandId,
                                 BrandName = y.Name,
                                 ColorId = x.ColorId,
                                 ColorName = z.Name,
                                 ModelYear = x.ModelYear,
                                 DailyPrice = x.DailyPrice,
                                 FindeksScore = x.FindeksScore
                             };
                return result.ToList();
            }
        }
        public IList<CarDetailDto> GetListCarDetail()
        {
            var result = CarDetailList();
            return result.ToList();
        }

        public IList<CarDetailDto> GetListCarDetailByBrandId(int brandId)
        {
            var result = CarDetailList().Where(c=> c.BrandId == brandId);
            return result.ToList();
        }

        public IList<CarDetailDto> GetListCarDetailByColorId(int colorId)
        {
            var result = CarDetailList().Where(c => c.ColorId == colorId);
            return result.ToList();
        }

        public IList<CarDetailDto> GetListCarDetailwithBrandIdAndColorId(int branId, int colorId)
        {
            var result = CarDetailList().Where(c => c.BrandId == branId && c.ColorId == colorId);
            return result.ToList();
        }
    }
}
