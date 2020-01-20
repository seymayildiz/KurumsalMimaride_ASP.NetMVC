using Northwind.Interfaces;
using Nortwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nortwind.Dal.Abstract;

namespace Nortwind.Bll.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        public IAuthenticationDal _authenticationDal;

        public AuthenticationManager(IAuthenticationDal authenticationDal)
        {
            _authenticationDal = authenticationDal;
        }

        public User Authenticate(User user)
        {
            return _authenticationDal.Authenticate(user);
        }
    }
}
