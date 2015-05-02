using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm.Registration
{
    public class Participant
    {
        public Participant()
        {
 
        }
        public Participant(User user)
        {
 
        }

        public string IDNo { get; set; }
        public string EmploymentStatus { get; set; }
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Salutation { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string FullName { get; set; }
        public string OrganizationSize { get; set; }
        public string Gender { get; set; }
        public string SalaryRange { get; set; }
        public string Nationality { get; set; }
        public DateTime DOB { get; set; }
        public string EMail { get; set; }
        public string ContactNumber { get; set; }
        public string DietaryRequirement { get; set; }
    }
}
