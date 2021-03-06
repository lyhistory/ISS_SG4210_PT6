﻿using CRS_DAL.Repository;
using nus.iss.crs.dm;
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
        UnitOfWork unitOfWork = new UnitOfWork();
        private List<CourseCategory> courseCategoryList = null;
        private List<CourseInstructor> courseInstructorList = null;

        internal CourseManager() 
        {
        
        }

        /// <summary>
        /// detect user type 
        /// </summary>
        /// <param name="session"></param>
        internal CourseManager(ISession session)
        {
            //if (session.GetCurrentUser().GetRole() == null)
            //{
            //    throw new Exception("No permisison");
            //}
        }

        //List course category
        public  List<CourseCategory> GetCourseCategoryList()
        {
            if (courseCategoryList == null)
            courseCategoryList = unitOfWork.CourseService.GetCourseCategoryList();
            return courseCategoryList;
        }

        /// <summary>
        /// retrieve all the categoreis with its course and related class
        /// </summary>
        /// <param name="includeAllKids"></param>
        /// <returns></returns>
        public  List<CourseCategory> GetCourseCategoryList(bool includeAllKids)
        {
            return GetCourseCategoryList(DateTime.MinValue, DateTime.MaxValue, includeAllKids);
        }

        public List<CourseCategory> GetCourseCategoryList(DateTime dateFrom, DateTime dateTo, bool includeAllKids, string searchText="")
        {
            List<CourseCategory> courseCategoryList = unitOfWork.CourseService.GetCourseCategoryList(searchText);
            if (includeAllKids)
            {
                foreach (CourseCategory category in courseCategoryList)
                {
                    category.AddCourses(GetCourseListByCategory(category, dateFrom, dateTo, includeAllKids,true));
                }

            }
            return courseCategoryList;
        }

        public  Course CreateCourse(Course course)
        {
            if (course.IsValid())
            {
                return unitOfWork.CourseService.CreateCourse(course);
            }

            return null;
        }


        public  Course EditCourse(Course course)
        {
            if (course.IsValid())
            {
                return unitOfWork.CourseService.EditCourse(course);   
            }

            return null;
        }

        public bool ChangeCourseStatus(string courseCode)
        {
            if (string.IsNullOrEmpty(courseCode))
                return false;
            return unitOfWork.CourseService.ChangeCourseStatus(courseCode);
        }

        public bool DeleteCourse(string courseCode)
        {
            if (string.IsNullOrEmpty(courseCode))
                return false;
            return unitOfWork.CourseService.DeleteCourse(courseCode);
        }

        //show list of courses in a particular category
        public  List<Course> GetCourseListByCategory(CourseCategory courseCategory)
        {
            List<Course> courseList = unitOfWork.CourseService.GetCourseListByCategory(courseCategory.ID);
            foreach (Course course in courseList)
            {
                course.AddClassList(GetCourseClassList(course));
            }
            return courseList;
        }

        public  List<Course> GetCourseListByCategory(CourseCategory courseCategory, DateTime dateFrom, DateTime dateTo, bool includeClass,bool returnLevel1=false,bool returnLevel2=false)
        {
            List<Course> courseList = unitOfWork.CourseService.GetCourseListByCategory(courseCategory.ID, returnLevel2);
            if (includeClass)
            {
                foreach (Course course in courseList)
                {
                    course.AddClassList(GetCourseClassList(course, dateFrom, dateTo,returnLevel1,returnLevel2));
                }
            }
            return courseList;
        }

        public List<Course> GetCourseList()
        {
            return unitOfWork.CourseService.GetCourseList();
        }

        public  List<CourseClass> GetCourseClassList(Course course, DateTime dateFrom, DateTime dateTo, ClassStatus status)
        {
            List<CourseClass> courseClassList = unitOfWork.CourseService.GetCourseClassList(course.Code, dateFrom, dateTo, (int)status);
            return courseClassList;
        }

        public  List<CourseClass> GetCourseClassList(Course course, DateTime dateFrom, DateTime dateTo,bool returnLevel1=true,bool returnLevel2=true)
        {
             return unitOfWork.CourseService.GetCourseClassList(course.Code, dateFrom, dateTo,-1,returnLevel1,returnLevel2);             
        }

        public List<CourseClass> GetCourseClassList(Course course)
        {
            return unitOfWork.CourseService.GetCourseClassList(course.Code, DateTime.MinValue, DateTime.MaxValue);
        }

        public  List<CourseInstructor> GetInstructorList()
        {
            return unitOfWork.CourseService.GetInstructorList();
        }

        //List upcoming course within half years
        //public List<Course> GetUpcomingCourseList(DateTime dateFrom,DateTime dateTo)
        //{
        //    List<Course> courseList = new List<Course>();
        //    return courseList;
        //} 
 
        //show course detail by clicking course code
        public  Course GetCourseByCode(string code)
        {
            Course course = new Course();
            course = unitOfWork.CourseService.GetCourseByCode(code);

            return course;
        }
        
        public CourseCategory GetCourseCategoryByID(string categoryID)
        {
            foreach (CourseCategory category in this.GetCourseCategoryList())
            {
                if (category.ID == categoryID)
                    return category;
            }
            return null;
        }

        public CourseInstructor GetInstructorByID(string instructorID)
        {
            return unitOfWork.CourseService.GetInstructorByID(instructorID);
        }
    }
}
