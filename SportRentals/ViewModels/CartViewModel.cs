using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;

namespace SportRentals.ViewModels
{
    public class CartViewModel
    {

        public int ProductID;
        public string Product;
        public decimal Price;
        public int Quantity;
        public int SubTotal;

        public CartViewModel() { }

        public CartViewModel(int productID, string prod, int price, int quantity)
        {
            ProductID = productID;
            Product = prod;
            Price = price;
            Quantity = quantity;
            SubTotal = price * quantity;
        }
    }
}