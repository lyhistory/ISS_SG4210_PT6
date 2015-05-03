using nus.iss.crs.dm.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm.Registration
{
    public class Registration
    {
        private string RegID;

        private RegistrationStatus status = RegistrationStatus.Valid;

        private CourseClass cls;
        private Participant participant;

        public Registration()
        { }

        public Registration(CourseClass courseClass, Participant participant)
        { }

        public Billing billingInfo { get; set; }

        public string Sponsorship { get; set; }
        public string DietaryRequirement { get; set; }

    }
}
