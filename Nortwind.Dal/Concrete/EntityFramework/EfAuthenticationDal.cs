using Nortwind.Dal.Abstract;
using Nortwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.Dal.Concrete.EntityFramework
{
    public class EfAuthenticationDal :IAuthenticationDal
    {
        public User Authenticate(User user)
        {
            //veritabanından alınacak 
            if (user.UserName == "seyma" && user.Password == "1")
            {
                return user;
            }
            return null;
        }
    }
}
