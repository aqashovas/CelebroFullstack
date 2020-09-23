using celebro.Models;
using celebro.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace celebro.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly CelebroContext db = new CelebroContext();

        // GET: Questions
        public ActionResult Index()
        {
            Vwform1 model = new Vwform1();
            ViewBag.Categories = db.Categories.ToList();

            return View(model);
        }
    }
}