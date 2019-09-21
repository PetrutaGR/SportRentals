using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportRentals.Models
{
    public class CategoryModel
    {

        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(100, ErrorMessage = "The name is too long(max 100 chars)")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(500, ErrorMessage = "The name is too long(max 500 chars)")]
        public string Description { get; set; }
    }
}