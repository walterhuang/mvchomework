using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcHomework.Models;

namespace MvcHomework.Controllers
{
    public class OrderLineController : Controller
    {
        private FabricsEntities db = new FabricsEntities();

        // GET: /OrderLine/
        public ActionResult Index()
        {
            var orderlines = db.OrderLines.Include(o => o.Order).Include(o => o.Product);
            return View(orderlines.ToList());
        }

        // GET: /OrderLine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderline = db.OrderLines.Find(id);
            if (orderline == null)
            {
                return HttpNotFound();
            }
            return View(orderline);
        }

        // GET: /OrderLine/Create
        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderStatus");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: /OrderLine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="OrderId,LineNumber,ProductId,Qty,LineTotal")] OrderLine orderline)
        {
            if (ModelState.IsValid)
            {
                db.OrderLines.Add(orderline);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderStatus", orderline.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", orderline.ProductId);
            return View(orderline);
        }

        // GET: /OrderLine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderline = db.OrderLines.Find(id);
            if (orderline == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderStatus", orderline.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", orderline.ProductId);
            return View(orderline);
        }

        // POST: /OrderLine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="OrderId,LineNumber,ProductId,Qty,LineTotal")] OrderLine orderline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderStatus", orderline.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", orderline.ProductId);
            return View(orderline);
        }

        // GET: /OrderLine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderline = db.OrderLines.Find(id);
            if (orderline == null)
            {
                return HttpNotFound();
            }
            return View(orderline);
        }

        // POST: /OrderLine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderLine orderline = db.OrderLines.Find(id);
            db.OrderLines.Remove(orderline);
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
