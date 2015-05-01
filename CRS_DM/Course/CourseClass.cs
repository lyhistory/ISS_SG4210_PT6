using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm.Course
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

        public ClassStatus Status { get; set; }
    }
}
