using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TurboTechCapstone.Models;

namespace TurboTechCapstone.Controllers
{
    public class CustomersController : Controller
    {
        private TurboTechCapstoneDB db = new TurboTechCapstoneDB();

        // GET: Customers
        public ActionResult Index()
        {
            var holder = ViewBag.CustEmail;

            var customer = db.Customer.Include(c => c.Login);
                return View(customer.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [Authorize]
        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Login, "CustomerId", "Username");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,City,Country,Province,Address,PostalCode,Email,Phone,OrderId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //customer.Email = (string)ViewBag.CustEmail;
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index/"+ (string)Session["CustId"]);
            }

            ViewBag.CustomerId = new SelectList(db.Login, "CustomerId", "Username", customer.CustomerId);
            return View(customer);
        }

        [Authorize]
        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Login, "CustomerId", "Username", customer.CustomerId);
            return View(customer);
        }


        [Authorize]
        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName,City,Country,Province,Address,PostalCode,Email,Phone,OrderId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                customer.Email = User.Identity.Name;
                db.SaveChanges();
                return RedirectToAction("Details/"+ customer.CustomerId + "");
            }
            ViewBag.CustomerId = new SelectList(db.Login, "CustomerId", "Username", customer.CustomerId);
            return View(customer);
        }


        [Authorize]
        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        [Authorize]
        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

      
    }
}