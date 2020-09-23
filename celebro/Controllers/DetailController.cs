using celebro.Models;
using celebro.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace celebro.Controllers
{
    public class DetailController : Controller
    {
        private readonly CelebroContext db = new CelebroContext();

        // GET: Detail
        public ActionResult Index(int id)
        {
            Vwdetail model = new Vwdetail();
            int catid = db.Celebrities.FirstOrDefault(c => c.Id == id).CategoryID;
            model.Celebrities = db.Celebrities.Where(c => c.CategoryID == catid).ToList();
            model.catname=db.Categories.FirstOrDefault(f=>f.Id==catid).Name;

            model.Orders = db.Orders.Where(c => c.CelebrityID == id).ToList();
            ViewBag.Categories = db.Categories.ToList();

            return View(model);
        }
       
    }
}