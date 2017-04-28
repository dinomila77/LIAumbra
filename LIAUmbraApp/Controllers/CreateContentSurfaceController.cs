using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIAUmbraApp.Models;
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
            

            return CurrentUmbracoPage();
        }

    }
}