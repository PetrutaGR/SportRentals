using SportRentals.Repository;
using SportRentals.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Models
{
    public class Service
    {
        private ShopRepository shopRepository = new ShopRepository();
        private CategoryRepository categoryRepository = new CategoryRepository();
        private OrderRepository orderRepository = new OrderRepository();
        private AddressRepository addressRepository = new AddressRepository();
        private PaymentMethodsRepository paymentMethodsRepository = new PaymentMethodsRepository();
        public List<ShopViewModel> GetAllShops()
        {
            List<ShopModel> shops = shopRepository.GetAllShopswithName();
            var categories = categoryRepository.GetAllCategories();

            List<ShopViewModel> shopViewModels = new List<ShopViewModel>();

            foreach (var shop in shops)
            {
                var shopViewModel = new ShopViewModel()
                {
                    Name = shop.Name,
                    Email = shop.Email,
                    Phone = shop.Phone,
                    ShopId = shop.ShopId,
                    CategoryId = shop.CategoryID
                };


                foreach (var category in categories)
                {
                    if (category.CategoryID == shop.CategoryID)
                    {
                        shopViewModel.CategoryName = category.Name;
                    }
                }

                var address = addressRepository.GetAddressByID(shop.AddressID);

                string addressDetails = $"{address.StreetNumber}, {address.Street}, {address.PostCode}, {address.County}, {address.City}, {address.Country}";

                shopViewModel.Address = addressDetails;

                var paymentMethods = paymentMethodsRepository.GetAllPaymentMethodsByShopId(shop.ShopId);

                shopViewModel.PaymentMethods = string.Join(", ", paymentMethods.Select(x => x.Name));

                //foreach (var paymentMethod in paymentMethods)
                //{
                //    shopViewModel.PaymentMethods += $"{paymentMethod.Name},";
                //}

                
                shopViewModels.Add(shopViewModel);
            }

            return shopViewModels;
        }
    }
}