using nus.iss.crs.dm.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm.Registration
{
    [DataContract]
    public class Registration
    {        
        private RegistrationStatus _Status = RegistrationStatus.Valid;
        private CourseClass _CourseClass;
        private Participant _Participant;

        public Registration()
        { }

        public Registration(CourseClass courseClass, Participant participant)
        {
            _CourseClass = courseClass;
            _Participant = participant;
        }

        public string RegID { get; set; }

        public CourseClass CourseClassObj
        {
            get { return _CourseClass; }
            set { _CourseClass = value; }
        }

        public Participant ParticipantObj
        {
            get { return _Participant; }
            set { _Participant = value; }
        }
        
        public RegistrationStatus Status { get { return _Status; } 
                                           set { _Status = value; } }

        public Billing billingInfo { get; set; }

        public string Sponsorship { get; set; }
        public string DietaryRequirement { get; set; }
        public int OrganizationSize { get; set; }
    }
}
