using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Interfaces;
using Nortwind.Entities;
using Nortwind.Bll.Concrete;
using Nortwind.Dal.Concrete.EntityFramework;

namespace Nortwind.WcfLibrary.Concrete
{
    public class ProductService : IProductService
    {
        //Instance Provider ile ezilecek
        private ProductManager _productManager = new ProductManager(new EfProductDal());

        public List<Product> GetAll()
        {
           return _productManager.GetAll();
        }

        public Product Get(int productId)
        {
          return _productManager.Get(productId);
        }

        public void Add(Product product)
        {
            _productManager.Add(product);
        }

        public void Delete(int productId)
        {
            _productManager.Delete(productId);
        }

        public void Update(Product product)
        {
            _productManager.Update(product);
        }
    }
}














