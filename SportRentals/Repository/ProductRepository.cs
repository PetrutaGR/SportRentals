using SportRentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Repository
{
    public class ProductRepository
    {

        private Models.DBObjects.SportRentalsDataContext dbContext;
        public ProductRepository()
        {
            this.dbContext = new Models.DBObjects.SportRentalsDataContext();
        }

        public ProductRepository(Models.DBObjects.SportRentalsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Models.DBObjects.Product MapModelToDbObject(ProductModel productModel)
        {
            Models.DBObjects.Product dbProduct = new Models.DBObjects.Product();
            if(productModel != null)
            {
                dbProduct.ProductID = productModel.ProductID;
                dbProduct.CategoryID = productModel.CategoryID;
                dbProduct.Name = productModel.Name;
                dbProduct.Description = productModel.Description;
                dbProduct.DailyPrice = productModel.DailyPrice;
                dbProduct.Stock = productModel.Stock;

                return dbProduct;
            }

            return null;
        }

        public ProductModel MapDbOjectToModel(Models.DBObjects.Product dbProduct)
        {
            ProductModel productModel = new ProductModel();
            if(dbProduct != null)
            {
                productModel.ProductID = dbProduct.ProductID;
                productModel.CategoryID = dbProduct.CategoryID;
                productModel.Name = dbProduct.Name;
                productModel.Description = dbProduct.Description;
                productModel.DailyPrice = dbProduct.DailyPrice;
                productModel.Stock = dbProduct.Stock;

                return productModel;
            }

            return null;

        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> productList = new List<ProductModel>();
            foreach(Models.DBObjects.Product dbProduct in dbContext.Products)
            {
                productList.Add(MapDbOjectToModel(dbProduct));
            }

            return productList;
        }

        public void InsertProduct(ProductModel productModel)
        {
            dbContext.Products.InsertOnSubmit(MapModelToDbObject(productModel));
            dbContext.SubmitChanges();
        }

        public ProductModel GetProductById(int ID)
        {
            return MapDbOjectToModel(dbContext.Products.FirstOrDefault(x => x.ProductID == ID));

        }

        public void UpdateProduct(ProductModel productModel)
        {
            Models.DBObjects.Product existingProduct = dbContext.Products.FirstOrDefault(x => x.ProductID == productModel.ProductID);

            if( existingProduct !=null)
            {
                existingProduct.ProductID = productModel.ProductID;
                existingProduct.CategoryID = productModel.CategoryID;
                existingProduct.Name = productModel.Name;
                existingProduct.Description = productModel.Description;
                existingProduct.DailyPrice = productModel.DailyPrice;
                existingProduct.Stock = productModel.Stock;

                dbContext.SubmitChanges();

            }
        }

        public void DeleteProduct(int ID)
        {
            Models.DBObjects.Product productToDelete = dbContext.Products.FirstOrDefault(x => x.ProductID == ID);
            if(productToDelete !=null)
            {
                dbContext.Products.DeleteOnSubmit(productToDelete);
                dbContext.SubmitChanges();
            }
        }
        
            
        



    }
}