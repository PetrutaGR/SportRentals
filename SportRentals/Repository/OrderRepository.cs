using SportRentals.Models;
using SportRentals.Models.DBObjects;
using SportRentals.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Repository
{
    public class OrderRepository
    {
        private Models.DBObjects.SportRentalsDataContext dbContext;

        public OrderRepository()
        {
            this.dbContext = new Models.DBObjects.SportRentalsDataContext();
        }

        public OrderRepository(Models.DBObjects.SportRentalsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private OrderModel MapDbObjectToModel(Models.DBObjects.Order dbOrder)
        {
            OrderModel orderModel = new OrderModel();
            if(dbOrder!=null)
            {
                orderModel.OrderID = dbOrder.OrderID;
                orderModel.CustomerID = dbOrder.CustomerID;
                orderModel.ShopID = dbOrder.ShopID;
                orderModel.StartDate = dbOrder.StartDate;
                orderModel.EndDate = dbOrder.EndDate;
                orderModel.CreatedDateTime = dbOrder.CreatedDateTime;
                orderModel.StatusID = dbOrder.StatusID;
                orderModel.Total = dbOrder.Total;

                return orderModel;
                    
            }
            return null;

        }

        private Models.DBObjects.Order MapModelToDbObject(OrderModel orderModel)
        {
            Models.DBObjects.Order dbOrderModel = new Models.DBObjects.Order();
            if(orderModel !=null)
            {
                dbOrderModel.OrderID = orderModel.OrderID;
                dbOrderModel.CustomerID = orderModel.CustomerID;
                dbOrderModel.ShopID = orderModel.ShopID;
                dbOrderModel.StartDate = orderModel.StartDate;
                dbOrderModel.EndDate = orderModel.EndDate;
                dbOrderModel.CreatedDateTime = orderModel.CreatedDateTime;
                dbOrderModel.StatusID = orderModel.StatusID;
                dbOrderModel.Total = orderModel.Total;

                return dbOrderModel;

            }
            return null;
        }

        public List<OrderModel> GetAllOrders()
        {
            List<OrderModel> orderList = new List<OrderModel>();
            foreach(Models.DBObjects.Order dbOrder in dbContext.Orders)
            {
                orderList.Add(MapDbObjectToModel(dbOrder));
            }

            return orderList;
        }

        public OrderModel GetOrderByID(int ID)
        {
            return MapDbObjectToModel(dbContext.Orders.FirstOrDefault(x => x.OrderID == ID));
        }

        public List<OrderModel> GetOrderByEffectiveDates(DateTime startDate, DateTime endDate)
        {
            List<OrderModel> orderList = new List<OrderModel>();
            foreach(Models.DBObjects.Order dbOrder in dbContext.Orders.Where(x=>x.StartDate >=startDate && x.EndDate <= endDate))
            {
                orderList.Add(MapDbObjectToModel(dbOrder));
            }
            return orderList;
        }

        public void InsertOrder(OrderModel orderModel)
        {
            dbContext.Orders.InsertOnSubmit(MapModelToDbObject(orderModel));
            dbContext.SubmitChanges();
        }

        public void UpdateOrder(OrderModel orderModel)
        {
            Models.DBObjects.Order existingOrder = dbContext.Orders.FirstOrDefault(x => x.OrderID == orderModel.OrderID);
            if(existingOrder !=null)
            {
                existingOrder.OrderID = orderModel.OrderID;
                existingOrder.CustomerID = orderModel.CustomerID;
                existingOrder.ShopID = orderModel.ShopID;
                existingOrder.StartDate = orderModel.StartDate;
                existingOrder.EndDate = orderModel.EndDate;
                existingOrder.CreatedDateTime = orderModel.CreatedDateTime;
                existingOrder.StatusID = orderModel.StatusID;
                existingOrder.Total = orderModel.Total;
                dbContext.SubmitChanges();

            }
        }

        public void DeleteOrder(int ID)
        {
            Models.DBObjects.Order orderToDelete = dbContext.Orders.FirstOrDefault(x => x.OrderID == ID);
            if(orderToDelete!=null)
            {
                dbContext.Orders.DeleteOnSubmit(orderToDelete);
                dbContext.SubmitChanges();
            }
        }

        public List<OrderModel> GetAllOrdersByShopID(int ID)
        {
            List<OrderModel> ordersList = new List<OrderModel>();
            List<Order> order = dbContext.Orders.Where(x => x.ShopID == ID).ToList();
            foreach(Models.DBObjects.Order dbOrder in order)
            {
                OrderModel orderModel = new OrderModel();
                orderModel.OrderID = dbOrder.OrderID;
                orderModel.CustomerID = dbOrder.CustomerID;
                orderModel.ShopID = dbOrder.ShopID;
                orderModel.StartDate = dbOrder.StartDate;
                orderModel.EndDate = dbOrder.EndDate;
                orderModel.Total = dbOrder.Total;
                orderModel.CreatedDateTime = dbOrder.CreatedDateTime;
                orderModel.StatusID = dbOrder.StatusID;

                ordersList.Add(orderModel);
            }
            return ordersList;
        }

        public List<OrderModel> GetAllOrdersByCustomerID(int ID)
        {
            List<OrderModel> ordersList = new List<OrderModel>();
            List<Order> order = dbContext.Orders.Where(x => x.CustomerID == ID).ToList();
            foreach (Models.DBObjects.Order dbOrder in order)
            {
                OrderModel orderModel = new OrderModel();
                orderModel.OrderID = dbOrder.OrderID;
                orderModel.CustomerID = dbOrder.CustomerID;
                orderModel.ShopID = dbOrder.ShopID;
                orderModel.StartDate = dbOrder.StartDate;
                orderModel.EndDate = dbOrder.EndDate;
                orderModel.Total = dbOrder.Total;
                orderModel.CreatedDateTime = dbOrder.CreatedDateTime;
                orderModel.StatusID = dbOrder.StatusID;

                ordersList.Add(orderModel);
            }
            return ordersList;
        }

        public void DeleteOrderProductByOrderId(int orderId)
        {
            Models.DBObjects.OrderProduct productToDelete = dbContext.OrderProducts.FirstOrDefault(x => x.OrderID == orderId);
            if (productToDelete != null)
            {
                dbContext.OrderProducts.DeleteOnSubmit(productToDelete);
                dbContext.SubmitChanges();
            }
        }

    }
}