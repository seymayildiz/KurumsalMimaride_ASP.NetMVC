using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nortwind.MVCWebUI.Models
{
   public class ProductViewModel
    {
        public List<Entities.Product> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
