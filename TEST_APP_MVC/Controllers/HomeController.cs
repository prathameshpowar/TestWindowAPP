using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST_APP_MVC.Models;
using TEST_APP_MVC.EntityFramework;
using System.Web.Security;

namespace TEST_APP_MVC.Controllers
{
   
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            try
            {
                object o = 0;
                o = "string";

                int[] s = { 1, 2, 3, 4 };


            }
            finally
            {

            }


            return View();
        }


        public ActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            NetCoreEntities netCoreEntities = new NetCoreEntities();

            int? userID = netCoreEntities.Validate_Users(user.UserName.ToString(), user.UserPassword).FirstOrDefault();

            string message = string.Empty;

            switch (userID.Value)
            {
                case -1:
                    message = "Username and/or password is incorrect.";
                    break;
                case -2:
                    message = "Account has not been activated.";
                    break;
                default:
                    FormsAuthentication.SetAuthCookie(user.UserID.ToString(), true);
                    return RedirectToAction("Profile");
            }

            ViewBag.Message = message;

            return View(user);

        }


        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        [CustomAuthenticationFilter]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ShowPartialView()
        {
            ViewBag.Message = "Your contact page.";

            return PartialView("_PartialView");
        }

    }
}