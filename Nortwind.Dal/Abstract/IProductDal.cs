using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nortwind.Entities;


namespace Nortwind.Dal.Abstract
{
    public interface IProductDal
    {
        List<Product> GetAll();

        Product Get(int ProductID);
        void Add(Product product);
        void Delete(int ProductID);
        void Update(Product product);
    }
}
