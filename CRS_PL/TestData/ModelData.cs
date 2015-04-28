using nus.iss.crs.dm;
using nus.iss.crs.dm.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.pl.TestData
{
    public class ModelData
    {
        public List<CourseInstructor> GetInstructors()
        {
            List<CourseInstructor> instructors = new List<CourseInstructor>();

            CourseInstructor instructor = new CourseInstructor("Super Hero");
            instructors.Add(instructor);

            instructor = new CourseInstructor("Super Man");
            instructors.Add(instructor);

            instructor = new CourseInstructor("Green Man");
            instructors.Add(instructor);

            instructor = new CourseInstructor("Iron Man");
            instructors.Add(instructor);

            return instructors;
        }

        public List<CourseCategory> GetCategories()
        {
            List<CourseCategory> categories = new List<CourseCategory>();
            CourseCategory category = new CourseCategory("ABC", "A B C", "AAA BBB CCC");
            categories.Add(category);

            category = new CourseCategory("ABC", "A B C", "AAA BBB CCC");
            categories.Add(category);


            category = new CourseCategory("XYZ", "X Y Z", "XXX YYY ZZZ");
            categories.Add(category);


            category = new CourseCategory("MN", "M N", "MM NN");
            categories.Add(category);


            category = new CourseCategory("OPQ", "O P Q", "OOO PPP QQQ");
            categories.Add(category);

            return categories;
        }
    }
}
