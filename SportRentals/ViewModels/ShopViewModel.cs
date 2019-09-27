using SportRentals.Models;
using SportRentals.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportRentals.ViewModels
{
    public class ShopViewModel
    {
        [Display(Name = "ID")]
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Payment Methods")]
        public string PaymentMethods { get; set; }

        public string Address { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Category")]

        public string CategoryName { get; set; }

    }
}