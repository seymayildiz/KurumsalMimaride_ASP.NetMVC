using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.Internal.Xml.XPath;
using Nortwind.Entities;

namespace Nortwind.Entities
{
    public class Cart
    {
        List<CartLine> _lines = new List<CartLine> () ;

        public void AddToCart(Product product, int quantity)
        {
            //sepete bak, sepette ürün varsa sayısını arttır,yoksa yeni ürün ekle.
            CartLine cartLine = _lines.FirstOrDefault(c => c.Product.ProductID == product.ProductID);

            if (cartLine == null)
            {
                _lines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                cartLine.Quantity += quantity;
            }
        }

        public void RemoveFromCart(Product product)
        {
            _lines.RemoveAll(p => p.Product.ProductID == product.ProductID); //remove belirttiğimiz ürünü silmeye yarıyor
        }

        public decimal TotalPrice
        {
            get
            {
                return _lines.Sum(c => c.Product.UnitPrice * c.Quantity);
            }
        }

        public void Clear()
        {
            _lines.Clear(); //clear sepeti silmeye yarıyor 
        }

        public List<CartLine> Lines
        {
            get { return _lines; }
        }

        public class CartLine
        {

            public Product Product { get; set; }

            public int Quantity { get; set; }
        }
    }
}
