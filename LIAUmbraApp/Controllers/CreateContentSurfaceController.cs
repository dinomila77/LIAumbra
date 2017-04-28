using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace LIAUmbraApp.Controllers
{
    public class CreateContentSurfaceController : SurfaceController
    {
        // GET: CreateContentSurface
        public ActionResult RenderForm()
        {
            return CurrentUmbracoPage();
        }

        public ActionResult SubmitForm()
        {
            return CurrentUmbracoPage();
        }

    }
}