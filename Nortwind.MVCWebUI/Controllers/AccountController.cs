using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nortwind.Entities;
using System.Web.Security;
using Northwind.Interfaces;

namespace Nortwind.MVCWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationService _authenticationManager; //kullanıcı bilgilerine illa veritabanı üzerinden erişmek 
        //istemeyebiliriz. Bu yüzden IAuthenticationManager i oluşturduk

        public AccountController(IAuthenticationService authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        //get
        public ActionResult Login()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Login(User user, string returnUrl) //kullanıcıyı geldiği yere gönderme returnUrl 
        {
            User validatedUser = _authenticationManager.Authenticate(user);
            if (validatedUser == null)
            {
                ModelState.AddModelError("Hata", "Kullanıcı adı veya şifre hatalı.");
            }
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return Redirect(returnUrl);
            }      
            return View();

        }
    }
}
