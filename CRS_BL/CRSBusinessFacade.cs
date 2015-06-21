using nus.iss.crs.dm;
using nus.iss.crs.dm.Course;
using nus.iss.crs.dm.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    public class CRSBusinessFacade : ICRSBusinessFacade
    {
        LoginManager loginManager = new LoginManager();
        public User login(LogingStrategy strategy)
        {
            return loginManager.Login(strategy);
        }

        public bool RegistrateCourse(dm.Registration.Registration registration, string companyName, string participantID, string courseCode, DateTime dateFrom, DateTime dateTo)
        {
            CourseRegistrationManager regManager = new CourseRegistrationManager();
            CourseManager crsManager = new CourseManager();
            Course course = CourseManager.GetCourseByCode(courseCode);
            CourseClass courseClass = CourseManager.GetCourseClassList(course, dateFrom, dateTo).FirstOrDefault();
            ParticipantManager pManager = new ParticipantManager();
            Participant participant = pManager.GetParticipant(participantID, companyName);
            Registration retReg = regManager.CreateRegistration(courseClass, participant, registration);
            if (string.IsNullOrEmpty(retReg.RegID))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
