using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace nus.iss.crs.pl.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CourseRegistrationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CourseRegistrationService.svc or CourseRegistrationService.svc.cs at the Solution Explorer and start debugging.
    public class CourseRegistrationService : ICourseRegistrationService
    { 

        public void DoWork()
        {
            Console.WriteLine("Do work");
        }

        public void RegistrateCourse(dm.Registration.Registration reg)
        {
            Console.WriteLine("DietaryRequirement:" + reg.DietaryRequirement);
        }
    }
}
