using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace nus.iss.crs.pl.Models
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        [Compare("NewPassword", ErrorMessage = "Please confirm new password")]
        public string ConfirmNewPassword { get; set; }
    }
}