using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bonsal_Gardent.Areas.Admin.Data;

namespace Bonsal_Gardent.Areas.Admin.Controllers
{
    public class CustomerOrdersController : Controller
    {
        private Bonsal_GardentEntities db = new Bonsal_GardentEntities();

        // GET: Admin/CustomerOrders
        public ActionResult Index()
        {
            var customerOrders = db.CustomerOrders.Include(c => c.AccCustomer);
            return View(customerOrders.ToList());
        }

        // GET: Admin/CustomerOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customerOrder = db.CustomerOrders.Find(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            return View(customerOrder);
        }

        // GET: Admin/CustomerOrders/Create
        public ActionResult Create()
        {
            ViewBag.AccCustomerID = new SelectList(db.AccCustomers, "ID", "Name");
            return View();
        }

        // POST: Admin/CustomerOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AccCustomerID,CreateAtTime")] CustomerOrder customerOrder)
        {
            if (ModelState.IsValid)
            {
                db.CustomerOrders.Add(customerOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccCustomerID = new SelectList(db.AccCustomers, "ID", "Name", customerOrder.AccCustomerID);
            return View(customerOrder);
        }

        // GET: Admin/CustomerOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customerOrder = db.CustomerOrders.Find(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccCustomerID = new SelectList(db.AccCustomers, "ID", "Name", customerOrder.AccCustomerID);
            return View(customerOrder);
        }

        // POST: Admin/CustomerOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AccCustomerID,CreateAtTime")] CustomerOrder customerOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccCustomerID = new SelectList(db.AccCustomers, "ID", "Name", customerOrder.AccCustomerID);
            return View(customerOrder);
        }

        // GET: Admin/CustomerOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customerOrder = db.CustomerOrders.Find(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            return View(customerOrder);
        }

        // POST: Admin/CustomerOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerOrder customerOrder = db.CustomerOrders.Find(id);
            db.CustomerOrders.Remove(customerOrder);
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
