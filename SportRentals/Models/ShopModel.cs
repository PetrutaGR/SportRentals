using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Models
{
    public class ShopModel
    {
        public int ShopID { get; set; }
        public int AddressID { get; set;}
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get;set }

    }
}