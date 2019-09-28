using SportRentals.Models;
using SportRentals.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportRentals.ViewModels
{
    public class ShopEditViewModel
    {
        public ShopModel Shop { get; set; }

        public List<PaymentMethodViewModel> PaymentMethods { get; set; }

        public AddressModel Address { get; set; }

    }
}