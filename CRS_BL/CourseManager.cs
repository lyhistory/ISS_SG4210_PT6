using nus.iss.crs.dm.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    public class CourseManager
    {
        internal CourseManager()
        {}

        internal CourseManager(ISession session)
        {
            //only course admin can do  
            if (session.GetCurrentUser().GetRole() == null)
            {
                throw new Exception("No permisison");
            }
        }

        public Course CreateCourse()
        {
            Course course = new Course();
            //course.
            return course;
        }

        public bool SaveCourse(Course course)
        {
        //call dal to save
            return true;
        }

    }
}
