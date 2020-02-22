using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverflowProject.ViewModels;
using StackOverflowProject.ServiceLayer;

namespace StackOverflowProject.Controllers
{
    public class AccountController : Controller
    {
        IuserService us;

        public AccountController(IuserService us)
        {
            this.us = us;
        }
        public ActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                int uid = this.us.InsertUser(rvm);
                Session["CurrentUserID"] = uid;
                Session["CurrentUserName"] = rvm.Name;
                Session["CurrentUserEmail"] = rvm.Email;
                Session["CurrentUserPassword"] = rvm.Password;
                Session["CurrentUserIsAdmin"] = false;
                return RedirectToAction("index", "Home");
            }
            else
            {
                ModelState.AddModelError("X", "Invalid data");
                return View();
            }
        }
    }
}