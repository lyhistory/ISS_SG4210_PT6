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
    public class AttendanceService
    {
        IUnitOfWork unitOfWork;

        IRepository<CourseClass> CourseClassRepository;
        IRepository<Course> CourseRepository;
        IRepository<CourseCategory> CourseCategoryRepository;
        IRepository<Participant> ParticipantRepository;
        IRepository<Attendance> AttendanceRepository;
        IRepository<Instructor> InstructorRepository;
        IRepository<Registration> RegistrationRepository;

        public AttendanceService(IUnitOfWork unitOfWork, IRepository<CourseClass> courseClassRepository,
            IRepository<Course> courseRepository,IRepository<CourseCategory> courseCategoryRepository,
            IRepository<Participant> participantRepository,IRepository<Attendance> attendanceRepository,
            IRepository<Instructor> instructorRepository)
        {
            this.unitOfWork = unitOfWork;
            this.CourseClassRepository = courseClassRepository;
            this.CourseRepository = courseRepository;
            this.CourseCategoryRepository = courseCategoryRepository;
            this.ParticipantRepository = participantRepository;
            this.AttendanceRepository = attendanceRepository;
            this.InstructorRepository = instructorRepository;
        }

        public bool SaveParticipantAttendance(string participantID,string courseCode,DateTime classDate,int status,string remark)
        {
            try
            {
                if (string.IsNullOrEmpty(courseCode) || classDate==null||string.IsNullOrEmpty(participantID))
                    return false;
                List<CourseClass> _courseClasslist = CourseClassRepository.GetWhere(x => x.CourseCode.Equals(courseCode)&&x.StartDate<=classDate&&x.EndDate>=classDate).ToList();
                if (_courseClasslist == null || _courseClasslist.Count>1)
                    return false;
                CourseClass _courseClass = _courseClasslist.FirstOrDefault();
                Participant _participant = ParticipantRepository.GetFirstOrDefault(x => x.ParticipantID.Equals(participantID));
                Attendance _attendance = new Attendance();
                _attendance.AttendanceID = Guid.NewGuid().ToString();
                _attendance.ClassID = _courseClass.ClassID;
                _attendance.Status = status;
                _attendance.AttendanceDate = classDate;
                _attendance.ParticipantID = participantID;
                _attendance.Remark = remark;
                AttendanceRepository.Add(_attendance);
                unitOfWork.Commit();

                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public List<dm.ParticipantAttendance> GetUserAttendances(string participantID)
        {
            Participant _participant=this.ParticipantRepository.GetFirstOrDefault(x=>x.ParticipantID.Equals(participantID));
            if(_participant==null)
                return null;
            dm.Registration.Participant participant=new dm.Registration.Participant()
                        {
                            ParticipantID = _participant.ParticipantID,
                            IDNumber = _participant.IDNumber,
                            EmploymentStatus = _participant.EmploymentStatus,
                            CompanyID = _participant.CompanyID,
                            CompanyName = _participant.CompanyName,
                            Salutation = _participant.Salutation,
                            JobTitle = _participant.JobTitle,
                            Department = _participant.Department,
                            FullName = _participant.FullName,
                            OrganizationSize = _participant.OrganizationSize,
                            Gender = _participant.Gender == 1 ? "Male" : "Female",
                            SalaryRange = _participant.SalaryRange,
                            Nationality = _participant.Nationality,
                            DOB = _participant.DateOfBirth,
                            EMail = _participant.Email,
                            ContactNumber = _participant.ContactNumber,
                            DietaryRequirement = _participant.DietaryRequirement
                        };
            List<Attendance> attendancelist = this.AttendanceRepository.GetWhere(x => x.ParticipantID.Equals(participantID)).ToList();
            IQueryable<CourseClass> courseClasslist=this.CourseClassRepository.GetAll();
            IQueryable<Course> courselist=this.CourseRepository.GetAll();
            IQueryable<Instructor> instructorlist = this.InstructorRepository.GetAll();
            IQueryable<CourseCategory> courseCategorylist=this.CourseCategoryRepository.GetAll();

            return (from attendance in attendancelist
                    join courseClass in courseClasslist on attendance.ClassID equals courseClass.ClassID
                    join course in courselist on courseClass.ClassCode equals course.CourseCode
                    join courseCategory in courseCategorylist on course.CategoryID equals courseCategory.CategoryID
                    join instructor in instructorlist on course.InstructorID equals instructor.InstructorID
                    select new dm.ParticipantAttendance()
                    {
                        Attendant = participant,
                        ClassDate = attendance.AttendanceDate.Value,
                        Status = (nus.iss.crs.dm.AttendanceStatus)attendance.Status,
                        Remark = attendance.Remark,
                        CourseObj = new dm.Course.Course()
                    {
                        CourseTitle = course.CourseTitle,
                        Code = course.CourseCode,
                        Category = new dm.Course.CourseCategory(courseCategory.CategoryID, courseCategory.CategoryName, courseCategory.CategoryDesc),
                        Description = course.Description,
                        Duration = course.NumberOfDays,
                        Fee = course.Fee.ToString(),
                        Instructor = new dm.CourseInstructor()
                        {
                            ID=instructor.InstructorID,
                            Name=instructor.InstructorName
                        },
                        Status = (dm.Course.CourseStatus)course.Status
                    }
                    }).ToList();


        }

        public List<dm.ParticipantAttendance> GetUserAttendances(string participantID, string classCode)
        {
            Participant _participant = this.ParticipantRepository.GetFirstOrDefault(x => x.ParticipantID.Equals(participantID));
            if (_participant == null)
                return null;
            CourseClass _courseClass = this.CourseClassRepository.GetFirstOrDefault(x => x.ClassCode.Equals(classCode));
            if (_courseClass == null)
                return null;
            Course _course = this.CourseRepository.GetFirstOrDefault(x => x.CourseCode.Equals(_courseClass.CourseCode));
            if (_course == null)
                return null;
            CourseCategory _courseCategory = this.CourseCategoryRepository.GetFirstOrDefault(x => x.CategoryID.Equals(_course.CategoryID));
            if (_courseCategory == null)
                return null;
            Instructor _instructor = this.InstructorRepository.GetFirstOrDefault(x => x.InstructorID.Equals(_course.InstructorID));
            if (_instructor == null)
                return null;

            dm.Registration.Participant participant = new dm.Registration.Participant()
            {
                ParticipantID = _participant.ParticipantID,
                IDNumber = _participant.IDNumber,
                EmploymentStatus = _participant.EmploymentStatus,
                CompanyID = _participant.CompanyID,
                CompanyName = _participant.CompanyName,
                Salutation = _participant.Salutation,
                JobTitle = _participant.JobTitle,
                Department = _participant.Department,
                FullName = _participant.FullName,
                OrganizationSize = _participant.OrganizationSize,
                Gender = _participant.Gender == 1 ? "Male" : "Female",
                SalaryRange = _participant.SalaryRange,
                Nationality = _participant.Nationality,
                DOB = _participant.DateOfBirth,
                EMail = _participant.Email,
                ContactNumber = _participant.ContactNumber,
                DietaryRequirement = _participant.DietaryRequirement
            };
            List<Attendance> attendancelist = this.AttendanceRepository.GetWhere(x => x.ParticipantID.Equals(participantID) && x.ClassID.Equals(_courseClass.ClassID)).ToList();

            IQueryable<CourseClass> courseClasslist = this.CourseClassRepository.GetAll();
            IQueryable<Course> courselist = this.CourseRepository.GetAll();
            IQueryable<Instructor> instructorlist = this.InstructorRepository.GetAll();
            IQueryable<CourseCategory> courseCategorylist = this.CourseCategoryRepository.GetAll();

            return (from attendance in attendancelist
                    
                    select new dm.ParticipantAttendance()
                    {
                        Attendant = participant,
                        ClassDate = attendance.AttendanceDate.Value,
                        Status = (nus.iss.crs.dm.AttendanceStatus)attendance.Status,
                        Remark = attendance.Remark,
                        CourseObj = new dm.Course.Course()
                        {
                            CourseTitle = _course.CourseTitle,
                            Code = _course.CourseCode,
                            Category = new dm.Course.CourseCategory(_courseCategory.CategoryID, _courseCategory.CategoryName, _courseCategory.CategoryDesc),
                            Description = _course.Description,
                            Duration = _course.NumberOfDays,
                            Fee = _course.Fee.ToString(),
                            Instructor = new dm.CourseInstructor()
                            {
                                ID = _instructor.InstructorID,
                                Name = _instructor.InstructorName
                            },
                            Status = (dm.Course.CourseStatus)_course.Status
                        }
                    }).ToList();
        }

        public List<dm.ParticipantAttendance> GetUserAttendancesByClassCode(string classCode)
        {
            CourseClass _courseClass = this.CourseClassRepository.GetFirstOrDefault(x => x.ClassCode.Equals(classCode));
            if (_courseClass == null)
                return null;
            Course _course = this.CourseRepository.GetFirstOrDefault(x => x.CourseCode.Equals(_courseClass.CourseCode));
            if (_course == null)
                return null;
            CourseCategory _courseCategory = this.CourseCategoryRepository.GetFirstOrDefault(x => x.CategoryID.Equals(_course.CategoryID));
            if (_courseCategory == null)
                return null;
            Instructor _instructor = this.InstructorRepository.GetFirstOrDefault(x => x.InstructorID.Equals(_course.InstructorID));
            if (_instructor == null)
                return null;

            
            List<Attendance> attendancelist = this.AttendanceRepository.GetWhere(x=>x.ClassID.Equals(_courseClass.ClassID)).ToList();

            IQueryable<Participant> participantlist = this.ParticipantRepository.GetAll();

            return (from attendance in attendancelist
                    join participant in participantlist on attendance.ParticipantID equals participant.ParticipantID into finalist
                    from _participant in finalist
                    select new dm.ParticipantAttendance()
                    {
                        Attendant = new dm.Registration.Participant()
                        {
                            ParticipantID = _participant.ParticipantID,
                            IDNumber = _participant.IDNumber,
                            EmploymentStatus = _participant.EmploymentStatus,
                            CompanyID = _participant.CompanyID,
                            CompanyName = _participant.CompanyName,
                            Salutation = _participant.Salutation,
                            JobTitle = _participant.JobTitle,
                            Department = _participant.Department,
                            FullName = _participant.FullName,
                            OrganizationSize = _participant.OrganizationSize,
                            Gender = _participant.Gender == 1 ? "Male" : "Female",
                            SalaryRange = _participant.SalaryRange,
                            Nationality = _participant.Nationality,
                            DOB = _participant.DateOfBirth,
                            EMail = _participant.Email,
                            ContactNumber = _participant.ContactNumber,
                            DietaryRequirement = _participant.DietaryRequirement
                        },
                        ClassDate = attendance.AttendanceDate.Value,
                        Status = (nus.iss.crs.dm.AttendanceStatus)attendance.Status,
                        Remark = attendance.Remark,
                        CourseObj = new dm.Course.Course()
                        {
                            CourseTitle = _course.CourseTitle,
                            Code = _course.CourseCode,
                            Category = new dm.Course.CourseCategory(_courseCategory.CategoryID, _courseCategory.CategoryName, _courseCategory.CategoryDesc),
                            Description = _course.Description,
                            Duration = _course.NumberOfDays,
                            Fee = _course.Fee.ToString(),
                            Instructor = new dm.CourseInstructor()
                            {
                                ID = _instructor.InstructorID,
                                Name = _instructor.InstructorName
                            },
                            Status = (dm.Course.CourseStatus)_course.Status
                        }
                    }).ToList();
        }

        public List<dm.ParticipantAttendance> GetUserAttendancesByClassCode(string classCode, DateTime date)
        {
            CourseClass _courseClass = this.CourseClassRepository.GetFirstOrDefault(x => x.ClassCode.Equals(classCode));
            if (_courseClass == null)
                return null;
            Course _course = this.CourseRepository.GetFirstOrDefault(x => x.CourseCode.Equals(_courseClass.CourseCode));
            if (_course == null)
                return null;
            CourseCategory _courseCategory = this.CourseCategoryRepository.GetFirstOrDefault(x => x.CategoryID.Equals(_course.CategoryID));
            if (_courseCategory == null)
                return null;
            Instructor _instructor = this.InstructorRepository.GetFirstOrDefault(x => x.InstructorID.Equals(_course.InstructorID));
            if (_instructor == null)
                return null;


            List<Attendance> attendancelist = this.AttendanceRepository.GetWhere(x => x.ClassID.Equals(_courseClass.ClassID)
                &&x.AttendanceDate!=null
                &&x.AttendanceDate.Value.Year==date.Year
                &&x.AttendanceDate.Value.Month==date.Month
                &&x.AttendanceDate.Value.Day==date.Day).ToList();

            IQueryable<Participant> participantlist = this.ParticipantRepository.GetAll();

            return (from attendance in attendancelist
                    join participant in participantlist on attendance.ParticipantID equals participant.ParticipantID into finalist
                    from _participant in finalist
                    select new dm.ParticipantAttendance()
                    {
                        Attendant = new dm.Registration.Participant()
                        {
                            ParticipantID = _participant.ParticipantID,
                            IDNumber = _participant.IDNumber,
                            EmploymentStatus = _participant.EmploymentStatus,
                            CompanyID = _participant.CompanyID,
                            CompanyName = _participant.CompanyName,
                            Salutation = _participant.Salutation,
                            JobTitle = _participant.JobTitle,
                            Department = _participant.Department,
                            FullName = _participant.FullName,
                            OrganizationSize = _participant.OrganizationSize,
                            Gender = _participant.Gender == 1 ? "Male" : "Female",
                            SalaryRange = _participant.SalaryRange,
                            Nationality = _participant.Nationality,
                            DOB = _participant.DateOfBirth,
                            EMail = _participant.Email,
                            ContactNumber = _participant.ContactNumber,
                            DietaryRequirement = _participant.DietaryRequirement
                        },
                        ClassDate = attendance.AttendanceDate.Value,
                        Status = (nus.iss.crs.dm.AttendanceStatus)attendance.Status,
                        Remark = attendance.Remark,
                        CourseObj = new dm.Course.Course()
                        {
                            CourseTitle = _course.CourseTitle,
                            Code = _course.CourseCode,
                            Category = new dm.Course.CourseCategory(_courseCategory.CategoryID, _courseCategory.CategoryName, _courseCategory.CategoryDesc),
                            Description = _course.Description,
                            Duration = _course.NumberOfDays,
                            Fee = _course.Fee.ToString(),
                            Instructor = new dm.CourseInstructor()
                            {
                                ID = _instructor.InstructorID,
                                Name = _instructor.InstructorName
                            },
                            Status = (dm.Course.CourseStatus)_course.Status
                        }
                    }).ToList();
        }

        public List<dm.ParticipantAttendance> GetUserAttendancesByCourseCode(string courseCode)
        {
            Course _course = this.CourseRepository.GetFirstOrDefault(x => x.CourseCode.Equals(courseCode));
            if (_course == null)
                return null;
            CourseCategory _courseCategory = this.CourseCategoryRepository.GetFirstOrDefault(x => x.CategoryID.Equals(_course.CategoryID));
            if (_courseCategory == null)
                return null;
            Instructor _instructor = this.InstructorRepository.GetFirstOrDefault(x => x.InstructorID.Equals(_course.InstructorID));
            if (_instructor == null)
                return null;

            IQueryable<CourseClass> _courseClassList = this.CourseClassRepository.GetWhere(x => x.CourseCode.Equals(courseCode));
            if (_courseClassList == null)
                return null;

            List<Attendance> attendancelist = this.AttendanceRepository.GetAll().ToList();

            IQueryable<Participant> participantlist = this.ParticipantRepository.GetAll();

            return (from attendance in attendancelist
                    join courseClass in _courseClassList on attendance.ClassID equals courseClass.ClassID
                    join participant in participantlist on attendance.ParticipantID equals participant.ParticipantID into finalist
                    from _participant in finalist
                    select new dm.ParticipantAttendance()
                    {
                        Attendant = new dm.Registration.Participant()
                        {
                            ParticipantID = _participant.ParticipantID,
                            IDNumber = _participant.IDNumber,
                            EmploymentStatus = _participant.EmploymentStatus,
                            CompanyID = _participant.CompanyID,
                            CompanyName = _participant.CompanyName,
                            Salutation = _participant.Salutation,
                            JobTitle = _participant.JobTitle,
                            Department = _participant.Department,
                            FullName = _participant.FullName,
                            OrganizationSize = _participant.OrganizationSize,
                            Gender = _participant.Gender == 1 ? "Male" : "Female",
                            SalaryRange = _participant.SalaryRange,
                            Nationality = _participant.Nationality,
                            DOB = _participant.DateOfBirth,
                            EMail = _participant.Email,
                            ContactNumber = _participant.ContactNumber,
                            DietaryRequirement = _participant.DietaryRequirement
                        },
                        ClassDate = attendance.AttendanceDate.Value,
                        ClassCode = courseClass.ClassCode,
                        Status = (nus.iss.crs.dm.AttendanceStatus)attendance.Status,
                        Remark = attendance.Remark,
                        CourseObj = new dm.Course.Course()
                        {
                            CourseTitle = _course.CourseTitle,
                            Code = _course.CourseCode,
                            Category = new dm.Course.CourseCategory(_courseCategory.CategoryID, _courseCategory.CategoryName, _courseCategory.CategoryDesc),
                            Description = _course.Description,
                            Duration = _course.NumberOfDays,
                            Fee = _course.Fee.ToString(),
                            Instructor = new dm.CourseInstructor()
                            {
                                ID = _instructor.InstructorID,
                                Name = _instructor.InstructorName
                            },
                            Status = (dm.Course.CourseStatus)_course.Status
                        }
                    }).ToList();
        }

        public List<dm.ParticipantAttendance> GetUserAttendancesByCourseCode(string courseCode, DateTime date)
        {
            Course _course = this.CourseRepository.GetFirstOrDefault(x => x.CourseCode.Equals(courseCode));
            if (_course == null)
                return null;
            CourseCategory _courseCategory = this.CourseCategoryRepository.GetFirstOrDefault(x => x.CategoryID.Equals(_course.CategoryID));
            if (_courseCategory == null)
                return null;
            Instructor _instructor = this.InstructorRepository.GetFirstOrDefault(x => x.InstructorID.Equals(_course.InstructorID));
            if (_instructor == null)
                return null;

            IQueryable<CourseClass> _courseClassList = this.CourseClassRepository.GetWhere(x => x.CourseCode.Equals(courseCode)&&x.StartDate<=date&&x.EndDate>=date);
            if (_courseClassList == null)
                return null;

            List<Attendance> attendancelist = this.AttendanceRepository.GetWhere(x => x.AttendanceDate != null
                && x.AttendanceDate.Value.Year == date.Year
                && x.AttendanceDate.Value.Month == date.Month
                && x.AttendanceDate.Value.Day == date.Day).ToList();

            IQueryable<Participant> participantlist = this.ParticipantRepository.GetAll();

            return (from attendance in attendancelist
                    join courseClass in _courseClassList on attendance.ClassID equals courseClass.ClassID
                    join participant in participantlist on attendance.ParticipantID equals participant.ParticipantID into finalist
                    from _participant in finalist
                    select new dm.ParticipantAttendance()
                    {
                        Attendant = new dm.Registration.Participant()
                        {
                            ParticipantID = _participant.ParticipantID,
                            IDNumber = _participant.IDNumber,
                            EmploymentStatus = _participant.EmploymentStatus,
                            CompanyID = _participant.CompanyID,
                            CompanyName = _participant.CompanyName,
                            Salutation = _participant.Salutation,
                            JobTitle = _participant.JobTitle,
                            Department = _participant.Department,
                            FullName = _participant.FullName,
                            OrganizationSize = _participant.OrganizationSize,
                            Gender = _participant.Gender == 1 ? "Male" : "Female",
                            SalaryRange = _participant.SalaryRange,
                            Nationality = _participant.Nationality,
                            DOB = _participant.DateOfBirth,
                            EMail = _participant.Email,
                            ContactNumber = _participant.ContactNumber,
                            DietaryRequirement = _participant.DietaryRequirement
                        },
                        ClassDate = attendance.AttendanceDate.Value,
                        ClassCode=courseClass.ClassCode,
                        Status = (nus.iss.crs.dm.AttendanceStatus)attendance.Status,
                        Remark = attendance.Remark,
                        CourseObj = new dm.Course.Course()
                        {
                            CourseTitle = _course.CourseTitle,
                            Code = _course.CourseCode,
                            Category = new dm.Course.CourseCategory(_courseCategory.CategoryID, _courseCategory.CategoryName, _courseCategory.CategoryDesc),
                            Description = _course.Description,
                            Duration = _course.NumberOfDays,
                            Fee = _course.Fee.ToString(),
                            Instructor = new dm.CourseInstructor()
                            {
                                ID = _instructor.InstructorID,
                                Name = _instructor.InstructorName
                            },
                            Status = (dm.Course.CourseStatus)_course.Status
                        }
                    }).ToList();
        }
    }
}
