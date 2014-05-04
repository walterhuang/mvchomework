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
    public class OccupationController : Controller
    {
        private FabricsEntities db = new FabricsEntities();

        // GET: /Occupation/
        public ActionResult Index()
        {
            return View(db.Occupations.ToList());
        }

        // GET: /Occupation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occupation occupation = db.Occupations.Find(id);
            if (occupation == null)
            {
                return HttpNotFound();
            }
            return View(occupation);
        }

        // GET: /Occupation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Occupation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="OccupationId,OccupationName")] Occupation occupation)
        {
            if (ModelState.IsValid)
            {
                db.Occupations.Add(occupation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(occupation);
        }

        // GET: /Occupation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occupation occupation = db.Occupations.Find(id);
            if (occupation == null)
            {
                return HttpNotFound();
            }
            return View(occupation);
        }

        // POST: /Occupation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="OccupationId,OccupationName")] Occupation occupation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(occupation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(occupation);
        }

        // GET: /Occupation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occupation occupation = db.Occupations.Find(id);
            if (occupation == null)
            {
                return HttpNotFound();
            }
            return View(occupation);
        }

        // POST: /Occupation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Occupation occupation = db.Occupations.Find(id);
            db.Occupations.Remove(occupation);
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
