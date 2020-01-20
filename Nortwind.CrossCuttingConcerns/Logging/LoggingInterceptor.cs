using Ninject.Extensions.Interception; //NuGet package dan eklendi.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.CrossCuttingConcerns.Logging
{
    public class LoggingInterceptor : SimpleInterceptor
    {
        //Interceptor : Methodun başında veya sonunda çalışmasını istediğiniz aksiyonları doldurduğunuz bir yapıdır.
        //Ninjectin SimleInterceptor mekanizması bizim için gerekli olacaktır. 


        protected override void AfterInvoke(IInvocation invocation) //methoddan sonra çalışacak
        {
             base.AfterInvoke(invocation);
        }

        protected override void BeforeInvoke(IInvocation invocation) //methoddan önce çalışacak 
        {
            //loglama framework 'ün loglama işlemleri yapılacak.
            base.BeforeInvoke(invocation);
        }
    }
}
