using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Models
{
    public class PaymentMethodModel
    {

        public int PaymentMethodID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}