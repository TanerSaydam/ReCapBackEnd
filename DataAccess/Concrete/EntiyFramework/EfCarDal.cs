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
        public IList<CarDetailDto> GetListCarDetail()
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
                                 CarName = x.Description,
                                 BrandName = y.Name,
                                 ColorName = z.Name,
                                 DailyPrice = x.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
