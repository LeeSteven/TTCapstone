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
            var cust = db.Customer.Where(x => x.Email == User.Identity.Name).FirstOrDefault();
            if (cust != null)
            {
                Session["CustId"] = cust.CustomerId;
                Session["CustEmail"] = User.Identity.Name;
            }
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
