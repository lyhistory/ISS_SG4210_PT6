using CRS_DAL.EF;
using CRS_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using dm = nus.iss.crs.dm;

namespace CRS_DAL.Service
{
    public class ClassService
    {
        IUnitOfWork unitOfWork;

        IRepository<CourseClass> CourseClassRepository;
        IRepository<Course> CourseRepository;
        IRepository<CourseCategory> CourseCategoryRepository;
        IRepository<Participant> ParticipantRepository;
        IRepository<Registration> RegistrationRepository;

        public ClassService(IUnitOfWork unitOfWork, IRepository<CourseClass> courseClassRepository,
            IRepository<Course> courseRepository,IRepository<CourseCategory> courseCategoryRepository,
            IRepository<Participant> participantRepository,IRepository<Registration> registrationRepository)
        {
            this.unitOfWork = unitOfWork;
            this.CourseClassRepository = courseClassRepository;
            this.CourseRepository = courseRepository;
            this.CourseCategoryRepository = courseCategoryRepository;
            this.ParticipantRepository = participantRepository;
            this.RegistrationRepository = registrationRepository;
        }

        public bool CreateCourseClass(dm.Course.CourseClass courseClass)
        {
            try
            {
                CourseClass _courseClass = new CourseClass()
                {
                    ClassID = Guid.NewGuid().ToString(),
                    CourseCode = courseClass.GetCourse().Code,  //must not be null!!!!!!!!!!!
                    StartDate = courseClass.StartDate,
                    EndDate = courseClass.EndDate,
                    ClassCode = courseClass.ClassCode,
                    Status = (int)courseClass.Status,
                    Size = courseClass.Size
                };
                return true;
            }
            catch { }
            return false;
        }

        public bool ChangeCourseClassStatus(dm.Course.CourseClass courseClass)
        {
            try
            {
                CourseClass _courseClass = this.CourseClassRepository.GetSingleOrDefault(x => x.ClassCode.Equals(courseClass.ClassCode));
                if (_courseClass != null)
                {
                    _courseClass.Status = (int)courseClass.Status;
                    this.unitOfWork.Commit();
                    return true;
                }
            }
            catch { }
            return false;

        }

        public bool EditCourseClassDate(dm.Course.CourseClass courseClass,DateTime startDate,DateTime endDate)
        {
            try
            {
                CourseClass _courseClass = this.CourseClassRepository.GetSingleOrDefault(x => x.ClassCode.Equals(courseClass.ClassCode));
                if (_courseClass != null)
                {
                    _courseClass.StartDate = startDate;
                    _courseClass.EndDate = endDate;
                    this.unitOfWork.Commit();
                    return true;
                }
                
            }
            catch { }
            return false;

        }

        public dm.Course.CourseClass GetCourseClassByCode(string classCode)
        {
            CourseClass _courseClass =this.CourseClassRepository.GetSingleOrDefault(x => x.ClassCode.Equals(classCode));

            if(_courseClass!=null){

                Course _course=this.CourseRepository.GetSingleOrDefault(x=>x.CourseCode.Equals(_courseClass.CourseCode));
                if(_course!=null){

                    CourseCategory _category = this.CourseCategoryRepository.GetWhere(x => x.CategoryID.Equals(_course.CategoryID)).FirstOrDefault();
                    if(_category!=null){
                        return new dm.Course.CourseClass(
                                new dm.Course.Course(){
                                    CourseTitle = _course.CourseTitle,
                                        Code = _course.CourseCode,
                                        Category = new dm.Course.CourseCategory(_category.CategoryID, _category.CategoryName, _category.CategoryDesc),
                                        Description = _course.Description,
                                        Duration = _course.NumberOfDays,
                                        Fee = _course.Fee.HasValue ? _course.Fee.Value.ToString() : "0",
                                        Instructor = new dm.CourseInstructor(_course.Instructors),
                                        Status = (dm.Course.CourseStatus)_course.Status
                                }
                            ){
                                StartDate = _courseClass.StartDate,
                                EndDate =_courseClass.EndDate,
                                ClassCode =_courseClass.ClassCode,
                                Size =_courseClass.Size.HasValue ? _courseClass.Size.Value : 0,
                                Status =(dm.Course.ClassStatus)_courseClass.Status
                            };
                    }
                }
            }
            return null;
        }

        public List<dm.Registration.Participant> GetCourseClassParticipantList(dm.Course.CourseClass courseClass)
        {
            CourseClass _courseClass=this.CourseClassRepository.GetSingleOrDefault(x=>x.ClassCode.Equals(courseClass.ClassCode));
            if (_courseClass != null)
            {
                IQueryable<Registration> _registrationlist = this.RegistrationRepository.GetWhere(x => x.ClassID.Equals(_courseClass.ClassID));
                IQueryable<Participant> _paticipantlistall = this.ParticipantRepository.GetAll();

                List<Participant> _paticipantlist = _paticipantlistall.Join(_registrationlist, p => p.ParticipantID, r => r.ParticipantID, (p, r) => p).ToList();

                return (from _paticipant in _paticipantlist
                        select new dm.Registration.Participant()
                        {
                            IDNumber = _paticipant.IDNumber,
                            EmploymentStatus =_paticipant.EmploymentStatus,
                            CompanyID =_paticipant.CompanyID,
                            CompanyName =_paticipant.CompanyName,
                            Salutation = _paticipant.Salutation,
                            JobTitle =_paticipant.JobTitle,
                            Department=_paticipant.Department,
                            FullName =_paticipant.FullName,
                            OrganizationSize =_paticipant.OrganizationSize,
                            Gender =_paticipant.Gender==1 ? "Male" : "Female",
                            SalaryRange =_paticipant.SalaryRange,
                            Nationality =_paticipant.Nationality,
                            DOB =_paticipant.DateOfBirth,
                            EMail =_paticipant.Email,
                            ContactNumber=_paticipant.ContactNumber,
                            DietaryRequirement =_paticipant.DietaryRequirement
                        }).ToList();
            }
            return null;
        }
    }
}
