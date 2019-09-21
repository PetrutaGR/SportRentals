using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportRentals.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ShopID { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Invalid Datetime")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }



        [DataType(DataType.DateTime, ErrorMessage = "Invalid Datetime")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }


        [DisplayName("Total Amount")]
        [Range(1, 1000, ErrorMessage = "Price must be between $1 and $1000")]
        public double Total { get; set;}


        [DataType(DataType.DateTime, ErrorMessage = "Invalid Datetime")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDateTime { get; set; }
    }
}