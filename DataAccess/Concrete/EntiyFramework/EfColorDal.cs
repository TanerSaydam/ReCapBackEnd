using DataAccess.Abstract;
using Entities.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.EntiyFramework.Context;

namespace DataAccess.Concrete.EntiyFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color,RentACarContext>,IColorDal
    {
    }
}
