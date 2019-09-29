using SportRentals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportRentals.Models;
using SportRentals.ViewModels;

namespace SportRentals.Controllers
{
    public class ProductUserController : Controller
    {
        private ProductRepository productRepository = new Repository.ProductRepository();
        private ShopRepository shopRepository = new ShopRepository();
        private CategoryRepository categoryRepository = new CategoryRepository();
        // GET: ProductUser


        [Authorize(Roles = "User")]
        public ActionResult Index()
        {
            var shopViewModel = new ProductCategoryShopViewModel();

            var shops = shopRepository.GetAllShops();
            var orderedShops = shops.OrderBy(x => x.Name);
            shopViewModel.ShopID = orderedShops.FirstOrDefault().ShopId;

            SelectList shopList = new SelectList(orderedShops, "ShopID", "Name");
            ViewData["ShopList"] = shopList;

            shopViewModel.StartDate = DateTime.Today;
            shopViewModel.EndDate = DateTime.Today;

            shopViewModel.Products = productRepository.GetAllProducts();


            return View("IndexUser", shopViewModel);
        }

        [HttpPost]

        [Authorize(Roles = "User")]
        public ActionResult Search(FormCollection collection)
        {
            var shopViewModel = new ProductCategoryShopViewModel();
            TryUpdateModel(shopViewModel);


            var shops = shopRepository.GetAllShops();
            var orderedShops = shops.OrderBy(x => x.Name);
            SelectList shopList = new SelectList(orderedShops, "ShopID", "Name");
            ViewData["ShopList"] = shopList;

            var shop = shops.FirstOrDefault(x => x.ShopId == shopViewModel.ShopID);

            shopViewModel.Products = productRepository.GetAllProductsByCategoryID(shop.CategoryID);


            return View("IndexUser", shopViewModel);

        }

        //// GET: ProductUser/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: ProductUser/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: ProductUser/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ProductUser/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: ProductUser/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ProductUser/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ProductUser/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpPost]
        public ActionResult Checkout(FormCollection collection)
        {
            throw new NotImplementedException();
        }
    }
}
