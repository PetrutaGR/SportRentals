using SportRentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Repository
{
    public class ShopPaymentMethodsRepository
    {

        private Models.DBObjects.SportRentalsDataContext dbContext;

        public ShopPaymentMethodsRepository()
        {
            this.dbContext = new Models.DBObjects.SportRentalsDataContext();
        }

        public ShopPaymentMethodsRepository(Models.DBObjects.SportRentalsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private Models.DBObjects.ShopPaymentMethod MapModelToDbObject(ShopPaymentMethodModel shopPaymentMethodModel)
        {
            Models.DBObjects.ShopPaymentMethod dbShopPaymentMethod = new Models.DBObjects.ShopPaymentMethod();
            if (shopPaymentMethodModel != null)
            {
                dbShopPaymentMethod.ShopID = shopPaymentMethodModel.ShopID;
                dbShopPaymentMethod.PaymentMethodID = shopPaymentMethodModel.PaymentMethodID;
                return dbShopPaymentMethod;
            }

            return null;
        }

        private ShopPaymentMethodModel MapDbOjectToModel(Models.DBObjects.ShopPaymentMethod dbShopPaymentMethod)
        {
            ShopPaymentMethodModel shopPaymentMethodModel = new ShopPaymentMethodModel();
            if (dbShopPaymentMethod != null)
            {
                shopPaymentMethodModel.ShopID = dbShopPaymentMethod.ShopID;
                shopPaymentMethodModel.PaymentMethodID = dbShopPaymentMethod.PaymentMethodID;

                return shopPaymentMethodModel;
            }

            return null;
        }

        public List<ShopPaymentMethodModel> GetAllShopPaymentMethods()
        {
            List<ShopPaymentMethodModel> shopPaymentMethodList = new List<ShopPaymentMethodModel>();
            foreach (Models.DBObjects.ShopPaymentMethod dbShopPaymentMethod in dbContext.ShopPaymentMethods)
            {
                shopPaymentMethodList.Add(MapDbOjectToModel(dbShopPaymentMethod));
            }

            return shopPaymentMethodList;
        }

        public void InsertShopPaymentMethod(ShopPaymentMethodModel shopPaymentMethodModel)
        {
            dbContext.ShopPaymentMethods.InsertOnSubmit(MapModelToDbObject(shopPaymentMethodModel));
            dbContext.SubmitChanges();
        }


        public void DeleteShopPaymentMethods(int shopId)
        {
            var shopPaymentMethods = dbContext.ShopPaymentMethods.Where(x => x.ShopID == shopId);
            dbContext.ShopPaymentMethods.DeleteAllOnSubmit(shopPaymentMethods);

            dbContext.SubmitChanges();
        }






    }
}