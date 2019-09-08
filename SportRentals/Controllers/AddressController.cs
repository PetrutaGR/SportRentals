using SportRentals.Models;
using SportRentals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportRentals.Controllers
{
    public class AddressController : Controller
    {

        private AddressRepository addressRepository = new AddressRepository();
        // GET: Address
        public ActionResult Index()
        {

            List<Models.AddressModel> addresses = addressRepository.GetAllAddresses();
            return View("Index", addresses);
        }

        // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            AddressModel addressModel = addressRepository.GetAddressByID(id);
            return View("Details", addressModel);
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            return View("CreateAddress");
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                AddressModel addressModel = new AddressModel();
                UpdateModel(addressModel);
                addressRepository.InsertAddress(addressModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateAddress");
            }
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            Models.AddressModel addressModel = addressRepository.GetAddressByID(id);
            return View("EditAddress", addressModel);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Models.AddressModel addressModel = new AddressModel();
                UpdateModel(addressModel);
                addressRepository.UpdateAddress(addressModel);
                    

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditAddress");
            }
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            AddressModel addressModel = addressRepository.GetAddressByID(id);
            return View("Delete", addressModel);
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                addressRepository.DeleteAddress(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
