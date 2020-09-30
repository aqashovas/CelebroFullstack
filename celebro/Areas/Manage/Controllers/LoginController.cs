using celebro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace celebro.Areas.Manage.Controllers
{
    public class LoginController : Controller
    {
        private readonly CelebroContext db = new CelebroContext();

        // GET: Manage/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            if (ModelState.IsValid)
            {
                Admin adm = db.Admins.FirstOrDefault(a => a.Username == admin.Username && a.AdminCatId==1);

                if (adm != null)
                {
                    if (Crypto.VerifyHashedPassword(adm.Password, admin.Password))
                    {
                        Session["login"] = true;
                        Session["UserId"] = adm.Id;
                        return RedirectToAction("index", "dashboard");
                    }
                }

                ModelState.AddModelError("summary", "Email or password incorret");
            }

            return View(admin);

        }
        public ActionResult Createpass()
        {
            string a = Crypto.HashPassword("123");
            return Content(a);
        }
        public ActionResult Logout()
        {
            Session.Remove("login");
            Session.Remove("UserId");

            return RedirectToAction("index");
        }
    }
   
}