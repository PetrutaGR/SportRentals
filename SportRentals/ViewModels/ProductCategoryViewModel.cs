using SportRentals.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.ViewModels
{
    public class ProductCategoryViewModel
    {

        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get; set; }
        public int Stock { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }

        

  
    }
}