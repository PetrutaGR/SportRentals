using SportRentals.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportRentals.ViewModels
{
    public class ProductCategoryViewModel
    {
        [Display(Name = "ID")]
        public int ProductID { get; set; }
        public int CategoryID { get; set; }

        [Display(Name = "Product")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Price")]
        public decimal DailyPrice { get; set; }
        public int Stock { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Picture")]
        public string ImageUrl { get; set; }

        

  
    }
}