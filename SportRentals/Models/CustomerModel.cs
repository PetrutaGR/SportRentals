using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportRentals.Models
{
    public class CustomerModel
    {
        [Display(Name = "ID")]
        public int CustomerID { get; set; }
        public int AddressID { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(200, ErrorMessage = "The name is too long(max 200 chars)")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(200, ErrorMessage = "The name is too long(max 200 chars)")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(20, ErrorMessage = "The name is too long(max 20 chars)")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(100, ErrorMessage = "The name is too long(max 100 chars)")]
        public string Email { get; set; }

        public string UserID { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

    }
}