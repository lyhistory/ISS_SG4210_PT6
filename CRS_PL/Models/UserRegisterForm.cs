using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace nus.iss.crs.pl.Models
{
    public class UserRegisterForm
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string LoginID { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "password not the same!")]
        public string ConfirmPassword { get; set; }
        public string UserType { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }
        [Required]
        public string  JobTitle{ get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string FaxNumber { get; set; }

        [Required]
        public string CompanyName{get;set;}
        [Required]
        public string CompanyUEN{get;set;}
        [Required]
        public string OrganizationSize;
        [Required]
        public string CompanyAddress;
        [Required]
        public string Country{get;set;}
        [Required]
        public string PostalCode { get; set; }
        
    }
}