using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm.Course
{
    public class Course
    {
        public string Code { get; set; }
        public string CourseTitle { get; set; }
        public string Description { get; set; }
        public string Fee { get; set; }
        public Instructor instructor { get; set; }
        public int Duration { get; set; }

        public Category category { get; set; }

    }
}
