using celebro.Models;
using celebro.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace celebro.Controllers
{
    public class HomeController : Controller
    {
        private readonly CelebroContext db = new CelebroContext();
        public ActionResult Index()
        {
            Vwcelebrities model = new Vwcelebrities();
            model.Celebrities = db.Celebrities.OrderByDescending(p => p.Price).Take(16).ToList();
            model.Categories = db.Categories.ToList();
            ViewBag.Categories = db.Categories.ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,Fullname,CategoryID,Mail,Socialmedia,Phone,Price")] Celebrity celebrity)
        {

            if (ModelState.IsValid)
            {
                int catidi =Convert.ToInt32( Request.Form["CategoryID"]);
                //int catidi = db.Categories.FirstOrDefault(d => d.Name == strDDLValue).Id;
                db.Celebrities.Add(celebrity);
                celebrity.CategoryID = catidi;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = db.Categories.ToList();

            return View(celebrity);
        }


        public JsonResult Getcelebrities(int catid)
        {
            List<Celebrity> model = new List<Celebrity>();

            if (catid == 0)
            {
                 model = db.Celebrities.Include("Category").OrderByDescending(p=>p.Price).Take(16).ToList();

            }
            else
            {
                model = db.Celebrities.Include("Category").Where(c => c.CategoryID == catid).ToList();

            }
            return Json(model.Select(m=>new {
                m.Fullname,
                m.Category.Name,
                m.Price,
                m.Photo
            }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Getcelebritieswithinput(string text)
        {
            List<Celebrity> model = new List<Celebrity>();
            model = db.Celebrities.Include("Category").Where(c => c.Fullname.Contains(text) || c.Category.Name.Contains(text)).ToList();

            return Json(model.Select(m => new {
                m.Fullname,
                m.Category.Name,
                m.Price,
                m.Photo
            }), JsonRequestBehavior.AllowGet);
        }

        
    }
}