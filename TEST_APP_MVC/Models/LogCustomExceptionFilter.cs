using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TEST_APP_MVC.Models
{
    public class LogCustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var exceptionMessage = filterContext.Exception.Message;
            var stackTrace = filterContext.Exception.StackTrace;

            var controller = filterContext.RouteData.Values["controller"].ToString();
            var actionName = filterContext.RouteData.Values["action"].ToString();

            string Message = $"Data{DateTime.Now.ToString()} , Controller: {controller}, Action: {actionName }, Error Message: {exceptionMessage} {Environment.NewLine}, Stack Trace: {stackTrace}";

            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Log/Log.txt"), Message);

            filterContext.ExceptionHandled = true;

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };


        }
    }
}