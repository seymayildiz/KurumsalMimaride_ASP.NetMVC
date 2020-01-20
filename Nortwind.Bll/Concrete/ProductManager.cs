using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Interfaces;
using Nortwind.Entities;
using Nortwind.Dal.Abstract;


namespace Nortwind.Bll.Concrete
{
   public class ProductManager:IProductService 
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal; 
            //yapılandırıcı methodumuz (constructor)
            //bunu kullanacağımız zaman parametreyi interface veremeyiz somut bir sınıf vermek zorundayız

        }
        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product Get(int productId)
        {
            return _productDal.Get(productId);
        }

        public void Add(Nortwind.Entities.Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(productId);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
