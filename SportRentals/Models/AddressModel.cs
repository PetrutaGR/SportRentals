using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportRentals.Models
{
    public class AddressModel
    {
        public int AddressID { get; set; }

        [Required(ErrorMessage ="Mandatory field")]
        [StringLength(200, ErrorMessage ="The name is too long(max 200 chars)")]
        public string Country { get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(200, ErrorMessage = "The name is too long(max 200 chars)")]
        public string County { get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(200, ErrorMessage = "The name is too long(max 200 chars)")]
        public string City { get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(300, ErrorMessage = "The name is too long(max 300 chars)")]
        public string Street { get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        public int? StreetNumber { get; set; }


        public string PostCode { get; set; }

    }
}