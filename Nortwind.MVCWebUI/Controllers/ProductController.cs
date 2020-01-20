using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nortwind.Bll.Concrete;
using Nortwind.Dal.Concrete.EntityFramework;
using Nortwind.Entities;
using Northwind.Interfaces;
using Nortwind.MVCWebUI.Models;

namespace Nortwind.MVCWebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: /Product/
        //MVC de Controller isteğin ilk etapta karşılandığı yerdir
       
        //private IProductService _productService = new ProductManager(IProductDal)

        //bir interface e concrete bir sınıf atanabilir mi?
        // ProductManager sınıfı bll deki bir sınıftır ve interfaceden inherit edilir.
        //Burada temel sınıf IProductServicedir. Hem productmanager hemde diğer sınıfları temel sınıftan inherit edildiği için ikisini de atayabiliriz

        private IProductService _productService;

        //Constructor injection ile bağımlılıkları azalttık. Parantez içini istediğimiz gibi değiştirebiliriz
        //ProductControllerda productservice in nasıl hayata geçirileceğine bakacağız
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public int PageSize = 5; //sayfalama
        public ViewResult Index(int page=1 , int category=0)
        {
            //1 2 3 4 5 6 7 8 9 
            //sayfalama işlemi için kod satırı 
            List<Product> products = _productService.GetAll()
                .Where(p=>p.CategoryID == category||category==0).ToList();
            return View(new ProductViewModel
            {
                Products = products.Skip((page-1)*PageSize).Take(5).ToList(),
                PagingInfo = new PagingInfo { 
                    ItemsPerPage = PageSize,
                    TotalItems = products.Count,
                    CurrentPage = page,
                    CurrentCategory = category
                } /*alt tarafta sayfa sayılarını oluşturmam gerekekir. örneğin 100 eleman varsa
                aşağıda 20 tane sayfa numarası olması lazım. kaç eleman var, hangi sayfadayım, kaçarlı dizeceğim gibi bilgilere ihtiyaç oluşur
                bu yüzden bir sınıf oluşturup gerekli bilgileri burada yazdık*/
            } );
        }//ürünleri listeleme



        internal PagingInfo pagingInfo { get; set; }
    }
}
