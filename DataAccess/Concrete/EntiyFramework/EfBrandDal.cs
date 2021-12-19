using DataAccess.Abstract;
using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.EntiyFramework.Context;

namespace DataAccess.Concrete.EntiyFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand,RentACarContext>,IBrandDal
    {
    }
}
