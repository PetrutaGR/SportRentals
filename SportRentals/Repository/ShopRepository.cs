using SportRentals.Models;
using SportRentals.Models.DBObjects;
using SportRentals.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Repository
{
    public class ShopRepository
    {
        private Models.DBObjects.SportRentalsDataContext dbContext;

        public ShopRepository()
        {
            this.dbContext = new Models.DBObjects.SportRentalsDataContext();
        }

        public ShopRepository(Models.DBObjects.SportRentalsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private ShopModel MapDbObjectToModel(Models.DBObjects.Shop dbShop)
        {
            ShopModel shopModel = new ShopModel();
            if(dbShop != null)
            {
                shopModel.ShopId = dbShop.ShopId;
                shopModel.AddressID = dbShop.AddressID;
                shopModel.Name = dbShop.Name;
                shopModel.Phone = dbShop.Phone;
                shopModel.Email = dbShop.Email;
                shopModel.CategoryID = dbShop.CategoryID;

                return shopModel;
            }
            return null;
        }

        private Models.DBObjects.Shop MapModelToDbObject(ShopModel shopModel)
        {
            Models.DBObjects.Shop dbShopModel = new Models.DBObjects.Shop();
            if(shopModel !=null)
            {
                dbShopModel.ShopId = shopModel.ShopId;
                dbShopModel.AddressID = shopModel.AddressID;
                dbShopModel.Name = shopModel.Name;
                dbShopModel.Phone = shopModel.Phone;
                dbShopModel.Email = shopModel.Email;
                dbShopModel.CategoryID = shopModel.CategoryID;

                return dbShopModel;

            }
            return null;
        }

        public List<ShopModel> GetAllShops()
        {
            List<ShopModel> shopList = new List<ShopModel>();
            foreach(Models.DBObjects.Shop dbShop in dbContext.Shops)
            {
                shopList.Add(MapDbObjectToModel(dbShop));
            }
            return shopList;
                
        }

        public ShopModel GetShopByID(int ID)
        {
            return MapDbObjectToModel(dbContext.Shops.FirstOrDefault(x => x.ShopId == ID));
        }

        public void InsertShop(ShopModel shopModel)
        {
            dbContext.Shops.InsertOnSubmit(MapModelToDbObject(shopModel));
            dbContext.SubmitChanges();
        }

        public void UpdateShop(ShopModel shopModel)
        {
            Models.DBObjects.Shop existingShop = dbContext.Shops.FirstOrDefault(x => x.ShopId == shopModel.ShopId);
            if(existingShop !=null)
            {
                existingShop.ShopId = shopModel.ShopId;
                existingShop.AddressID = shopModel.AddressID;
                existingShop.Name = shopModel.Name;
                existingShop.Phone = shopModel.Phone;
                existingShop.Email = shopModel.Email;
                existingShop.CategoryID = shopModel.CategoryID;

                dbContext.SubmitChanges();

            }
        }

        public void DeleteShop(int id)
        {
            Models.DBObjects.Shop shopToDelete = dbContext.Shops.FirstOrDefault(x => x.ShopId == id);
            if(shopToDelete!=null)
            {
                dbContext.Shops.DeleteOnSubmit(shopToDelete);
                dbContext.SubmitChanges();

            }

        }

        public ShopProductsViewModel GetShopProducts(int categoryID)
        {
            ShopProductsViewModel shopProductsViewModel = new ShopProductsViewModel();

            Shop shop = dbContext.Shops.FirstOrDefault(x => x.CategoryID == categoryID);
            if (shop != null)
            {
                shopProductsViewModel.Name = shop.Name;
            }

            IQueryable<Product> shopProducts = dbContext.Products.Where(x => x.CategoryID == categoryID);
            foreach (Product dbProduct in shopProducts)
            {
                Models.DBObjects.Product productModel = new Models.DBObjects.Product();

                productModel.Name = dbProduct.Name;
                productModel.Description = dbProduct.Description;
                productModel.DailyPrice = dbProduct.DailyPrice;
                productModel.Stock = dbProduct.Stock;

                shopProductsViewModel.Products.Add(productModel);

            }
            return shopProductsViewModel;
        }

        public ShopViewModel GetCategoryNameByID( int CategoryID)
        {
            ShopViewModel shopNameforCategoryViewModel = new ShopViewModel();

            Shop shop = dbContext.Shops.FirstOrDefault(x => x.CategoryID == CategoryID);
            if (shop != null)
            {
                shopNameforCategoryViewModel.CategoryName = shop.Name;
            }

            return shopNameforCategoryViewModel;

        }

        public ShopViewModel GetShopViewModelByID(int ID)
        {
            ShopViewModel shopViewModel = new ShopViewModel();

            Shop shop = dbContext.Shops.FirstOrDefault(x => x.ShopId == ID);
            Category shopCategory = dbContext.Categories.FirstOrDefault(x => x.CategoryID == shop.CategoryID);
            shopViewModel.CategoryName = shopCategory.Name;

            List<ShopPaymentMethod> shopPaymentMethods = dbContext.ShopPaymentMethods.Where(x => x.ShopID == ID).ToList();

            string paymentMethods = "";
            foreach (var item in shopPaymentMethods)
            {
                PaymentMethod paymentMethod = dbContext.PaymentMethods.FirstOrDefault(x => x.PaymentMethodID == item.PaymentMethodID);
                paymentMethods += paymentMethod.Name + " ";
            }

            shopViewModel.PaymentMethods = paymentMethods;

            return shopViewModel;
        }







    }


    
}