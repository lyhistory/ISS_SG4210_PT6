using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm.Registration
{
    [DataContract]
    public class Participant
    {
        public Participant()
        {
 
        }
        public Participant(User user)
        {
 
        }

        [DataMember]
        public string ParticipantID { get; set; }

        [DataMember]
        public string IDNumber { get; set; }

        [DataMember]
        public string EmploymentStatus { get; set; }

        [DataMember]
        public string CompanyID { get; set; }

        [DataMember]
        public string CompanyName { get; set; }
        
        public string Salutation { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string OrganizationSize { get; set; }

        [DataMember]
        public string Gender { get; set; }
        public string SalaryRange { get; set; }

        [DataMember]
        public string Nationality { get; set; }
        public DateTime DOB { get; set; }

        [DataMember]
        public string EMail { get; set; }

        [DataMember]
        public string ContactNumber { get; set; }

        [DataMember]
        public string DietaryRequirement { get; set; }
    }
}
