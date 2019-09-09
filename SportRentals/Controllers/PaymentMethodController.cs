using SportRentals.Models;
using SportRentals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportRentals.Controllers
{
    public class PaymentMethodController : Controller
    {

        private PaymentMethodsRepository paymentMethodRepository = new PaymentMethodsRepository();
        // GET: PaymentMethod
        public ActionResult Index()
        {

            List<Models.PaymentMethodModel> paymentMethods = paymentMethodRepository.GetAllPaymentMethods();

            return View("Index", paymentMethods);
        }

        // GET: PaymentMethod/Details/5
        public ActionResult Details(int id)
        {
            PaymentMethodModel paymentMethodModel = paymentMethodRepository.GetPaymentMethodByID(id);
            return View("Details", paymentMethodModel);
        }

        // GET: PaymentMethod/Create
        public ActionResult Create()
        {
            return View("CreatePaymentMethod");
        }

        // POST: PaymentMethod/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                PaymentMethodModel paymentMethodModel = new PaymentMethodModel();
                UpdateModel(paymentMethodModel);
                paymentMethodRepository.InsertPaymentMethod(paymentMethodModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreatePaymentMethod");
            }
        }

        // GET: PaymentMethod/Edit/5
        public ActionResult Edit(int id)
        {
            Models.PaymentMethodModel paymentMethodModel = paymentMethodRepository.GetPaymentMethodByID(id);
            return View("EditPaymentMethod", paymentMethodModel);
        }

        // POST: PaymentMethod/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Models.PaymentMethodModel paymentMethodModel = new PaymentMethodModel();
                UpdateModel(paymentMethodModel);
                paymentMethodRepository.UpdatePaymentMethod(paymentMethodModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditPaymentMethod");
            }
        }

        // GET: PaymentMethod/Delete/5
        public ActionResult Delete(int id)
        {

            PaymentMethodModel paymentMethodModel = paymentMethodRepository.GetPaymentMethodByID(id);
            return View("Delete", paymentMethodModel);
        }

        // POST: PaymentMethod/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                paymentMethodRepository.DeletePaymentMethod(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
