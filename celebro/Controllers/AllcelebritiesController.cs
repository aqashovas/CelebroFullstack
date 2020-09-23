using celebro.Models;
using celebro.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace celebro.Controllers
{
    public class AllcelebritiesController : Controller
    {
        private readonly CelebroContext db = new CelebroContext();

        // GET: Allcelebrities
        public ActionResult Index()
        {
            Vwcelebrities model = new Vwcelebrities();
            model.Celebrities = db.Celebrities.ToList();
            model.Categories = db.Categories.ToList();
            ViewBag.Categories = db.Categories.ToList();

            return View(model);
        }
        
    }
}