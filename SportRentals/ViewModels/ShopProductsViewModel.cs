using SportRentals.Models;
using SportRentals.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SportRentals.ViewModels
{
    public class ShopProductsViewModel
    {
        [DisplayName("Shop Name")]
        public string Name { get; set; }

        public List<Product> Products = new List<Product>();
    }
}