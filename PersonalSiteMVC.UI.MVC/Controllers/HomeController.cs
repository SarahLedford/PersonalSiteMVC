using PersonalSiteMVC.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PersonalSiteMVC.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult ContactAjax(ContactViewModel cvm)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Json(cvm);
            //}

            string body = $"You have received a message from {cvm.Name}<br />{cvm.Message}<br />From email address: <strong>{cvm.Email}</strong>";

            MailMessage m = new MailMessage("admin@sarahledford.com", "Sarah_Ledford@outlook.com", cvm.Subject, body);

            m.IsBodyHtml = true;

            m.Priority = MailPriority.High;

            m.ReplyToList.Add(cvm.Email);

            SmtpClient client = new SmtpClient("mail.sarahledford.com");

            client.Credentials = new NetworkCredential("admin@sarahledford.com", "S@r@h123");

            try
            {
                client.Send(m);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.StackTrace;
            }
            return Json(cvm);
        }
    }
}