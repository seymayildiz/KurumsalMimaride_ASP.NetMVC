using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nortwind.Entities;

namespace Nortwind.Dal.Abstract
{
    public interface IAuthenticationDal
    {
        User Authenticate(User user);
    }
}
