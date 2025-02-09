﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportRentals.Models
{
    public class Cart
    {
        public List<ProductAdded> productsList;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public decimal Total { get; set; }

        public Cart()
        {
            productsList= new List<ProductAdded>();
        }

        public void AddProduct(int ProductID)
        {
            var existing_product = false;
            foreach (var productAdded in productsList)
            {
                if (productAdded.ProductAddedID == ProductID)
                {
                    productAdded.Count++;
                    existing_product = true;
                    break;

                }
            }

            if (existing_product == false)
            {
                ProductAdded productAdded = new ProductAdded() {Count = 1, ProductAddedID = ProductID};

                productsList.Add(productAdded);

            }
                  
        }

        public void DeleteProduct(int ProductID)
        {
            ProductAdded product_deleted =new ProductAdded();
            foreach (var productAdded in productsList)
            {
                if (productAdded.ProductAddedID == ProductID)
                {
                    product_deleted = productAdded;
                    break;
                }
            }

            productsList.Remove(product_deleted);
        }

        public void UpdateQuantity (int ProductID, int quantity)
        {
            int k = 0;
            foreach (var productAdded in productsList)
            {
                if (productAdded.ProductAddedID == ProductID)
                {
                    productsList[k].Count = quantity;
                }

                k++;
            }

        }

        public int NumberofItems()
        {
            int sum = 0;
            foreach(var productAdded in productsList)
            {
                sum = sum + productAdded.Count;
            }

            return sum;

        }
    }

    

    public class ProductAdded
    {
        public int ProductAddedID { get; set; }
        public int Count { get; set; }
    }
}