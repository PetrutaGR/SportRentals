using SportRentals.Models;
using SportRentals.Repository;
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
        // GET: Shop
        public ActionResult Index()
        {

            List<ShopModel> shops = shopRepository.GetAllShops();
            return View("Index", shops);
        }

        // GET: Shop/Details/5
        public ActionResult Details(int id)
        {
            ShopModel shopModel = shopRepository.GetShopByID(id);
            return View("Details", shopModel);
        }

        // GET: Shop/Create
        public ActionResult Create()
        {
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
