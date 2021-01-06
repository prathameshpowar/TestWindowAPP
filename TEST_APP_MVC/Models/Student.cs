using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;


namespace TEST_APP_MVC.Models
{
    [Table]
    public class Student
    {
        [Column(Name = "StudentID",IsPrimaryKey =true,IsDbGenerated =true)]
        public int StudentID { get; set; }

        [Column(Name = "StudentName")]
        public string StudentName { get; set; }

        [Column(Name = "StandardId")]
        public int? StandardId { get; set; }

        [Column(Name = "RowVersion")]
        public dynamic RowVersion { get; set; }

    }
}