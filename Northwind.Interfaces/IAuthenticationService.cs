using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nortwind.Entities;
using System.ServiceModel;

namespace Northwind.Interfaces
{
    [ServiceContract]
    public interface IAuthenticationService
    {
       [OperationContract]
       User Authenticate(User user);
    }
}
