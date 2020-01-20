using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Ninject.Extensions.Interception;
using Northwind.Interfaces;
using Nortwind.Bll.Concrete;
using Nortwind.Dal.Concrete.EntityFramework;
using Nortwind.CrossCuttingConcerns.Logging;

namespace Nortwind.MVCWebUI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        //DefaultControllerFactory bu uygulamayı ayağa kaldıran sınıftır
        //MVC controllerlarda kendisi bir yorumlama yapıyor, bizim ona söylediğimiz yorumu yapabilmesi için override getcontrollerınstance'ı ekliyoruz
        //olay şu; constructorda istenilen interfacei verebilmek

        private IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddServiceBindings();
           // AddBllBinding();//bu method ile , eğer birisi senden şu interface isterse ona şu sınıfı ver diyebileceğiz
        } // ninjecti devreye geçirdik

        private void AddBllBinding()
        {
            _ninjectKernel.Bind<IProductService>().To<ProductManager>().WithConstructorArgument("productDal",new EfProductDal());
            //IProductService istenildiği zaman ona ProductManageri ver.
            _ninjectKernel.Bind<ICategoryService>().To<CategoryManager>().WithConstructorArgument("categoryDal", new EfCategoryDal());
            //ICategoryService istenildiği zaman ona CategoryManageri ver. 

            _ninjectKernel.Bind<IAuthenticationService>().To<AuthenticationManager>().WithConstructorArgument("authenticationDal", new EfAuthenticationDal());
            //_ninjectKernel.Intercept(p => (true)).With(new LoggingInterceptor());

        }

        private void AddServiceBindings()
        {
            _ninjectKernel.Bind<IProductService>().ToConstant (WcfProxy<IProductService>.CreateChannel());
            _ninjectKernel.Bind<ICategoryService>().ToConstant(WcfProxy<ICategoryService>.CreateChannel());
            _ninjectKernel.Bind<IAuthenticationService>().ToConstant(WcfProxy<IAuthenticationService>.CreateChannel());

        }
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null :(IController) _ninjectKernel.Get(controllerType);
        }
    }
}