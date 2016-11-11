using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurboTechCapstone.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult ContactUs()
        {
            return View();

        }
        public ActionResult Recipe()
        {
            return View();

        }

        public ActionResult FAQ()
        {
            return View();

        }
        public ActionResult Privacy()
        {
            return View();

        }

        

    }
}
