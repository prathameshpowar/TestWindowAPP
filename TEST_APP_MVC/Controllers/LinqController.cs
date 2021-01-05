using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST_APP_MVC.Models;

namespace TEST_APP_MVC.Controllers
{
    public class LinqController : Controller
    {
        // GET: Linq
        public ActionResult Index()
        {




            DataContext dc = new DataContext("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SchoolDB;Data Source=DESKTOP-KQSP501");

            var x = dc.GetTable<Student>().ToList();

            //select data of all the candidates whose statndardid is greater than 5
            var y = dc.GetTable<Student>().Where(m => m.StandardId > 5);

            foreach (var item in y)
            {
                Debug.WriteLine(item.StudentName);
            }

            //Select data of whose name is start with "M"
            IEnumerable<Student> Mname = dc.GetTable<Student>().Where(p => p.StudentName.StartsWith("M"));
            foreach (var item in Mname)
            {
                Debug.WriteLine(item.StudentName);
            }

            //Insert Into database using Linq

            Student student = new Student()
            {
                StudentID = 1,
                StudentName = "Prathamesh",
                StandardId = 1
            };

            dc.GetTable<Student>().InsertOnSubmit(student);
            dc.SubmitChanges();

            //Delete data from Database

            Student students = dc.GetTable<Student>().Single(xx => xx.StudentID == 14);
            dc.GetTable<Student>().DeleteOnSubmit(students);

            try
            {
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            

            return View();
        }
    }
}