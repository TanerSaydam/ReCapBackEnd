using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.EntiyFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntiyFramework
{
    public class EfCreditCartDal : EfEntityRepositoryBase<CreditCart,RentACarContext>, ICreditCartDal
    {
    }
}
