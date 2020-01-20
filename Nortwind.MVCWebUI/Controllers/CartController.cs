using Northwind.Interfaces;
using Nortwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nortwind.MVCWebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId)
        {
            Product product = _productService.Get(productId);
            cart.AddToCart(product, 1);

            return RedirectToAction("Index", cart);
        }
        public ViewResult Index(Cart cart)
        { 
            return View(cart);
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId)
        {
            Product product = _productService.Get(productId);
            cart.RemoveFromCart(product);
            return RedirectToAction("Index",cart);
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            if (ModelState.IsValid) //modelde bir problem yoksa tamamlanıyor problem varsa detay sayfasını tekrar yüklüyor
            {
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public PartialViewResult CartSummary(Cart cart)
        {
            return PartialView(cart);
        }

    }
}
