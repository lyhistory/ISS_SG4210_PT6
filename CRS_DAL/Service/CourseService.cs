﻿using CRS_DAL.EF;
using CRS_DAL.Repository;
using dm=nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAL.ModelMapper;

namespace CRS_DAL.Service
{
    public class CourseService
    {
        IUnitOfWork unitOfWork;

        IRepository<Course> CourseRepository;
        IRepository<CourseCategory> CourseCategoryRepository;
        IRepository<CourseClass> CourseClassRepository;

        public CourseService(IUnitOfWork uow,IRepository<Course> courseRepository, IRepository<CourseCategory> courseCategoryRepository, IRepository<CourseClass> courseClassRepository)
        {
            this.unitOfWork = uow;
            this.CourseCategoryRepository = courseCategoryRepository;
            this.CourseClassRepository = courseClassRepository;
            this.CourseRepository = courseRepository;
        }

        public List<dm.Course.CourseClass> GetCourseClassList(string courseCode, DateTime dateFrom, DateTime dateTo,int status=-1)
        {
            try
            {
                List<dm.Course.CourseClass> list = new List<dm.Course.CourseClass>();
                List<CourseClass> _list = this.CourseClassRepository.GetWhere(x => x.CourseCode.Equals(courseCode) 
                    && (x.StartDate==null||x.EndDate==null||x.StartDate >= dateFrom && x.EndDate <= dateTo)
                    && (status<0||x.Status==status)).ToList();
                Course _course = this.CourseRepository.GetWhere(x => x.CourseCode.Equals(courseCode)).FirstOrDefault();
                CourseCategory _category = this.CourseCategoryRepository.GetWhere(x => x.CategoryID.Equals(_course.CategoryID)).FirstOrDefault();

                return (from x in _list
                        select new dm.Course.CourseClass(
                            new dm.Course.Course()
                            {
                                CourseTitle = _course.CourseTitle,
                                Code = _course.CourseCode,
                                Category = new dm.Course.CourseCategory(_category.CategoryID, _category.CategoryName, _category.CategoryDesc),
                                Description = _course.Description,
                                Duration = _course.NumberOfDays,
                                Fee = _course.Fee.HasValue ? _course.Fee.Value.ToString() : "0",
                                Instructor = new dm.CourseInstructor(_course.Instructors),
                                Status = (dm.Course.CourseStatus)_course.Status

                            })
                        {
                            ClassCode = x.ClassCode,
                            StartDate = x.StartDate,
                            EndDate = x.EndDate,
                            Status = (dm.Course.ClassStatus)x.Status,
                            Size = x.Size.Value
                        }).ToList()
                        ;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<dm.Course.CourseCategory> GetCourseCategoryList()
        {
            var _categoryList = this.CourseCategoryRepository.GetAll().ToList();
            return (from x in _categoryList
                    select new dm.Course.CourseCategory(x.CategoryID, x.CategoryName, x.CategoryDesc)
                        ).ToList();
        }

        public List<dm.Course.Course> GetCourseListByCategory(string courseCategoryID)
        {
            CourseCategory _category = this.CourseCategoryRepository.GetWhere(x => x.CategoryID.Equals(courseCategoryID)).FirstOrDefault();
            var _list = this.CourseRepository.GetWhere(x => x.CategoryID.Equals(courseCategoryID)).ToList();

            return (from x in _list
                    select new dm.Course.Course()
                    {
                        CourseTitle = x.CourseTitle,
                        Code = x.CourseCode,
                        Category = new dm.Course.CourseCategory(_category.CategoryID, _category.CategoryName, _category.CategoryDesc),
                        Description = x.Description,
                        Duration = x.NumberOfDays,
                        Fee = x.Fee.HasValue ? x.Fee.Value.ToString() : "0",
                        Instructor = new dm.CourseInstructor(x.Instructors),
                        Status = (dm.Course.CourseStatus)x.Status
                    }).ToList();
        }

        public dm.Course.Course GetCourseByCode(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
               Course _course= this.CourseRepository.GetSingleOrDefault(x => x.CourseCode.Equals(code));
               CourseCategory _category = this.CourseCategoryRepository.GetWhere(x => x.CategoryID.Equals(_course.CategoryID)).FirstOrDefault();

               dm.Course.Course course = new dm.Course.Course()
                            {
                                CourseTitle = _course.CourseTitle,
                                Code = _course.CourseCode,
                                Category = new dm.Course.CourseCategory(_category.CategoryID, _category.CategoryName, _category.CategoryDesc),
                                Description = _course.Description,
                                Duration = _course.NumberOfDays,
                                Fee = _course.Fee.HasValue ? _course.Fee.Value.ToString() : "0",
                                Instructor = new dm.CourseInstructor(_course.Instructors),
                                Status = (dm.Course.CourseStatus)_course.Status

                            };
                return course;
            }
            return null;
        }

        public dm.Course.Course CreateCourse(dm.Course.Course course)
        {
            try
            {
                Course _course = new Course()
                {
                    CourseTitle = course.CourseTitle,
                    CourseCode = course.Code,
                    CategoryID = course.Category.ID,
                    Description = course.Description,
                    NumberOfDays = course.Duration,
                    Fee = int.Parse(course.Fee),
                    Instructors = course.Instructor.Name,
                    Status = (int)course.Status
                };
                this.CourseRepository.Add(_course);
                
                return course;
            }
            catch (Exception ex)
            {
                //log
            }
            return null;
        }

        public dm.Course.Course EditCourse(dm.Course.Course course)
        {
            try
            {
                if (course.IsValid())
                {
                    Course _course = this.CourseRepository.GetSingleOrDefault(x => x.CourseCode.Equals(course.Code));
                    if (_course != null)
                    {
                        _course.CourseTitle = course.CourseTitle;
                        _course.CourseCode = course.Code;
                        _course.CategoryID = course.Category.ID;
                        _course.Description = course.Description;
                        _course.NumberOfDays = course.Duration;
                        _course.Fee = int.Parse(course.Fee);
                        _course.Instructors = course.Instructor.Name;
                        _course.Status = (int)course.Status;
                    }
                    this.unitOfWork.Commit();
                    return course;
                }
            }
            catch (Exception ex)
            {
                //log
            }
            return null;
        }
    }
}
