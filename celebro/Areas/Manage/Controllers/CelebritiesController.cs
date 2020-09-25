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
    public class CelebritiesController : Controller
    {
        private CelebroContext db = new CelebroContext();

        // GET: Manage/Celebrities
        public ActionResult Index()
        {
            var celebrities = db.Celebrities.Include(c => c.Category);
            return View(celebrities.ToList());
        }

        // GET: Manage/Celebrities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celebrity celebrity = db.Celebrities.Find(id);
            if (celebrity == null)
            {
                return HttpNotFound();
            }
            return View(celebrity);
        }

        // GET: Manage/Celebrities/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Manage/Celebrities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fullname,Price,Mail,Phone,Socialmedia,Photo,CategoryID")] Celebrity celebrity)
        {
            if (ModelState.IsValid)
            {
                db.Celebrities.Add(celebrity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", celebrity.CategoryID);
            return View(celebrity);
        }

        // GET: Manage/Celebrities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celebrity celebrity = db.Celebrities.Find(id);
            if (celebrity == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", celebrity.CategoryID);
            return View(celebrity);
        }

        // POST: Manage/Celebrities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fullname,Price,Mail,Phone,Socialmedia,Photo,CategoryID")] Celebrity celebrity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(celebrity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", celebrity.CategoryID);
            return View(celebrity);
        }

        // GET: Manage/Celebrities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celebrity celebrity = db.Celebrities.Find(id);
            if (celebrity == null)
            {
                return HttpNotFound();
            }
            return View(celebrity);
        }

        // POST: Manage/Celebrities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Celebrity celebrity = db.Celebrities.Find(id);
            db.Celebrities.Remove(celebrity);
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
