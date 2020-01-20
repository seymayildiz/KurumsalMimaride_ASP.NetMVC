using Nortwind.Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nortwind.Entities;

namespace Nortwind.Dal.Concrete.EntityFramework
{
    public class EfProductDal:IProductDal
    {
        private NortwindContext _context = new NortwindContext();
        public List<Entities.Product> GetAll()
        {
            return _context.Products.ToList();
            //tüm ürünleri getir ve onu listeye çevir 
            //select * gibi çalışır 
        }

        public Entities.Product Get(int productId)
        {
            //get tek bir ürün getirir
            //tek bir ürün getireceği için filtreleme yapmak gerekir
            return _context.Products.FirstOrDefault(p=>p.ProductID == productId);
            _context.SaveChanges();
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int productId)
        {
            _context.Products.Remove(_context.Products.FirstOrDefault(p => p.ProductID == productId));
            //neyi sileceğini belirtmiş oluyoruz
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            _context.SaveChanges();
        }
    }
}
