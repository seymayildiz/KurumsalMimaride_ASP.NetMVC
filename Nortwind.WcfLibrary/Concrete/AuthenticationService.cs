using Northwind.Interfaces;
using Nortwind.Entities;
using Nortwind.Dal.Concrete.EntityFramework;
using Nortwind.Bll.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.WcfLibrary.Concrete
{
    public class AuthenticationService :IAuthenticationService
    {
        AuthenticationManager _authenticationManager = new AuthenticationManager(new EfAuthenticationDal());

        public User Authenticate(User user)
        {
            return _authenticationManager.Authenticate(user);
        }
    }
}
