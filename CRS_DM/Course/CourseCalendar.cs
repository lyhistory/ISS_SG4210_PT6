using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm.crs.iss.nus.Course
{
    public class CourseCalendar
    {
        private List<CourseClass> courseClass;
        public DateTime date { get; set; }

        public bool isHoliday()
        {
            throw new NotImplementedException();
        }
    }
}
