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
        CourseManager crsManager = new CourseManager();
        public User login(LogingStrategy strategy)
        {
            return loginManager.Login(strategy);
        }

        public bool RegistrateCourse(dm.Registration.Registration registration, string companyName, string participantID, string courseCode, DateTime dateFrom, DateTime dateTo)
        {
            CourseRegistrationManager regManager = new CourseRegistrationManager();
            
            Course course = crsManager.GetCourseByCode(courseCode);
            CourseClass courseClass = crsManager.GetCourseClassList(course, dateFrom, dateTo).FirstOrDefault();
            ParticipantManager pManager = new ParticipantManager();

            //Participant p = new Participant ();
            //p.
            //regManager.CreateParticipant 
            //pManager.CreateParticipantByHR()
            Participant participant = pManager.GetParticipant(participantID, companyName);

            Registration retReg = regManager.CreateRegistration(courseClass, participant, registration);

                if (retReg == null || string.IsNullOrEmpty(retReg.RegID))
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        public string SubmitAttendance(string studentIDNo, AttendanceStatus status, string remark, string courseCode, DateTime dateFrom, DateTime dateTo)
        {
            AttendanceManager manager = new AttendanceManager();

            ParticipantAttendance pAttendance = new ParticipantAttendance ();

            pAttendance.Attendant = null;
            pAttendance.ClassDate = DateTime.Now;
            pAttendance.CourseObj = null;
            pAttendance.Remark = remark;
            pAttendance.Status = status;
            
            if (manager.SaveParticipantAttendance(pAttendance))
            {
                return "success";
            }
            else
            {
                return "failed";
            }
        }

        public List<Participant> GetStudents(string courseCode, DateTime dateFrom, DateTime dateTo)
        {
            CourseRegistrationManager manager = new CourseRegistrationManager();
            
            Course course = crsManager.GetCourseByCode(courseCode);

            return manager.GetParticipantListByCourse(course, dateFrom);
        }


        List<CourseCategory> categories = null;
        public List<Course> GetCourses(DateTime dateFrom, DateTime dateTo)
        {
           categories =  crsManager.GetCourseCategoryList();
            CourseCategory category = categories[0];
            return crsManager.GetCourseListByCategory(category);
        }


        public List<Participant> GetEmployees(string companyName)
        {
            return null;
        }
    }
}
