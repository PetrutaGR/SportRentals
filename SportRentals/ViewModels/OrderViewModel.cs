using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportRentals.Models;

namespace SportRentals.ViewModels
{
    public class OrderViewModel
    {
        public OrderModel Order { get; set; }

        public string CustomerName { get; set; }

        public string ShopName { get; set; }

        public string StatusName { get; set; }

        public int InitialStatusID { get; set; }

        public List<ProductModel> Products { get; set; }

    }
}