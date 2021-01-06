using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEST_APP_MVC.Models
{
    public class LoginModel
    {
        [DisplayName("User Name")]
        [Required(ErrorMessage = "User Name required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password required")]
        [Compare(otherProperty: "UserName", ErrorMessage = "Password Mismatch")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}