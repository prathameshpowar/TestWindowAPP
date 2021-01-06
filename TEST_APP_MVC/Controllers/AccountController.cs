using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST_APP_MVC.Models;

namespace TEST_APP_MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            List<string> abc = new List<string>();
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                if (login.UserName == "admin" && login.Password == "admin")
                {
                    Session["UserName"] = login.UserName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User name Or Password");
                    return View(login);
                }
            }
            else
            {
                return View(login);
            }
        }
    }
}