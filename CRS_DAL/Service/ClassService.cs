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
        IRepository<Instructor> InstructorRepository;

        public ClassService(IUnitOfWork unitOfWork, IRepository<CourseClass> courseClassRepository,
            IRepository<Course> courseRepository,IRepository<CourseCategory> courseCategoryRepository,
            IRepository<Participant> participantRepository,IRepository<Registration> registrationRepository,
            IRepository<Instructor> instructorRepository)
        {
            this.unitOfWork = unitOfWork;
            this.CourseClassRepository = courseClassRepository;
            this.CourseRepository = courseRepository;
            this.CourseCategoryRepository = courseCategoryRepository;
            this.ParticipantRepository = participantRepository;
            this.RegistrationRepository = registrationRepository;
            this.InstructorRepository = instructorRepository;
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
                    Instructor _instructor = this.InstructorRepository.GetSingleOrDefault(x => x.InstructorID.Equals(_course.InstructorID));
                    if (_instructor != null)
                    {
                        CourseCategory _category = this.CourseCategoryRepository.GetWhere(x => x.CategoryID.Equals(_course.CategoryID)).FirstOrDefault();
                        if (_category != null)
                        {
                            return new dm.Course.CourseClass(
                                    new dm.Course.Course()
                                    {
                                        CourseTitle = _course.CourseTitle,
                                        Code = _course.CourseCode,
                                        Category = new dm.Course.CourseCategory(_category.CategoryID, _category.CategoryName, _category.CategoryDesc),
                                        Description = _course.Description,
                                        Duration = _course.NumberOfDays,
                                        Fee = _course.Fee.ToString(),
                                        Instructor = new dm.CourseInstructor(_instructor.InstructorID, _instructor.InstructorName),
                                        Status = (dm.Course.CourseStatus)_course.Status
                                    }
                                )
                                {
                                    StartDate = _courseClass.StartDate,
                                    EndDate = _courseClass.EndDate,
                                    ClassCode = _courseClass.ClassCode,
                                    Size = _courseClass.Size,
                                    Status = (dm.Course.ClassStatus)_courseClass.Status
                                };
                        }
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
                IQueryable<Participant> _participantlistall = this.ParticipantRepository.GetAll();

                List<Participant> _participantlist = _participantlistall.Join(_registrationlist, p => p.ParticipantID, r => r.ParticipantID, (p, r) => p).ToList();

                return (from _participant in _participantlist
                        select new dm.Registration.Participant()
                        {
                            IDNumber = _participant.IDNumber,
                            EmploymentStatus =_participant.EmploymentStatus,
                            CompanyID =_participant.CompanyID,
                            CompanyName =_participant.CompanyName,
                            Salutation = _participant.Salutation,
                            JobTitle =_participant.JobTitle,
                            Department=_participant.Department,
                            FullName =_participant.FullName,
                            OrganizationSize =_participant.OrganizationSize,
                            Gender =_participant.Gender==1 ? "Male" : "Female",
                            SalaryRange =_participant.SalaryRange,
                            Nationality =_participant.Nationality,
                            DOB =_participant.DateOfBirth,
                            EMail =_participant.Email,
                            ContactNumber=_participant.ContactNumber,
                            DietaryRequirement =_participant.DietaryRequirement
                        }).ToList();
            }
            return null;
        }
    }
}
