using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using celebro.Models;

namespace celebro.Areas.Manage.Controllers
{
    [Auth]
    public class AdmincatsController : Controller
    {
        private CelebroContext db = new CelebroContext();

        // GET: Manage/Admincats
        public ActionResult Index()
        {
            return View(db.Admincats.ToList());
        }

        // GET: Manage/Admincats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admincat admincat = db.Admincats.Find(id);
            if (admincat == null)
            {
                return HttpNotFound();
            }
            return View(admincat);
        }

        // GET: Manage/Admincats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Admincats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Admincat admincat)
        {
            if (ModelState.IsValid)
            {
                db.Admincats.Add(admincat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admincat);
        }

        // GET: Manage/Admincats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admincat admincat = db.Admincats.Find(id);
            if (admincat == null)
            {
                return HttpNotFound();
            }
            return View(admincat);
        }

        // POST: Manage/Admincats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Admincat admincat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admincat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admincat);
        }

        // GET: Manage/Admincats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admincat admincat = db.Admincats.Find(id);
            if (admincat == null)
            {
                return HttpNotFound();
            }
            return View(admincat);
        }

        // POST: Manage/Admincats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admincat admincat = db.Admincats.Find(id);
            db.Admincats.Remove(admincat);
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
