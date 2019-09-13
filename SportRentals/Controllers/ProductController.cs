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
        

        public ActionResult Index()
        {
            List<ProductModel> products = productRepository.GetAllProducts();
            return View("Index", products);
        }
        public ActionResult ProductDetails()
        {
            List<ProductCategoryViewModel> products = productRepository.GetAllProductwithName();
            return View("ProductDetails", products);
        }


        // GET: Product/Details/5
        public ActionResult Details(int id)
        {

            Models.ProductModel productModel = productRepository.GetProductById(id);
            return View("Details", productModel);
        }

        // GET: Product/Create
        public ActionResult Create()
        {

            var categories = categoryRepository.GetAllCategories();
            SelectList lst = new SelectList(categories, "CategoryID", "Name");
            ViewData["categories"] = lst;
            return View("CreateProduct");
        }

        
        // POST: Product/Create
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

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {

            Models.ProductModel productModel = productRepository.GetProductById(id);
            return View("EditProduct", productModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Models.ProductModel productModel = new Models.ProductModel();

                UpdateModel(productRepository);

                productRepository.UpdateProduct(productModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditProduct");
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {

            Models.ProductModel productModel = productRepository.GetProductById(id);

            return View("DeleteProduct", productModel);
        }

        // POST: Product/Delete/5
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
