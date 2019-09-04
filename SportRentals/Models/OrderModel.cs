using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ShopID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Total { get; set;}

    }
}