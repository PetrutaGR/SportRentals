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
    public class ShopController : Controller
    {

        private ShopRepository shopRepository = new ShopRepository();
        private CategoryRepository categoryRepository = new CategoryRepository();
        // GET: Shop
        public ActionResult Index()
        {

            List<ShopModel> shops = shopRepository.GetAllShops();
            return View("Index", shops);
        }

        public ActionResult ShopUI()
        {

            List<ShopModel> shops = shopRepository.GetAllShops();
            return View("ShopUI", shops);
        }



        // GET: Shop/Details/5
        public ActionResult Details(int id)
        {
            ShopModel shopModel = shopRepository.GetShopByID(id);
            return View("Details", shopModel);
        }

        public ActionResult IndexwithName(int id)
        {
            ShopViewModel shopviewModel = shopRepository.GetShopViewModelByID(id);
            return View("IndexwithName", shopviewModel);
        }

        public ActionResult ShopProducts (int id)
        {
            ShopProductsViewModel shopProductsViewModel = shopRepository.GetShopProducts(id);
            return View("ShopProducts", shopProductsViewModel);
        }

        // GET: Shop/Create
        public ActionResult Create()
        {

            var categories = categoryRepository.GetAllCategories();
            SelectList lst = new SelectList(categories, "CategoryID", "Name");
            ViewData["categories"] = lst;
            return View("CreateShop");
        }

        // POST: Shop/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ShopModel shopModel = new ShopModel();
                UpdateModel(shopModel);
                shopRepository.InsertShop(shopModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateShop");
            }
        }

        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            Models.ShopModel shopModel = shopRepository.GetShopByID(id);
            return View("EditShop", shopModel);
        }

        // POST: Shop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ShopModel shopModel = new ShopModel();
                UpdateModel(shopModel);
                shopRepository.UpdateShop(shopModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditShop");
            }
        }

        // GET: Shop/Delete/5
        public ActionResult Delete(int id)
        {
            ShopModel shopModel = shopRepository.GetShopByID(id);
            return View("Delete", shopModel);
        }

        // POST: Shop/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                shopRepository.DeleteShop(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
