using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace nus.iss.crs.pl.Models
{
    public class CourseAdminViewModel
    {
        public string StaffID { get; set; }
        [Required]
        public string LoginID { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password not the same")]
        public string ConfirmPassword { get; set; }

        public int Enabled { get; set; }
        public int Status { get; set; }
    }
}