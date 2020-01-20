using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Nortwind.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage="İsim bilgisi boş geçilemez.!")]
        [Display (Name="Name Surname")]
        public string Name { get; set; }

        [Required()]
        [MinLength(50)]
        [MaxLength(100)]
        public string Adress1 { get; set; }

        [MaxLength(100)]
        public string Adress2 { get; set; }

        [MaxLength(100)]
        public string Adress3 { get; set; }

        public string Country { get; set; }

        [Required()]
        public string City { get; set; }

        public bool IsGift { get; set; }

    }
}
