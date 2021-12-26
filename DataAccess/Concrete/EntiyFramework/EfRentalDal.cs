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
        public IList<RentalDetailDto> GetListRentalDetail()
        {
            using (var context = new RentACarContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.Id
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             select new RentalDetailDto
                             {
                                 BrandName = brand.Name,
                                 Customer = customer.CompanyName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }            
        }
    }
}
