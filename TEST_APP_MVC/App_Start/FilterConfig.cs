using System.Web;
using System.Web.Mvc;
using TEST_APP_MVC.Models;

namespace TEST_APP_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LogCustomExceptionFilter());
        }
    }

}
