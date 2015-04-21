using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm.crs.iss.nus.Course
{
    public class CourseClass
    {
        private Course course;
         
        public CourseClass(Course course)
        {
            this.course = course;
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
