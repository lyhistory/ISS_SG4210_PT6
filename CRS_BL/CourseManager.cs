using CRS_DAL.Repository;
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
        static UnitOfWork unitOfWork = new UnitOfWork();

        internal CourseManager() {}

        /// <summary>
        /// detect user type 
        /// </summary>
        /// <param name="session"></param>
        internal CourseManager(ISession session)
        {
            if (session.GetCurrentUser().GetRole() == null)
            {
                throw new Exception("No permisison");
            }
        }

        //List course category
        public List<CourseCategory> GetCourseCategoryList()
        {
            List<CourseCategory> courseCategoryList = unitOfWork.CourseService.GetCourseCategoryList();
            return courseCategoryList;
        }

        /// <summary>
        /// retrieve all the categoreis with its course and related class
        /// </summary>
        /// <param name="includeAllKids"></param>
        /// <returns></returns>
        public List<CourseCategory> GetCourseCategoryList(bool includeAllKids)
        {
            return GetCourseCategoryList(DateTime.MinValue, DateTime.MaxValue, includeAllKids);
        } 

        public List<CourseCategory> GetCourseCategoryList(DateTime dateFrom, DateTime dateTo, bool includeAllKids)
        {
            List<CourseCategory> courseCategoryList = unitOfWork.CourseService.GetCourseCategoryList();
            if (includeAllKids)
            {
                foreach (CourseCategory category in courseCategoryList)
                {
                    category.AddCourses(GetCourseListByCategory(category, dateFrom, dateTo, includeAllKids));
                }

            }
            return courseCategoryList;
        }

        public Course CreateCourse(Course course)
        {
            if (course.IsValid())
            {
                return unitOfWork.CourseService.CreateCourse(course);
            }
            return null;
        }


        public Course EditCourse(Course course)
        {
            return unitOfWork.CourseService.EditCourse(course);   
        }

        //show list of courses in a particular category
        public List<Course> GetCourseListByCategory(CourseCategory courseCategory)
        {
            List<Course> courseList = unitOfWork.CourseService.GetCourseListByCategory(courseCategory.ID);
            return courseList;
        }

        public List<Course> GetCourseListByCategory(CourseCategory courseCategory, DateTime dateFrom, DateTime dateTo, bool includeClass)
        {
            List<Course> courseList = unitOfWork.CourseService.GetCourseListByCategory(courseCategory.ID);
            if (includeClass)
            {
                foreach (Course course in courseList)
                {
                    course.AddClassList(GetCourseClassList(course, dateFrom, dateTo));
                }
            }
            return courseList;
        } 

        public List<CourseClass> GetCourseClassList(Course course, DateTime dateFrom, DateTime dateTo, ClassStatus status)
        {
            List<CourseClass> courseClassList = unitOfWork.CourseService.GetCourseClassList(course.Code, dateFrom, dateTo, (int)status);
            return courseClassList;
        }

        public List<CourseClass> GetCourseClassList(Course course, DateTime dateFrom, DateTime dateTo)
        {
             return unitOfWork.CourseService.GetCourseClassList(course.Code, dateFrom, dateTo);             
        }

        public List<CourseInstructor> GetInstructorList()
        {
            List<CourseInstructor> courseInstructorList = new List<CourseInstructor>();
            return courseInstructorList;
        }

        //List upcoming course within half years
        //public List<Course> GetUpcomingCourseList(DateTime dateFrom,DateTime dateTo)
        //{
        //    List<Course> courseList = new List<Course>();
        //    return courseList;
        //} 
 
        //show course detail by clicking course code
        public Course GetCourseByCode(string code)
        {
            Course course = new Course();
            return course;
        }
         
    }
}
