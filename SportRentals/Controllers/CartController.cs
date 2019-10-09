using SportRentals.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportRentals.Repository;
using SportRentals.ViewModels;
using SportRentals.Models.DBObjects;
using Microsoft.AspNet.Identity;

namespace SportRentals.Controllers
{


    public class CartController : Controller
    {
        private ProductRepository productRepository = new ProductRepository();
        private OrderProductsRepository orderProductsRepository = new OrderProductsRepository();
        private CustomerRepository customerRepository = new CustomerRepository();
        private OrderRepository orderRepository = new OrderRepository();


        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewCart()
        {
            List<CartViewModel> cartcontent = new List<CartViewModel>();
            Cart shoppingcart = (Cart)Session["cart"];

            if (shoppingcart != null)
            {
                shoppingcart.Total = 0;

                shoppingcart.StartDate = (DateTime)Session["startDate"];
                shoppingcart.EndDate = (DateTime)Session["endDate"];

                int numberOfDays = (int)shoppingcart.EndDate.Subtract(shoppingcart.StartDate).TotalDays;
                if(numberOfDays == 0)
                {
                    numberOfDays = 1;
                }
                ProductRepository productRepository = new ProductRepository();

                foreach (var productAdded in shoppingcart.productsList)
                {
                    ProductModel product = productRepository.GetProductById(productAdded.ProductAddedID);

                    var cartViewModel = new CartViewModel(); //(product.productID, product.prod, product.price, productAdded.ItemNumber);
                    cartViewModel.ProductID = product.ProductID;
                    cartViewModel.Price = product.DailyPrice;
                    cartViewModel.Product = product.Name;
                    cartViewModel.Quantity = productAdded.Count;
                    cartViewModel.SubTotal = (product.DailyPrice * numberOfDays * productAdded.Count);

                    cartcontent.Add(cartViewModel);

                    shoppingcart.Total += cartViewModel.SubTotal;
                }
            }

            Session["cart"] = shoppingcart;

            ViewData["total"] = shoppingcart.Total.ToString("0.00");

            return View(cartcontent);
        }

        public ActionResult DeleteProduct(int ID)
        {
            Cart shoppingcart = new Cart();
            int numberOfDays = (int)shoppingcart.EndDate.Subtract(shoppingcart.StartDate).TotalDays;

            shoppingcart = (Cart)Session["cart"];

            shoppingcart.DeleteProduct((ID));

            Session["cart"] = shoppingcart;
            Session["numberofitems"] = shoppingcart.NumberofItems();

            decimal total = 0;
            foreach (var productAdded in shoppingcart.productsList)
            {
                var product = productRepository.GetProductById(productAdded.ProductAddedID);
                total = total + (product.DailyPrice * numberOfDays * productAdded.Count);
            }

            return Json(new { items = shoppingcart.NumberofItems(), productID = ID, deleted = 1, grandtotal = total });
        }

  

        [Authorize(Roles = "User")]
        public ActionResult Checkout()
        {
            return View("OrderSucces");
        }

        [Authorize(Roles = "User")]
        public ActionResult ProcessOrder()
        {
            OrderProductsRepository orderProductRepository = new OrderProductsRepository();
            Cart shoppingcart = new Cart();

            shoppingcart = (Cart)Session["cart"];
            var userId = User.Identity.GetUserId();
            var customer = customerRepository.GetCustomerByUserId(userId);
            
            var order = new OrderModel()
            {
                CreatedDateTime = DateTime.Now,
                StartDate = shoppingcart.StartDate,
                EndDate = shoppingcart.EndDate,
                StatusID = 1,
                Total = shoppingcart.Total,
                ShopID = (int)Session["shopId"],
                CustomerID = customer.CustomerID
            };

            var orderId = orderRepository.InsertOrder(order);

            foreach (var productAdded in shoppingcart.productsList)
            {
                OrderProductModel orderproduct = new OrderProductModel();

                orderproduct.ProductID = productAdded.ProductAddedID;
                orderproduct.OrderQuantity = productAdded.Count;
                orderproduct.OrderID = orderId;
                orderproduct.OrderSatus = "New";

                orderProductRepository.InsertOrderProduct(orderproduct);
            }

            Session["cart"] = null;
            Session["numberofitems"] = null;


            return View("OrderSucces");
        }


    }
}








         
           
    

 
