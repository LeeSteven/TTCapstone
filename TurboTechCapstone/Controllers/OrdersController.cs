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
    [Authorize]
    public class OrdersController : Controller
    {
         
        private TurboTechCapstoneDB db = new TurboTechCapstoneDB();


        public ActionResult Charge(string stripeToken, string stripeEmail)
        {
            string apiKey = "sk_test_uyHOoT6jWFyehqUw3fUDdlna";
            var stripeClient = new Stripe.StripeClient(apiKey);

            dynamic response = stripeClient.CreateChargeWithToken(2501, stripeToken, "CAD", stripeEmail);

            if (response.IsError == false && response.Paid)
            {
                // success
            }

            return RedirectToAction("PaymentSucceed");

        }
        // GET: Orders
        public ActionResult Index(int? id)
        {
            var holder = (int)Session["CustId"];
            
            var holder2 = db.Orders.Where(x => x.CustomerId == holder && x.Shippment == false).FirstOrDefault();
            if(holder2 == null)
            {
                return View();

            }
            var prodorder = db.OrderAndProducts.Where(y => y.Order_Id == holder2.OrderId).Include(p => p.Order).Include(p => p.Product).ToList();
            ViewBag.ProductOrder = prodorder;   

            var count = db.Product.ToList();

            //test
            var testCount = count.Count();
            int[] amount = new int[testCount+2];

            //for (int i = 0; i <= testCount+2; i++)
            //{
            //    amount[i] = 0;
            //}
            foreach (var item in count)
            {

                amount[item.ProductId] = amount[item.ProductId]+1;
            }

            //end

            int[] array = new int[count.Count + 1];

            for (int i = 0; i < count.Count; i++)
            {
                array[i] = 0;
            }

            var populate = db.OrderAndProducts.Where(x => x.Order_Id == id);

            foreach (var item in populate)
            {
                array[item.Product_Id]++;
            }

            ViewBag.quant = array;
            ViewBag.count = count.Count;
            ViewBag.amount = amount;

            return View();
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {


                 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            IEnumerable<Product> prods = db.Product.ToList();
           
            //Example  
            IEnumerable<Orders> orders = db.Orders.Where(x => x.CustomerId == 1);

            var model = new OrderAndProducts { };


            return View(model);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "FirstName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "OrderId,ProductName,Quantity,SubTotal,Total,Date,Image,CustomerId")] Order order)
        public ActionResult Create([Bind(Include = "ProductName,Quantity,Image,CustomerId")] Orders order)
        {
    
            //if (ModelState.IsValid)
            //{

            //    order.ProductName = ViewBag.prod;
            //    order.ProductName = Request.Form["ProductName"];
            //    order.CustomerId = 1;
            //    db.Orders.Add(order); 
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "FirstName", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "FirstName", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,ProductName,Quantity,SubTotal,Total,Date,Image,CustomerId")] Orders order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "FirstName", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders order = db.Orders.Find(id);
            db.Orders.Remove(order);
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


        [HttpGet]
        public ActionResult PaymentSucceed()
        {
            var holder = User.Identity.Name;

            Orders order = db.Orders.Where(x => x.Customer.Email == holder).Where(y => y.Shippment == false).FirstOrDefault();
            order.Shippment = true;
            db.SaveChanges();
            Orders ord = new Orders();
            ord.Shippment = false;
            ord.CustomerId = order.CustomerId;

            db.Orders.Add(ord);
            
            db.SaveChanges();

            return View("PaymentSucceed");

        }
    }
}
