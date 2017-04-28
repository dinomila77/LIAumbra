using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIAUmbraApp.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace LIAUmbraApp.Controllers
{
    public class CreateContentSurfaceController : SurfaceController
    {
        // GET: CreateContentSurface
        public ActionResult RenderForm()
        {
            string path = "~/Views/Partials/CreateContent/";
            return PartialView($"{path}_CreateContent.cshtml");
        }

        [HttpPost]
        public ActionResult SubmitForm(ContactViewModel model)
        {
            if (!ModelState.IsValid) return CurrentUmbracoPage();

            //var umb = new UmbracoVirtualNodeByIdRouteHandler(1000);

            try
            {
                var contentService = ApplicationContext.Services.ContentService;
                //var contentService2 = ApplicationContext.Current.Services.ContentService;
                var parent = contentService.GetById(2076);

                var newContent = contentService.CreateContent("New Node", parent, "textPage");
                newContent.SetValue("bodyText","Hello");

                var result = contentService.SaveAndPublishWithStatus(newContent);

                if (result.Success)
                {
                    TempData["success"] = "Thank you!";
                    return RedirectToCurrentUmbracoPage();
                }
            }
            catch (Exception ex)
            {
                var error = $"{ex.Message}";
                ModelState.AddModelError("Error", error);
                return CurrentUmbracoPage();
            }

            return CurrentUmbracoPage();
        }

    }
}