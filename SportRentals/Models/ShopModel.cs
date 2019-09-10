using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Models
{
    public class ShopModel
    {
        public int ShopId { get; set; }
        public int AddressID { get; set;}
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }



    }
}