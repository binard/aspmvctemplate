using System.Web.Profile;
using Fr.Binard.Net.Service;
using Fr.Binard.Net.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fr.Binard.Net.Web.Core.Settings;

namespace Fr.Binard.Net.Web.Core.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View(model:AppSettings.ApplicationName);
        }
    }
}