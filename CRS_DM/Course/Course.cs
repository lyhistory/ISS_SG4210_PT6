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
        public string ClassTime { get; set; }
        
        public CourseInstructor Instructor { get; set; }
        public int Duration { get; set; }

        public CourseCategory Category { get; set; }
        public CourseStatus Status { get; set; }

        public bool IsValid()
        {            
            if (Duration< 1 || Duration > 6)
                return false;
            if (Instructor == null)
                return false;
            if (Category == null)
                return false;
            if (string.IsNullOrWhiteSpace(Code))
                return false;

            return true;
        }

        protected List<CourseClass> _CourseClasses = new List<CourseClass>();
        public  List<CourseClass> GetClassList()
        {
            return _CourseClasses;
        }

        public void AddClass(CourseClass cls)
        {
            _CourseClasses.Add(cls);
        }

        public void AddClassList(List<CourseClass> classes)
        {
            _CourseClasses.AddRange(classes);
        }


    }
}
