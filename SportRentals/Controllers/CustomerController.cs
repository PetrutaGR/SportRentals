using SportRentals.Models;
using SportRentals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportRentals.Controllers
{
    public class CustomerController : Controller
    {

        private CustomerRepository customerRepository = new CustomerRepository();

        // GET: Customer
        public ActionResult Index()
        {
            List<Models.CustomerModel> customers = customerRepository.GetAllCustomers();

            return View("Index", customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            CustomerModel customerModel = customerRepository.GetCustomerById(id);
            return View("Details", customerModel);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View("CreateCustomer");
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CustomerModel customerModel = new CustomerModel();
                UpdateModel(customerModel);
                customerRepository.InsertCustomer(customerModel);



                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateCustomer");
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Models.CustomerModel customerModel = customerRepository.GetCustomerById(id);
            return View("EditCustomer", customerModel);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Models.CustomerModel customerModel = new Models.CustomerModel();
                UpdateModel(customerModel);
                customerRepository.UpdateCustomer(customerModel);
                    


                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditCustomer");
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {

            CustomerModel customerModel = customerRepository.GetCustomerById(id);

            return View("Delete", customerModel);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                customerRepository.DeleteCustomer(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
