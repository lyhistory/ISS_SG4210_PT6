using nus.iss.crs.bl;
using nus.iss.crs.dm.Course;
using nus.iss.crs.dm.Registration;
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

        ICRSBusinessFacade facadeObj = new CRSBusinessFacade();
         
        public void RegistrateCourse(dm.Registration.Registration reg,string companyName, string participantIDNumber,string courseCode,DateTime dateFrom,DateTime dateTo)
        {
            facadeObj.RegistrateCourse(reg,companyName, participantIDNumber, courseCode, dateFrom, dateTo);
        }

        public List<Course> GetCourses(DateTime dateFrom, DateTime dateTo)
        {
            return facadeObj.GetCourses(dateFrom, dateTo);
        }

        public List<Participant> GetEmployees(string companyName)
        {
            return facadeObj.GetEmployees(companyName);
        }
    }
}
