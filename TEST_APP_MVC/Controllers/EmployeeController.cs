using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST_APP_MVC.Models;

namespace TEST_APP_MVC.Controllers
{
    [LogFilter]
    public class EmployeeController : Controller
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee(){ EmployeeID=101,EmployeeName="Prathamesh"},
            new Employee(){ EmployeeID=102,EmployeeName="Soniya"},
            new Employee(){ EmployeeID=103,EmployeeName="Hirabai"},
            new Employee(){ EmployeeID=104,EmployeeName="Ramchandra"},
            new Employee(){ EmployeeID=105,EmployeeName="Rhea"}
        };

        // GET: Employee
        public ActionResult GetAllEmployee()
        {
            return View(employees);
        }

        public ActionResult GetEmployeeByID(int employeeID)
        {
            Employee employee = employees.FirstOrDefault(s => s.EmployeeID == employeeID);
            return View(employee);
        }

        [Route("Employee/{employeeID}/Course")]
        public ActionResult GetEmployeeCourse(int employeeID)
        {
            List<string> CourseList = new List<string>();

            if (employeeID == 1)
                CourseList = new List<string> { "ASP.NET", "C#.NET", "SQL Server" };
            else if (employeeID == 2)
                CourseList = new List<string> { "ASP.NET MVC", "C#.NET", "ADO.NET" };
            else if (employeeID == 3)
                CourseList = new List<string>() { "ASP.NET WEB API", "C#.NET", "Entity Framework" };
            else
                CourseList = new List<string>() { "Bootstrap", "jQuery", "AngularJs" };

            ViewBag.CourseList = CourseList;

            Session["CourseList"] = CourseList;

            return View();

        }

        public ActionResult Index()
        {
            throw new Exception("Something went wrong");
            //return View();
        }
    }
}