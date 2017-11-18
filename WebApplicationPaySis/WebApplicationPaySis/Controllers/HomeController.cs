using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationPaySis.Models;

namespace WebApplicationPaySis.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(USERSEntities objUser)
        {
            if (ModelState.IsValid)
            {
                using (PaysisEntities db = new PaysisEntities())
                {
                    var obj = db.USERSEntities.Where(a => a.USERNAME.Equals(objUser.USERNAME) && a.PASSWORD.Equals(objUser.PASSWORD)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.ID_USER.ToString();
                        Session["UserName"] = obj.USERNAME.ToString();
                        return RedirectToAction("UserOptions");
                    }
                    else
                    {
                        ViewBag.Message = "User/password invald";
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserOptions()
        {
            if (Session["UserID"] != null)
            {
                //return View();
                return RedirectToAction("../TRANSACTIONSEntities/index");
            }
            else
            {
                return RedirectToAction("..Login");
            }
        }
    }
}