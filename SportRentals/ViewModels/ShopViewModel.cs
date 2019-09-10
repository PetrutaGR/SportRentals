using SportRentals.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.ViewModels
{
    public class ShopViewModel
    {
     
        public Shop Shop { get; set; }

        public string PaymentMethods { get; set; }

        public string CategoryName { get; set; }


    }
}