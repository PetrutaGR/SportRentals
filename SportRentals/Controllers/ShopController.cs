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
        private OrderRepository orderRepository = new OrderRepository();

        // GET: Shop
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var service = new Service();
            List<ShopViewModel> shopViewModels = service.GetAllShops();

            return View("Index", shopViewModels);
        }

        [Authorize(Roles = "User,Admin")]
        public ActionResult ShopUI()
        {

            List<ShopModel> shops = shopRepository.GetAllShops();
            return View("ShopUI", shops);
        }



        // GET: Shop/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            ShopModel shopModel = shopRepository.GetShopByID(id);
            return View("Details", shopModel);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult IndexwithName(int id)
        {
            ShopViewModel shopviewModel = shopRepository.GetShopViewModelByID(id);
            return View("IndexwithName", shopviewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ShopProducts (int id)
        {
            ShopProductsViewModel shopProductsViewModel = shopRepository.GetShopProducts(id);
            return View("ShopProducts", shopProductsViewModel);
        }

        [Authorize(Roles = "Admin")]
        // GET: Shop/Create
        public ActionResult Create()
        {

            var categories = categoryRepository.GetAllCategories();
            SelectList lst = new SelectList(categories, "CategoryID", "Name");
            ViewData["categories"] = lst;
            return View("CreateShop");
        }

        [Authorize(Roles = "Admin")]
        // POST: Shop/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ShopModel shopModel = new ShopModel();
                TryUpdateModel(shopModel);
                shopRepository.InsertShop(shopModel);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                HandleErrorInfo error = new HandleErrorInfo(ex, "Shop", "Create");
                return View("Error", error);
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            Models.ShopModel shopModel = shopRepository.GetShopByID(id);
            return View("EditShop", shopModel);
        }

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int ID, FormCollection collection)
        {
            try
            {
                List<OrderModel> orders = orderRepository.GetAllOrdersByShopID(ID);
                foreach(OrderModel order in orders)
                {
                    orderRepository.DeleteOrder(order.OrderID);
                }
                shopRepository.DeleteShop(ID);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
