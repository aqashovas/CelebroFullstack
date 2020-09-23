using celebro.Models;
using celebro.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace celebro.Controllers
{
    public class SayusController : Controller
    {
        private readonly CelebroContext db = new CelebroContext();
        // GET: Sayus
        public ActionResult Index()
        {
            Vwsuggestion model = new Vwsuggestion();
            ViewBag.Categories = db.Categories.ToList();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,FullName,Mail,Phone,Text")] Suggestion suggestion)
        {
            if (ModelState.IsValid)
            {
                db.Suggestions.Add(suggestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suggestion);
        }
    }
}