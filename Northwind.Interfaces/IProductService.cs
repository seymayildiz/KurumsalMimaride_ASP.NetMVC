using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Nortwind.Entities;
using System.ServiceModel;

namespace Northwind.Interfaces
{
    [ServiceContract] //interfacein service kontratı olarak hizmete açılacağı anlamına gelir
    public interface IProductService
    {
        [OperationContract] //operationcontract olarak yayına çıkarıyoruz
        List<Product> GetAll();

        [OperationContract]
        Product Get(int productId);

        [OperationContract]
        void Add(Product product);

        [OperationContract]
        void Delete(int productId);

        [OperationContract]
        void Update(Product product);

    }
}