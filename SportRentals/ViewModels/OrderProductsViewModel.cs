using SportRentals.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportRentals.Models;

namespace SportRentals.ViewModels
{
    public class OrderProductsViewModel
    {
        public int OrderID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public List<ProductModel> Products { get; set; }
    }
}