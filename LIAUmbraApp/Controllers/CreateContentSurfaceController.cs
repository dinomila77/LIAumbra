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
            const string path = "~/Views/Partials/CreateContent/";
            return PartialView($"{path}_CreateContent.cshtml");
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

                var newContent = contentService.CreateContent("New Page", parent, "textPage");

                string text = $"<br/><br/><p><strong>First Name:</strong> {model.FirstName}</p> " +
                              $"<p><strong>Last Name:</strong> {model.LastName}</p> " +
                              $"<p><strong>Message:</strong> {model.Message}</p>";

                string bigtext = $"<br/><h4>First Name: {model.FirstName}</h4> " +
                                 $"<h4>Last Name: {model.LastName}</h4> " +
                                 $"<h4>Message: {model.Message}</h4>";

                newContent.SetValue("bodyText", text);
                contentService.SaveAndPublishWithStatus(newContent);
                TempData["success"] = "Thank you!";
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