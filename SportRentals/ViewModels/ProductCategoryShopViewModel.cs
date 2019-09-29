using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SportRentals.Models;

namespace SportRentals.ViewModels
{
    public class ProductCategoryShopViewModel
    {

        public List<ShopModel> Shops { get; set; }

        public List<CategoryModel> Categories { get; set; }

        public List<ProductModel> Products { get; set; }

        [DisplayName("Shop")]
        public int ShopID { get; set; }

        [DisplayName("Category")]
        public int CategoryID { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid Datetime")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid Datetime")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

    }
}