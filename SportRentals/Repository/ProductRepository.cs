using SportRentals.Models;
using SportRentals.Models.DBObjects;
using SportRentals.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Repository
{


    public class ProductRepository
    {

        private CategoryRepository categoryRepository = new CategoryRepository();

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
            if (productModel != null)
            {
                dbProduct.ProductID = productModel.ProductID;
                dbProduct.CategoryID = productModel.CategoryID;
                dbProduct.Name = productModel.Name;
                dbProduct.Description = productModel.Description;
                dbProduct.DailyPrice = productModel.DailyPrice;
                dbProduct.Stock = productModel.Stock;
                dbProduct.ImageUrl = productModel.ImageUrl;


                return dbProduct;
            }

            return null;
        }

        public ProductModel MapDbOjectToModel(Models.DBObjects.Product dbProduct)
        {
            ProductModel productModel = new ProductModel();
            if (dbProduct != null)
            {
                productModel.ProductID = dbProduct.ProductID;
                productModel.CategoryID = dbProduct.CategoryID;
                productModel.Name = dbProduct.Name;
                productModel.Description = dbProduct.Description;
                productModel.DailyPrice = dbProduct.DailyPrice;
                productModel.Stock = dbProduct.Stock;
                productModel.ImageUrl = dbProduct.ImageUrl;


                return productModel;
            }

            return null;

        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> productList = new List<ProductModel>();
            foreach (Models.DBObjects.Product dbProduct in dbContext.Products)
            {
                productList.Add(MapDbOjectToModel(dbProduct));
            }

            return productList;
        }
        

        public ProductCategoryViewModel GetCategoryNameByID(int CategoryID)
        {
                ProductCategoryViewModel productCategoryViewModel = new ProductCategoryViewModel();
                Product product = dbContext.Products.FirstOrDefault(x => x.CategoryID == CategoryID);

                if (product != null)
                {
                    productCategoryViewModel.CategoryName = product.Name;
                }

                return productCategoryViewModel;





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

                if (existingProduct != null)
                {
                    existingProduct.ProductID = productModel.ProductID;
                    existingProduct.CategoryID = productModel.CategoryID;
                    existingProduct.Name = productModel.Name;
                    existingProduct.Description = productModel.Description;
                    existingProduct.DailyPrice = productModel.DailyPrice;
                    existingProduct.Stock = productModel.Stock;
                    existingProduct.ImageUrl = productModel.ImageUrl;

                    dbContext.SubmitChanges();

                }
       }

       public void DeleteProduct(int ID)
       {
                Models.DBObjects.Product productToDelete = dbContext.Products.FirstOrDefault(x => x.ProductID == ID);
                if (productToDelete != null)
                {
                    dbContext.Products.DeleteOnSubmit(productToDelete);
                    dbContext.SubmitChanges();
                }
       }

        public List<ProductCategoryViewModel> GetAllProductwithName()
        {
            List<ProductCategoryViewModel> productCategoryList = new List<ProductCategoryViewModel>();
            {
                var categories = categoryRepository.GetAllCategories();
                foreach(Models.DBObjects.Product dbProduct in dbContext.Products)
                {
                    ProductCategoryViewModel productCategory = new ProductCategoryViewModel();
                    productCategory.ProductID = dbProduct.ProductID;
                    productCategory.Name = dbProduct.Name;
                    productCategory.Description = dbProduct.Description;
                    productCategory.DailyPrice = dbProduct.DailyPrice;
                    productCategory.Stock = dbProduct.Stock;
                    productCategory.ImageUrl = dbProduct.ImageUrl;
                    productCategory.CategoryID = dbProduct.CategoryID;

                    foreach(var category in categories)
                    {
                        if (category.CategoryID == productCategory.CategoryID)
                        {
                            productCategory.CategoryName = category.Name;
                        }

                        productCategoryList.Add(productCategory);
                    }

                    

                }
                return productCategoryList;
            }
        }






        
    }
}

