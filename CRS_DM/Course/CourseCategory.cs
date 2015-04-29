using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm.Course
{
    public class CourseCategory
    {
        protected List<Course> courseList = new List<Course>();

        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public CourseCategory(string ID, string categoryName, string categoryDescrition)
        {
            this.ID = ID;
            this.Name = categoryName;
            this.Description = categoryDescrition; 
        }

        public virtual List<Course> GetCourses()
        {
            return courseList;
        }

        public void AddCourse(Course course)
        {
            courseList.Add(course);
        }
    }
}
