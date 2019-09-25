using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportRentals.Models
{
    public class OrderProductModel
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public int OrderQuantity { get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "The name is too long(max 50 chars)")]
        public string OrderSatus { get; set; }

    }
}