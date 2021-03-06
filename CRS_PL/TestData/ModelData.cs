﻿using nus.iss.crs.dm;
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
        private List<CourseCategory> categories = new List<CourseCategory>();
        private List<Course> courses = new List<Course>();

        private static ModelData instance = null;
        private ModelData()
        { }

        public static ModelData GetInstance()
        {
            if (instance == null)
                instance = new ModelData();
            return instance;
        } 

        public List<CourseInstructor> GetInstructors()
        {
            List<CourseInstructor> instructors = new List<CourseInstructor>();

            //CourseInstructor instructor = new CourseInstructor("1","Super Hero");
            //instructors.Add(instructor);

            //instructor = new CourseInstructor("2","Super Man");
            //instructors.Add(instructor);

            //instructor = new CourseInstructor("3","Green Man");
            //instructors.Add(instructor);

            //instructor = new CourseInstructor("4","Iron Man");
            //instructors.Add(instructor);

            return instructors;
        }

        public List<CourseCategory> GetCategories()
        {
            if (categories != null && categories.Count > 0)
                return categories;

            categories = CreateCategoryList();

            AddCourse4Categories();

            return categories;
        }

        public CourseCategory GetCategory(string categoryID)
        {
            foreach (CourseCategory category in GetCategories())
            {
                if (categoryID == category.ID)
                    return category;
            }
            return null;
            
        }

        public Course GetCourse(string courseCode)
        {
            foreach (Course course in GetCourses())
            {
                if (course.Code == courseCode)
                    return course;
            }

            return null;
        }

        public void AddCourse4Categories()
        {
            if (courses.Count > 0)
                return;

            CreateCourseList();
        }

        public Course CreateCourse(CourseCategory category,
           string code, string title, string desc, int duration, string fee)
        {
            Course course = new Course();
            course.Category = category;
            course.Code = code;
            course.CourseTitle = title;
            course.Description = desc;
            course.Duration = duration;
            course.Fee = fee;

            CourseInstructor instructor = GetInstructors()[r.Next(3)];
            course.Instructor = instructor;

            category.AddCourse(course);
            return course;
        }

        public void AddCategoryCourse(CourseCategory category,Course course)
        {
            category.AddCourse(course);
        }

        private List<CourseCategory> CreateCategoryList()
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

        private CourseCategory CreateCategory(string ID,string name,string description)
        {
            CourseCategory category = new CourseCategory(ID, name, description); 
            return category;
        }

        private void CreateCourseList()
        {            
            foreach(CourseCategory category in GetCategories())
            {
                courses.Add(CreateCourse(category, "coursecode1", "title1", "desc1", 3, "1000"));
                courses.Add(CreateCourse(category, "coursecode2", "title2", "desc2", 4, "2000"));
                courses.Add(CreateCourse(category, "coursecode3", "title3", "desc3", 5, "3000"));
                courses.Add(CreateCourse(category, "coursecode4", "title4", "desc4", 3, "1000"));
            }
        }



        List<CourseClass> courseClasses = new List<CourseClass> ();
        public void AddCourseClasses()
        {
            if (courseClasses.Count > 0)
                return;

            courseClasses = CreateClasses();
            
        } 
        
        public List<Course> GetCourses()
        {
            if (courses.Count < 1)
                CreateCourseList();
            return courses;
        }

        private List<CourseClass> CreateClasses()
        {
            List<CourseClass> courseClassList = new List<CourseClass> ();
            foreach(CourseCategory  category in GetCategories())
            {
                foreach(Course course in category.GetCourses())
                {
                    if(course.Status != CourseStatus.Disabled)
                    {
                        for (int i = 1; i < 6; i++)
                        {
                            int startDate = r.Next(i*30);
                            CourseClass cls = CreateClass(course,i, startDate, startDate + 7, (ClassStatus)(Enum.GetValues(typeof(ClassStatus)).GetValue(r.Next(4))));
                            courseClassList.Add(cls);
                        }
                    }

                }
            }
            
            return courseClassList;
        }

        private CourseClass CreateClass(Course course,int i, int startDate, int endDate, ClassStatus status)
        { 
            CourseClass cls = new CourseClass(course);
            cls.ClassCode ="classcode" +  r.Next(i);
            cls.StartDate = DateTime.Now.AddDays(startDate);
            cls.EndDate = DateTime.Now.AddDays(endDate);
            cls.Status = ClassStatus.New;
            cls.Size = 39;
            return cls;
        }
    }
}
