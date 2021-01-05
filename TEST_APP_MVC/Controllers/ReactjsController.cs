using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST_APP_MVC.Models;

namespace TEST_APP_MVC.Controllers
{
    public class ReactjsController : Controller
    {
        // GET: Reactjs
        public ActionResult Index()
        {
            List<Product> p = new List<Product>() {

               new Product { Id = 1, Name = "Pen", Price = 300 },
               new Product { Id = 2, Name = "Pencil", Price = 100 }
            };

            ViewData["MyName"] = "Prathamesh";
            ViewBag.MyLastName = "Powar";
            ViewData["Product"] = p;
            ViewBag.Product = p;

            TempData["name"] = "Bill";

            TempData["Product"] = p;


            //return RedirectToAction("About");

            return View(p);
        }


        public ActionResult About()
        {
            string name;
            if (TempData.ContainsKey("name"))
            {
                name = TempData.Peek("name").ToString(); //TempData["name"].ToString() ;
            }

            return View("About");
            //return RedirectToAction("Contact");
        }

        [HandleError]
        [HandleError(ExceptionType = typeof(DivideByZeroException), View = "~/Views/Errors/DivisibleByZero.cshtml")]
        public ActionResult Contact()
        {
            //string msg = null;
            //ViewBag.Message = msg.Length;
            int a = 0;
            int result = 10 / a;

            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            //Log Error!!

            //Redirect to action
            filterContext.Result = RedirectToAction("", "InternalError");            
            
        }


    }


}