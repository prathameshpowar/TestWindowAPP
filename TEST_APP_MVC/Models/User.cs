using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEST_APP_MVC.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage ="Required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Required.")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Required.")]
        [Compare("UserPassword", ErrorMessage ="Password do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Required.")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string UserEmailID { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public Nullable<System.DateTime> LastLoginDate { get; set; }

        public bool RememberMe { get; set; }

    }
}