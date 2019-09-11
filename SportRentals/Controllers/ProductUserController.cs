using SportRentals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportRentals.Controllers
{
    public class ProductUserController : Controller
    {
        private ProductRepository productRepository = new Repository.ProductRepository();
        // GET: ProductUser
        public ActionResult Index()
        {
            List<Models.ProductModel> products = productRepository.GetAllProducts();
            return View("Index", products);
        }

        // GET: ProductUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductUser/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
