using SportRentals.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportRentals.Repository;
using SportRentals.ViewModels;

namespace SportRentals.Controllers
{

    
    public class CartController : Controller
    {
        private ProductRepository productRepository = new ProductRepository();
        private OrderProductsRepository orderProductsRepository = new OrderProductsRepository();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToCart(int ID)
        {
            Cart shoppingcart = Session["cart"] as Cart;

            shoppingcart.AddProduct(ID);

            Session["cart"] = shoppingcart;
            Session["numberofitems"] = shoppingcart.NumberofItems();

            return Json(new {items = shoppingcart.NumberofItems(), message = "Your product has been added!"});
        }

        public ActionResult ViewCart()
        { 
            Cart shoppingcart = new Cart();

            shoppingcart = (Cart) Session["cart"];
            int numberOfDays = (int) shoppingcart.EndDate.Subtract(shoppingcart.StartDate).TotalDays;
            ProductRepository productRepository = new ProductRepository();

            List<CartViewModel> cartcontent = new List<CartViewModel>();

            decimal total = 0;
            foreach (var productAdded in shoppingcart.productsList)
            {
                ProductModel product = productRepository.GetProductById(productAdded.ProductAddedID);

                var cartViewModel = new CartViewModel(); //(product.productID, product.prod, product.price, productAdded.ItemNumber);
                cartViewModel.ProductID = product.ProductID;
                cartViewModel.Price = product.DailyPrice;
                cartViewModel.Product = product.Name;
                cartViewModel.Quantity = productAdded.ItemNumber;


                cartcontent.Add(cartViewModel);

                total = total + (product.DailyPrice * numberOfDays * productAdded.ItemNumber);
            }

            ViewData["total"] = total;

            return View(cartcontent);
        }

        public ActionResult DeleteProduct (int ID)
        {
            Cart shoppingcart = new Cart();
            int numberOfDays = (int)shoppingcart.EndDate.Subtract(shoppingcart.StartDate).TotalDays;

            shoppingcart = (Cart) Session["cart"];

            shoppingcart.DeleteProduct((ID));

            Session["cart"] = shoppingcart;
            Session["numberofitems"] = shoppingcart.NumberofItems();

            decimal total = 0;
            foreach (var productAdded in shoppingcart.productsList)
            {
                var product = productRepository.GetProductById(productAdded.ProductAddedID);
                total = total + (product.DailyPrice * numberOfDays * productAdded.ItemNumber);
            }

            return Json(new {items = shoppingcart.NumberofItems(), productID = ID, deleted = 1, grandtotal = total});
        }

        public ActionResult RegisterOrder()
        {
            OrderProductsRepository orderProductRepository= new OrderProductsRepository( );

            Cart shoppingcart = new Cart();

            shoppingcart = (Cart) Session["cart"];

            foreach (var productAdded in shoppingcart.productsList)
            {
                OrderProductModel order = new OrderProductModel();

                order.ProductID = productAdded.ProductAddedID;
                order.OrderQuantity = productAdded.ItemNumber;

                orderProductRepository.InsertOrderProduct(order);
            }

            return View("Index");
        }

    }
}