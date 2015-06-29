using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Web.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult About()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session["email"] = null;

            return RedirectToAction("LogOn", "Account");
          
        }
    }
}