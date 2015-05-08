using CRS_DAL.Repository;
using nus.iss.crs.dm.Course;
using nus.iss.crs.dm.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    class ClassManager
    {
        static UnitOfWork unitOfWork = new UnitOfWork();

        internal ClassManager() { }
        internal ClassManager(ISession session) 
        {
            if (session.GetCurrentUser().GetRole() == null) 
            {
                throw new Exception("No permission.");
            }
        }

        public bool CreateCourseClass(CourseClass courseClass)
        {
            if (courseClass.GetCourse() != null)
            {
                return unitOfWork.ClassService.CreateCourseClass(courseClass);
            }
            return false;
        }

        public bool CloseCourseClass(CourseClass courseClass)
        {
            courseClass.Status = ClassStatus.Close;
            return unitOfWork.ClassService.ChangeCourseClassStatus(courseClass);
        }

        public bool ConfirmCourseClass(CourseClass courseClass)
        {
            courseClass.Status = ClassStatus.Confirmed;
            return unitOfWork.ClassService.ChangeCourseClassStatus(courseClass);
        }

        public bool CancelCourseClass(CourseClass courseClass)
        {
            courseClass.Status = ClassStatus.Canceled;
            return unitOfWork.ClassService.ChangeCourseClassStatus(courseClass);
        }

        public bool AdjustCourseClassSchedule(CourseClass courseClass,DateTime startDate,DateTime endDate)
        {
            return unitOfWork.ClassService.EditCourseClassDate(courseClass, startDate, endDate);
        }

        public CourseClass GetCourseClassByCode(string classCode)
        {
            return unitOfWork.ClassService.GetCourseClassByCode(classCode);
        }

        public List<Participant> GetCourseClassParticipantList(CourseClass courseClass)
        {
            return unitOfWork.ClassService.GetCourseClassParticipantList(courseClass);
        }
    }
}
