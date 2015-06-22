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
        { billingInfo = new Billing();}

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

        [DataMember]
        public RegistrationStatus Status { get { return _Status; } 
                                           set { _Status = value; } }


        [DataMember]
        public Billing billingInfo { get; set; }

        [DataMember]
        public string Sponsorship { get; set; }

        [DataMember]
        public string DietaryRequirement { get; set; }
        
        [DataMember]
        public string OrganizationSize { get; set; }
    }
}
