using SportRentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Repository
{
    public class OrderProductsRepository
    {

        private Models.DBObjects.SportRentalsDataContext dbContext;
        public OrderProductsRepository()
        {
            this.dbContext = new Models.DBObjects.SportRentalsDataContext();
        }

        public OrderProductsRepository(Models.DBObjects.SportRentalsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private Models.DBObjects.OrderProduct MapModelToDbObject(OrderProductModel orderProductModel)
        {
            Models.DBObjects.OrderProduct dbOrderProduct = new Models.DBObjects.OrderProduct();
            if(orderProductModel != null)
            {
                dbOrderProduct.OrderID = orderProductModel.OrderID;
                dbOrderProduct.ProductID = orderProductModel.ProductID;
                return dbOrderProduct;
            }

            return null;
        }

        private OrderProductModel MapDbOjectToModel(Models.DBObjects.OrderProduct dbProduct)
        {
            OrderProductModel orderProductModel = new OrderProductModel();
            if(dbProduct != null)
            {
                orderProductModel.OrderID = dbProduct.OrderID;
                orderProductModel.ProductID = dbProduct.ProductID;

                return orderProductModel;
            }

            return null;
        }

        public List<OrderProductModel> GetAllOrderProducts()
        {
            List<OrderProductModel> productList = new List<OrderProductModel>();
            foreach(Models.DBObjects.OrderProduct dbProduct in dbContext.OrderProducts)
            {
                productList.Add(MapDbOjectToModel(dbProduct));
            }

            return productList;
        }

        public void InsertOrderProduct(OrderProductModel orderProductModel)
        {
            dbContext.OrderProducts.InsertOnSubmit(MapModelToDbObject(orderProductModel));
            dbContext.SubmitChanges();
        }

        public List<OrderProductModel> GetOrderProductsByOrderId(int orderId)
        {
            List<OrderProductModel> productList = new List<OrderProductModel>();
            foreach (Models.DBObjects.OrderProduct dbProduct in dbContext.OrderProducts.Where(x => x.OrderID == orderId))
            {
                productList.Add(MapDbOjectToModel(dbProduct));
            }

            return productList;
        }

        public void DeleteOrderProductByOrderId(int orderId)
        {
            Models.DBObjects.OrderProduct productToDelete = dbContext.OrderProducts.FirstOrDefault(x => x.OrderID == orderId);
            if(productToDelete !=null)
            {
                dbContext.OrderProducts.DeleteOnSubmit(productToDelete);
                dbContext.SubmitChanges();
            }
        }
        
            
        



    }
}