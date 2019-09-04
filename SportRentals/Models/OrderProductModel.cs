using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Models
{
    public class OrderProductModel
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int OrderQuantity { get; set; }
        public string OrderSatus { get; set; }

    }
}