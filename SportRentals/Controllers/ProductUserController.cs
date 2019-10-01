using SportRentals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportRentals.Models;
using SportRentals.ViewModels;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace SportRentals.Controllers
{
    public class ProductUserController : Controller
    {
        private ProductRepository productRepository = new Repository.ProductRepository();
        private ShopRepository shopRepository = new ShopRepository();
        private CategoryRepository categoryRepository = new CategoryRepository();


       
        public ActionResult Index()
        {
            var shopViewModel = new ProductCategoryShopViewModel();

            var shops = shopRepository.GetAllShops();
            shops.Add(new ShopModel() { Name = "- All -", ShopId = 0 });

            var orderedShops = shops.OrderBy(x => x.Name);
            SelectList shopList = new SelectList(orderedShops, "ShopID", "Name");
            ViewData["ShopList"] = shopList;

            var shop = orderedShops.FirstOrDefault();



            if (Session["startDate"] != null && Session["endDate"] != null)
            {
                shopViewModel.StartDate = (DateTime)Session["startDate"];
                shopViewModel.EndDate = (DateTime)Session["endDate"];
            }
            else
            {
                shopViewModel.StartDate = DateTime.Today;
                shopViewModel.EndDate = DateTime.Today;
            }


            if (Session["shopId"] != null)
            {
                shopViewModel.ShopID = (int)Session["shopId"];
            }
            else
            {
                shopViewModel.ShopID = 0;
            }


            if (Session["products"] != null)
            {
                shopViewModel.Products = (List<ProductModel>)Session["products"];
            }
            else
            {
                shopViewModel.Products = productRepository.GetAllProducts();
            }


            return View("IndexUser", shopViewModel);
        }


        [HttpPost]
        public ActionResult Search(FormCollection collection)
        {
            var shopViewModel = new ProductCategoryShopViewModel();
            TryUpdateModel(shopViewModel);

            var shops = shopRepository.GetAllShops();
            shops.Add(new ShopModel() { Name = "- All -", ShopId = 0 });

            var orderedShops = shops.OrderBy(x => x.Name);
            SelectList shopList = new SelectList(orderedShops, "ShopID", "Name");
            ViewData["ShopList"] = shopList;

            var shop = shops.FirstOrDefault(x => x.ShopId == shopViewModel.ShopID);

            if (shopViewModel.ShopID == 0)
            {
                shopViewModel.Products = productRepository.GetAllProducts();
            }
            else
            {
                shopViewModel.Products = productRepository.GetAllProductsByCategoryID(shop.CategoryID);
            }

            Session["startDate"] = shopViewModel.StartDate;
            Session["endDate"] = shopViewModel.EndDate;
            Session["shopId"] = shopViewModel.ShopID;
            Session["Products"] = shopViewModel.Products;
            Session["shopId"] = shopViewModel.ShopID;

            return View("IndexUser", shopViewModel);

        }


        public ActionResult AddToCart(int ID)
        {
            Cart shoppingcart = Session["cart"] as Cart;

            if(shoppingcart == null)
            {
                shoppingcart = new Cart();
            }

            shoppingcart.AddProduct(ID);

            Session["cart"] = shoppingcart;
            Session["numberofitems"] = shoppingcart.NumberofItems();
            
            TempData["ProductAdded"] = true;
            //return Json(new { items = shoppingcart.NumberofItems(), message = "Your product has been added!" }, JsonRequestBehavior.AllowGet);
            



            return RedirectToAction("Index");
        }

        // GET: ProductUser/Details/5
        public ActionResult Details(int id)
        {
            Models.ProductModel productModel = productRepository.GetProductById(id);
            return View("Details", productModel);
        }

    
        [HttpPost]
        public ActionResult Checkout(FormCollection collection)
        {
            var shopViewModel = new ProductCategoryShopViewModel();
            TryUpdateModel(shopViewModel);

            return RedirectToAction("ViewCart", "Cart");
        }
    }
}
