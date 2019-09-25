using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportRentals.Models
{
    public class ProductModel
    {

        public int ProductID { get; set; }
        public int CategoryID { get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(200, ErrorMessage = "The name is too long(max 200 chars)")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(200, ErrorMessage = "The name is too long(max 200 chars)")]
        public string Description { get; set; }


        [DataType(DataType.Currency)]
        public decimal DailyPrice { get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        public int Stock { get; set; }

        public string ImageUrl { get; set; }
        


        
    }
}