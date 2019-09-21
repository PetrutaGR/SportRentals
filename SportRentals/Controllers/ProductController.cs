using SportRentals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportRentals.ViewModels;
using SportRentals.Models;

namespace SportRentals.Controllers
{
    public class ProductController : Controller
    {

        private ProductRepository productRepository = new Repository.ProductRepository();
        private CategoryRepository categoryRepository = new CategoryRepository();

        // GET: Product

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<ProductModel> products = productRepository.GetAllProducts();
            return View("Index", products);
        }

        [Authorize(Roles = "User")]
        public ActionResult ProductDetails()
        {
            List<ProductCategoryViewModel> products = productRepository.GetAllProductwithName();
            return View("ProductDetails", products);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {

            Models.ProductModel productModel = productRepository.GetProductById(id);
            return View("Details", productModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {

            var categories = categoryRepository.GetAllCategories();
            SelectList lst = new SelectList(categories, "CategoryID", "Name");
            ViewData["categories"] = lst;
            return View("CreateProduct");
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Models.ProductModel productModel = new Models.ProductModel();
                UpdateModel(productModel);

                productRepository.InsertProduct(productModel);
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateProduct");
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {

            Models.ProductModel productModel = productRepository.GetProductById(id);
            return View("EditProduct", productModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Models.ProductModel productModel = new Models.ProductModel();

                UpdateModel(productModel);

                productRepository.UpdateProduct(productModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditProduct");
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {

            Models.ProductModel productModel = productRepository.GetProductById(id);

            return View("DeleteProduct", productModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                productRepository.DeleteProduct(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteProduct");
            }
        }
    }
}
