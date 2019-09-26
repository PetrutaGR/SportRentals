using SportRentals.Models;
using SportRentals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportRentals.Controllers
{
    public class CategoryController : Controller
    {

        private CategoryRepository categoryRepository = new CategoryRepository();
        private ProductRepository productRepository = new ProductRepository();
        private ShopRepository shopRepository = new ShopRepository();


        // GET: Category
        public ActionResult Index()
        {
            List<Models.CategoryModel> categories = categoryRepository.GetAllCategories();
            return View("Index", categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View("CreateCategory");
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CategoryModel categoryModel = new CategoryModel();
                UpdateModel(categoryModel);
                categoryRepository.InsertCategory(categoryModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateCategory");
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
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

        // GET: Category/Delete/5
        public ActionResult Delete(int ID)
        {
            CategoryModel categoryModel = categoryRepository.GetCategoryByID(ID);

            return View("Delete", categoryModel);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int ID, FormCollection collection)
        {
            try
            {
                List<ProductModel> products = productRepository.GetAllProductsByCategoryID(ID);
                foreach(ProductModel product in products)
                {
                    productRepository.DeleteProduct(product.ProductID);
                }

                List<ShopModel> shops = shopRepository.GetAllShopsByCategoryID(ID);
                foreach (ShopModel shop in shops)
                {
                    shopRepository.DeleteShop(ID);
                }

                categoryRepository.DeleteCategory(ID);
             
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
