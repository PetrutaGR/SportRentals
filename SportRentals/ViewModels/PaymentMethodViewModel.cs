using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportRentals.Models;

namespace SportRentals.ViewModels
{
    public class PaymentMethodViewModel
    {
        public PaymentMethodModel PaymentMethod { get; set; }
        public bool Selected { get; set; }
    }
}