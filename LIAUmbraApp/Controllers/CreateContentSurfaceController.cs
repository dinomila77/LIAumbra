using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LIAUmbraApp.Models;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace LIAUmbraApp.Controllers
{
    public class CreateContentSurfaceController : SurfaceController
    {
        public ActionResult RenderForm()
        {
            return PartialView("_CreateContent");
        }

        [HttpPost]
        public ActionResult SubmitForm(ContactViewModel model)
        {
            if (!ModelState.IsValid) return CurrentUmbracoPage();

            if (!CurrentPage.HasValue("parentId")) return CurrentUmbracoPage();
            try
            {
                var property = CurrentPage.GetProperty("parentId");
                var parentId = property.Value;
                //var x = id.DataValue;
                var contentService = ApplicationContext.Services.ContentService;
                //var contentService2 = ApplicationContext.Current.Services.ContentService;
                var parent = contentService.GetById((int) parentId);
                var newPage = Umbraco.GetDictionaryValue("createContent");
                var firstName = Umbraco.GetDictionaryValue("firstName");
                var lastName = Umbraco.GetDictionaryValue("lastName");
                var message = Umbraco.GetDictionaryValue("emailMessage");

                var newContent = contentService.CreateContent(newPage, parent, "textPage");

                string text = $"<br/><br/><p><strong>{firstName}:</strong> {model.FirstName}</p> " +
                              $"<p><strong>{lastName}:</strong> {model.LastName}</p> " +
                              $"<p><strong>{message}:</strong> {model.Message}</p>";

                string bigtext = $"<br/><h4>{firstName}: {model.FirstName}</h4> " +
                                 $"<h4>{lastName}: {model.LastName}</h4> " +
                                 $"<h4>{message}: {model.Message}</h4>";

                newContent.SetValue("bodyText", text);
                newContent.SetValue("umbracoNaviHide",false);
                contentService.SaveAndPublishWithStatus(newContent);
                TempData["success"] = Umbraco.GetDictionaryValue("thankYou");
                return RedirectToCurrentUmbracoPage();
            }
            catch (Exception ex)
            {
                var error = $"{ex.Message}";
                ModelState.AddModelError("Error", error);
                return CurrentUmbracoPage();
            }
        }
    }
}