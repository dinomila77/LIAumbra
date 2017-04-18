using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace LIAUmbraApp.Controllers
{
    public class HomePageSurfaceController : SurfaceController
    {
        // GET: HomePageSurface
        public ActionResult Index()
        {
            return CurrentUmbracoPage();
        }
    }
}