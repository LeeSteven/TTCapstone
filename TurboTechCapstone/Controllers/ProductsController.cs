﻿using System;
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
    public class ProductsController : Controller
    {
        private TurboTechCapstoneDB db = new TurboTechCapstoneDB();

        // GET: Products
        public ActionResult Index(int? id, string searchBy, string search)
        {
            ViewBag.OrderNum = id;
            var allProds = db.Product.ToList();
            ViewBag.AllProducts = allProds;
            ViewBag.ProductOrder = allProds.ToList();

            if (searchBy == "Name")
            {
                return View(db.Product.Where(x => x.ProductName.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.Product.Where(x => x.Category.StartsWith(search) || search == null).ToList());
            }

      
        
        }
        [HttpPost]
        public ActionResult Index(int prodID, int ordId)
        {
            Product prod = db.Product.Find(prodID);
            Order ord = db.Order.Find(ordId);

            //if (prod == null || ord == null)
            //{
            //    return HttpNotFound();
            //}

            OrderAndProducts orderAndProducts = new OrderAndProducts();
            orderAndProducts.Order_Id = ord.OrderId;
            orderAndProducts.Product_Id = prod.ProductId;
            orderAndProducts.Order = ord;
            orderAndProducts.Product = prod;

            if (ModelState.IsValid)
            {
                db.OrderAndProducts.Add(orderAndProducts);

                db.SaveChanges();
                return RedirectToAction("index/" + ord.OrderId, "Orders");
            }

            ViewBag.Order_Id = new SelectList(db.Order, "Id", "UserName", orderAndProducts.Order_Id);
            ViewBag.Product_Id = new SelectList(db.Product, "Id", "Name", orderAndProducts.Product_Id);
            return RedirectToAction("index", "Orders");
           


        }
        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Category,Description,Quantity,Price,Image")] Product product)
        {
          
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");

     
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Description,Quantity,Price,Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
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
