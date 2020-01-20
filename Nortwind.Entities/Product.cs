using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nortwind.Entities
{
    public class Product
    {
        //tablolarde gelen productıd leri gizleyeceğiz

        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int CategoryID { get; set; } //ürünün hangi kategoriye ait olduğunu bilmek istediğimiz için buraya categoryıd alanını ekledik.
       
    }
}
