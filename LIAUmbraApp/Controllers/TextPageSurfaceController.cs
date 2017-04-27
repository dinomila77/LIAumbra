using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace LIAUmbraApp.Controllers
{
    public class TextPageSurfaceController : SurfaceController
    {
        // GET: TextPageSurface
        public ActionResult Index()
        {
            return CurrentUmbracoPage();
        }
    }
}