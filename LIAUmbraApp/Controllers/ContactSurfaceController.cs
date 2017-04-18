using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using LIAUmbraApp.Models;
using Umbraco.Web.Mvc;

namespace LIAUmbraApp.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        public ActionResult RenderForm()
        {
            const string partialViewFolder = "~/Views/Partials/Contact/";
            return PartialView($"{partialViewFolder}_Contact.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                SendMail(model);
                return RedirectToCurrentUmbracoPage();
            }

            return CurrentUmbracoPage();
        }

        private void SendMail(ContactModel model)
        {
            var client = new SmtpClient();
            var msg = new MailMessage("noreply@authority.com", model.EmailAddress)
            {
                Subject = "Testing send email",
                Body = model.Message
            };

            client.Send(msg);
        }
    }
}