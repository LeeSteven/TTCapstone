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
    public class OrderAndProductsController : Controller
    {
        private TurboTechCapstoneDB db = new TurboTechCapstoneDB();

        // GET: OrderAndProducts
        public ActionResult Index(int? id)
        {
            ViewBag.TotalCount = db.Product.ToList().Count;

            

            return View();
          
        }
        

        // GET: OrderAndProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderAndProducts orderAndProducts = db.OrderAndProducts.Find(id);
            if (orderAndProducts == null)
            {
                return HttpNotFound();
            }
            return View(orderAndProducts);
        }

        // GET: OrderAndProducts/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: OrderAndProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Product_Id,Order_Id")] OrderAndProducts orderAndProducts)
        {
            if (ModelState.IsValid)
            {
                db.OrderAndProducts.Add(orderAndProducts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderAndProducts);
        }

        // GET: OrderAndProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderAndProducts orderAndProducts = db.OrderAndProducts.Find(id);
            if (orderAndProducts == null)
            {
                return HttpNotFound();
            }
            return View(orderAndProducts);
        }

        // POST: OrderAndProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Product_Id,Order_Id")] OrderAndProducts orderAndProducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderAndProducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderAndProducts);
        }

        // GET: OrderAndProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderAndProducts orderAndProducts = db.OrderAndProducts.Find(id);
            if (orderAndProducts == null)
            {
                return HttpNotFound();
            }
            return View(orderAndProducts);
        }

        // POST: OrderAndProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderAndProducts orderAndProducts = db.OrderAndProducts.Find(id);
            db.OrderAndProducts.Remove(orderAndProducts);
            db.SaveChanges();
             return RedirectToAction("index/" + ViewBag.Order_Id, "Order");
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
