using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

namespace Nortwind.MVCWebUI.Infrastructure
{
    public static class WcfProxy <T> //<T> generic demek 
    {
       /*
        Bu kodu biz IProductService için yazdık.
        *Biz hangi interface verirsek kod satırıda onun için çalışmalıdır. Service sayısı artabilir bizde bu yüzden
        *kodu generic yapıp istediğimiz interface çalıştırmış olacağız.
        * public static IProductService CreateChannel()
        {
            string adress = "http://localhost:55749/ProductService.svc?wsdl";
            var binding = new BasicHttpBinding();
            var channel = new ChannelFactory<IProductService>(binding, adress);

            return channel.CreateChannel();

        }*/

        public static T CreateChannel()
        {
            string adress = String.Format("http://localhost:55738/{0}.svc?wsdl",typeof(T).Name.Substring(1));
            //substring(1); başındaki interface den gelen I harfini uçur demektir.
            //{0} ; Service adı
            var binding = new BasicHttpBinding();//Service model
            var channel = new ChannelFactory<T>(binding, adress);

            return channel.CreateChannel();
            
        }
    }
}