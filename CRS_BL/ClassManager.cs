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
        internal ClassManager() { }
        internal ClassManager(ISession session) 
        {
            if (session.GetCurrentUser().GetRole() == null) 
            {
                throw new Exception("No permission.");
            }
        }

        public CourseClass CreateCourseClass(Course course)
        {
            CourseClass courseClass = new CourseClass(course);
            return courseClass;
        }

        public bool CloseCourseClass(CourseClass courseClass)
        {
            return false;
        }

        public bool ConfirmCourseClass(CourseClass courseClass)
        {
            return false;
        }

        public bool CancelCourseClass(CourseClass courseClass)
        {
            return false;
        }

        public bool AdjustCourseClassSchedule(DateTime startDate)
        {   

            return false;
        }

        public bool GetCourseClassStatus(CourseClass courseClass)
        {
            return false;
        }

        public List<Participant> GetCourseClassParticipantList(CourseClass courseClass)
        {
            List<Participant> participantList = new List<Participant>();
            return participantList;
        }
    }
}
