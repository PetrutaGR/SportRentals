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
            Session["valoare"] = 12;
            return View("SendEmail");
        }
        public ActionResult SendEmail()
        {
            if (Session["valoare"] != null)
            {
                int x = 0;
                x = int.Parse(Session["valoare"].ToString());
            }
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("gbrlpetruta@gmail.com", "Gabriela");
                    var receiverEmail = new MailAddress(receiver, "gabrielarotar26@gmail.com");
                    var password = "Proiect.2019";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception )
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}