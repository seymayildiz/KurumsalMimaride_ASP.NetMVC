using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Nortwind.MVCWebUI.Infrastructure;
using Nortwind.Entities;
using Nortwind.MVCWebUI.ModelBinders;
namespace Nortwind.MVCWebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //uygulamanın ilk çalıştığı nokta
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            //klasör ismide modelbinders olduğu için tanımlamayı bu şekilde yapmak zorunda kaldık.
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
                        
        }
    }
}