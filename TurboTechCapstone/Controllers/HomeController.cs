using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurboTechCapstone.Models;


namespace TurboTechCapstone.Controllers
{

    public class HomeController : Controller
    {
        private TurboTechCapstoneDB db = new TurboTechCapstoneDB();
   

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
