using dm.crs.iss.nus.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm.crs.iss.nus.Registration
{
    public class Registration
    {
        public Registration(CourseClass courseClass, Participant participant)
        { }

        public Bill billingInfo { get; set; }

        public string Sponsorship { get; set; }
        public string DietaryRequirement { get; set; }

    }
}
