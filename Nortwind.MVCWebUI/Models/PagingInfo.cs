using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nortwind.MVCWebUI.Models
{
    public class PagingInfo
    {
        public int ItemsPerPage { get; set; }

        public int TotalItems { get; set; }

        public int CurrentPage { get; set; }

        public int CurrentCategory { get; set; }
    }
}
