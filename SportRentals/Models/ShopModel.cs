using SportRentals.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportRentals.Models
{
    public class ShopModel
    {
        [Display(Name = "ID")]
        [Editable(false)]
        public int ShopId { get; set; }
        public int AddressID { get; set;}

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "The name is too long(max 50 chars)")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "The name is too long(max 50 chars)")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "The name is too long(max 50 chars)")]
        public string Email { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }


    }
}