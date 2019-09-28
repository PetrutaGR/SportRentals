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
        private AddressRepository addressRepository = new AddressRepository();
        private PaymentMethodsRepository paymentMethodsRepository = new PaymentMethodsRepository();
        private ShopPaymentMethodsRepository shopPaymentMethodsRepository = new ShopPaymentMethodsRepository();
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

            var shopViewModel = new ShopEditViewModel();
            shopViewModel.Shop = shopModel;

            var categories = categoryRepository.GetAllCategories();
            SelectList categoryList = new SelectList(categories, "CategoryID", "Name");
            ViewData["CategoryList"] = categoryList;

            var address = addressRepository.GetAddressByID(shopModel.AddressID);
            shopViewModel.Address = address;

            var allPaymentMethods = paymentMethodsRepository.GetAllPaymentMethods();
            ViewData["AllPaymentMethods"] = allPaymentMethods;

            var shopPaymentMethods = paymentMethodsRepository.GetAllPaymentMethodsByShopId(shopModel.ShopId);

            List<PaymentMethodViewModel> paymentMethodViewModels = new List<PaymentMethodViewModel>();

            foreach (var paymentMethodModel in allPaymentMethods)
            {
                var paymentMethodViewModel = new PaymentMethodViewModel();
                paymentMethodViewModel.PaymentMethod = paymentMethodModel;
                
                foreach (var shopPaymentMethod in shopPaymentMethods)
                {
                    if (shopPaymentMethod.PaymentMethodID == paymentMethodModel.PaymentMethodID)
                    {
                        paymentMethodViewModel.Selected = true;
                    }
                }

                paymentMethodViewModels.Add(paymentMethodViewModel);
            }

            shopViewModel.PaymentMethods = paymentMethodViewModels;

            return View("EditShop", shopViewModel);
        }

        [Authorize(Roles = "Admin")]
        // POST: Shop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ShopEditViewModel shopViewModel = new ShopEditViewModel();
                TryUpdateModel(shopViewModel);

                var shopModel = new ShopModel();
                shopModel.ShopId = shopViewModel.Shop.ShopId;
                shopModel.AddressID = shopViewModel.Address.AddressID;
                shopModel.Email = shopViewModel.Shop.Email;
                shopModel.Name = shopViewModel.Shop.Name;
                shopModel.Phone = shopViewModel.Shop.Phone;
                shopModel.CategoryID = shopViewModel.Shop.CategoryID;
                shopRepository.UpdateShop(shopModel);

                var addressModel = new AddressModel();
                addressModel.AddressID = shopViewModel.Address.AddressID;
                addressModel.City = shopViewModel.Address.City;
                addressModel.Country = shopViewModel.Address.Country;
                addressModel.County = shopViewModel.Address.County;
                addressModel.PostCode = shopViewModel.Address.PostCode;
                addressModel.Street = shopViewModel.Address.Street;
                addressModel.StreetNumber = shopViewModel.Address.StreetNumber;
                addressRepository.UpdateAddress(addressModel);

                shopPaymentMethodsRepository.DeleteShopPaymentMethods(shopViewModel.Shop.ShopId);

                foreach (var paymentMethodViewModel in shopViewModel.PaymentMethods)
                {
                    if (paymentMethodViewModel.Selected == true)
                    {
                        var shopPaymentMethod = new ShopPaymentMethodModel();
                        shopPaymentMethod.PaymentMethodID = paymentMethodViewModel.PaymentMethod.PaymentMethodID;
                        shopPaymentMethod.ShopID = shopViewModel.Shop.ShopId;

                        shopPaymentMethodsRepository.InsertShopPaymentMethod(shopPaymentMethod);
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HandleErrorInfo error = new HandleErrorInfo(ex, "Shop", "Edit");
                return View("Error", error);
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
            catch (Exception ex)
            {
                HandleErrorInfo error = new HandleErrorInfo(ex, "Shop", "Delete");
                return View("Error", error);
            }
        }
    }
}
