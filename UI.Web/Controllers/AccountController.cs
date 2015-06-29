using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web.Services;
using UI.Web.ViewModels;

namespace UI.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogOn()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LogOn(LogOnViewModel lg)
        {
            string email = lg.Email;
            string password = lg.Password;

            if (LogOnService.CanLogin(email, password))
            {
                Session["email"] = email;
                return RedirectToAction("Wall", "Comments");
            }
            return View();
        }
    }
}