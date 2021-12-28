using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.EntiyFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntiyFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        private IList<RentalDetailDto> List()
        {
            using (var context = new RentACarContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.Id
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             select new RentalDetailDto
                             {
                                 CarId = car.Id,
                                 BrandId = brand.Id,
                                 BrandName = brand.Name,
                                 ColorId = car.ColorId,
                                 ColorName = color.Name,
                                 Customer = customer.CompanyName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
        public IList<RentalDetailDto> GetListRentalDetail()
        {
            var result = List();
            return result;
        }

        public IList<RentalDetailDto> GetListRentalDetailByBrand(int brandId)
        {
            var result = List();

            result = result.Where(r => r.BrandId == brandId).ToList();
            return result;
        }

        public IList<RentalDetailDto> GetListRentaDetailByColor(int colorId)
        {
            var result = List();
            result = result.Where(r => r.ColorId == colorId).ToList();
            return result;
        }
    }
}
