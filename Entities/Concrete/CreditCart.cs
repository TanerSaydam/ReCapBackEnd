using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CreditCart : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string CartNumber { get; set; }
        public int ExpirationMounth { get; set; }
        public int ExpirationYear { get; set; }
        public int Cvv { get; set; }
    }
}
