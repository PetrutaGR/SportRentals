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
        // GET: Order
        public ActionResult Index()
        {
            List<Models.OrderModel> orders = orderRepository.GetAllOrders();
            return View("Index", orders);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            OrderModel orderModel = orderRepository.GetOrderByID(id);
            return View("Details", orderModel);
        }

        public ActionResult OrderProducts(int id)
        {
            OrderProductsViewModel viewModel = orderRepository.GetOrderProducts(id);

            return View("OrderProducts", viewModel);
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
            return View("EditOrder", orderModel);
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Models.OrderModel orderModel = new OrderModel();
                UpdateModel(orderModel);
                orderRepository.UpdateOrder(orderModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditOrder");
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
