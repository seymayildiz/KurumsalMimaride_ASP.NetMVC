using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Nortwind.Entities;

namespace Nortwind.Dal.Concrete.EntityFramework
{
    public class NortwindContext: DbContext //entity framework ile veritabanı bağlantısını gerçekleştirdik
    {
        public DbSet<Product> Products { get; set; } //veritabanında ki ürünler tablosu ile entity frameworku ilişkilendir
        //ürünler tablosunda ki her bir satırın türü product dır.
        public DbSet<Category> Categories { get; set; }
    }
}





