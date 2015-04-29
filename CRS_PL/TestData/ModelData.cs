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
        private Random r = new Random();

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
            CourseCategory category = new CourseCategory("ABC", "A B C", "1AA BBB CCC");
            categories.Add(category);

            category = new CourseCategory("ABC", "A B C", "AAA BBB CCC");
            categories.Add(category);


            category = new CourseCategory("XYZ", "X Y Z", "XXX YYY ZZZ");
            categories.Add(category);


            category = new CourseCategory("MN", "M N", "MM NN");
            categories.Add(category);


            category = new CourseCategory("OPQ", "O P Q", "OOO PPP QQQ");
            categories.Add(category);

            Course course = new Course();

            return categories;
        }

        public List<CourseCategory> CreateCategoryList()
        {
            List<CourseCategory> categories = new List<CourseCategory>();

            int x = r.Next(1,5);
            categories.Add(CreateCategory("category " + x, "Name " +x, "Description " + x));

            x = r.Next(6,10);
            categories.Add(CreateCategory("Software " + x, "Software Engineering " + x, "Software Engineering " + x));

            x = r.Next(11, 15);
            categories.Add(CreateCategory("Bussiness " + x, "Bussiness Development " + x, "Bussiness Development " + x));

            x = r.Next(16, 20);
            categories.Add(CreateCategory("MBA " + x, "MBA " + x, "MBA " + x));


            return categories;
        }

        public CourseCategory CreateCategory(string ID,string name,string description)
        {
            CourseCategory category = new CourseCategory(ID, name, description);

            category.AddCourse(CreateCourse(category, "code1", "title1", "desc1", 3, "1000"));
            category.AddCourse(CreateCourse(category, "code2", "title2", "desc2", 5, "1000"));
            category.AddCourse(CreateCourse(category, "code3", "title3", "desc3", 5, "1000"));
            category.AddCourse(CreateCourse(category, "code4", "title4", "desc4", 5, "1000"));

            return category;
        }

        public Course CreateCourse(CourseCategory category,
            string code, string title, string desc, int duration,string fee)
        {
            Course course = new Course();
            course.Category = category;
            course.Code = code;
            course.CourseTitle = title;
            course.Description = desc;
            course.Duration = duration;
            course.Fee = fee;

            CourseInstructor instructor = GetInstructors()[r.Next(3)];
            course.Instructor =instructor;
            return course;
        }
    }
}
