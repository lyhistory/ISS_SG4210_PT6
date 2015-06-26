using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace nus.iss.crs.pl.Models
{

    public class CRForm
    {
        /// <summary>
        /// Course Class
        /// </summary>
        public string CourseTitle { get; set; }
        public string CourseCode { get; set; }
        public string ClassCode { get; set; }

        //Participant
        [Required(ErrorMessage = "Name is Requirde")]
        public string IDNumber { get; set; }
        [Required]
        public int IsLocal { get; set; }
        public string CompanyID { get; set; }
        [Required]
        public string Salutation { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }
        public string DietaryRequirement { get; set; }

        public string EmploymentStatus { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        
        public string OrganizationSize { get; set; }
        public string SalaryRage { get; set; }

        //Registration
        public string Sponsorship { get; set; }
        [Required]
        public string BillingAddress { get; set; }
        [Required]
        public string BillingPersonName { get; set; }
        [Required]
        public string BillingAddressCountry { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string BillingAddressPostalCode { get; set; }
    }
}
