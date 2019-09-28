using SportRentals.Models;
using SportRentals.Repository;
using SportRentals.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportRentals.Controllers
{
    public class OrderController : Controller
    {

        private OrderRepository orderRepository = new OrderRepository();
        private OrderProductsRepository orderProductsRepository = new OrderProductsRepository();

        private ShopRepository shopRepository = new ShopRepository();
        private CustomerRepository customerRepository = new CustomerRepository();
        private StatusRepository statusRepository = new StatusRepository();
        private ProductRepository productRepository = new ProductRepository();

        // GET: Order
        public ActionResult Index()
        {
            List<Models.OrderModel> orders = orderRepository.GetAllOrders();

            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();

            foreach (var orderModel in orders)
            {
                var orderViewModel = new OrderViewModel();
                orderViewModel.Order = orderModel;

                var shop = shopRepository.GetShopByID(orderModel.ShopID);
                orderViewModel.ShopName = shop.Name;

                var customer = customerRepository.GetCustomerById(orderModel.CustomerID);
                orderViewModel.CustomerName = customer.FirstName + " " + customer.LastName;

                var status = statusRepository.GetStatus(orderModel.StatusID);
                orderViewModel.StatusName = status.Name;

                orderViewModels.Add(orderViewModel);
            }

            return View("Index", orderViewModels);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            OrderModel orderModel = orderRepository.GetOrderByID(id);
            return View("Details", orderModel);
        }

        public ActionResult OrderProducts(int id)
        {

            OrderProductsViewModel orderProductsViewModel = new OrderProductsViewModel();

            return View("OrderProducts", orderProductsViewModel);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View("CreateOrder");
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                OrderModel orderModel = new OrderModel();
                UpdateModel(orderModel);
                orderRepository.InsertOrder(orderModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateOrder");
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            Models.OrderModel orderModel = orderRepository.GetOrderByID(id);
            
            var orderViewModel = new OrderViewModel();
            orderViewModel.Order = orderModel;

            var shop = shopRepository.GetShopByID(orderModel.ShopID);
            orderViewModel.ShopName = shop.Name;

            var customer = customerRepository.GetCustomerById(orderModel.CustomerID);
            orderViewModel.CustomerName = customer.FirstName + " " + customer.LastName;

            var statuses = statusRepository.GetAllStatuses();
            SelectList statusList = new SelectList(statuses, "StatusID", "Name");
            ViewData["StatusList"] = statusList;

            var orderProducts = orderProductsRepository.GetOrderProductsByOrderId(id);

            List<ProductModel> products = new List<ProductModel>();
            foreach (var orderProduct in orderProducts)
            {
                var product = productRepository.GetProductById(orderProduct.ProductID);
                products.Add(product);
            }

            orderViewModel.Products = products;

            return View("EditOrder", orderViewModel);
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var orderViewModel = new OrderViewModel();
                TryUpdateModel(orderViewModel);

                var orderModel = new OrderModel();
                orderModel = orderViewModel.Order;


                orderRepository.UpdateOrder(orderModel);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HandleErrorInfo error = new HandleErrorInfo(ex, "Order", "Edit");
                return View("Error", error);
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            OrderModel orderModel = orderRepository.GetOrderByID(id);
            return View("Delete", orderModel);
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                orderRepository.DeleteOrder(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
