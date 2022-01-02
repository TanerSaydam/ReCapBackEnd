using Core.Entities;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserLoginResultDto : IDto
    {
        public AccessToken accessToken { get; set; }
        public User user { get; set; }
    }
}
