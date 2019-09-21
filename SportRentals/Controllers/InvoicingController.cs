using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SportRentals.Controllers
{
    public class InvoicingController : Controller
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
                    var password = "Proiect.2019!";
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


        // GET: Invoicing/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Invoicing/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invoicing/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Invoicing/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
