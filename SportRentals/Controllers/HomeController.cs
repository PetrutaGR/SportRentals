using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SportRentals.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
         
            return View("Index");
        }

     
        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}