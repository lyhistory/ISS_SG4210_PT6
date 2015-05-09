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
    public class CourseRegistrationService
    {
        IUnitOfWork unitOfWork;

        IRepository<CourseClass> CourseClassRepository;
        IRepository<Course> CourseRepository;
        IRepository<CourseCategory> CourseCategoryRepository;
        IRepository<Participant> ParticipantRepository;
        IRepository<Registration> RegistrationRepository;

        public CourseRegistrationService(IUnitOfWork unitOfWork, IRepository<CourseClass> courseClassRepository,
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

        public List<dm.Registration.Participant> GetEmployeeListByCompanyID(string companyID)
        {
            List<Participant> _participantlist = this.ParticipantRepository.GetWhere(x=>x.CompanyID.Equals(companyID)).ToList();
            if(_participantlist!=null){
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

        public dm.Registration.Participant GetEmployeeByIDNumber(string idNumber)
        {
            Participant _participant = this.ParticipantRepository.GetSingleOrDefault(x => x.IDNumber.Equals(idNumber));
            if (_participant != null)
            {
                return new dm.Registration.Participant()
                {
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
            }
            return null;
        }

        public bool CreateEmployee(dm.Registration.Participant participant)
        {
            try
            {
                Participant _participant = new Participant()
                {
                    IDNumber = participant.IDNumber,
                    EmploymentStatus = participant.EmploymentStatus,
                    CompanyID = participant.CompanyID,
                    CompanyName = participant.CompanyName,
                    Salutation = participant.Salutation,
                    JobTitle = participant.JobTitle,
                    Department = participant.Department,
                    FullName = participant.FullName,
                    OrganizationSize = participant.OrganizationSize,
                    Gender = participant.Gender.Equals("Male",StringComparison.OrdinalIgnoreCase) ? 1 : 2,
                    SalaryRange = participant.SalaryRange,
                    Nationality = participant.Nationality,
                    DateOfBirth = participant.DOB,
                    Email = participant.EMail,
                    ContactNumber = participant.ContactNumber,
                    DietaryRequirement = participant.DietaryRequirement
                };
                this.ParticipantRepository.Add(_participant);
                this.unitOfWork.Commit();
                return true;
            }
            catch { }

            return false;
        }

        public List<dm.Registration.Registration> GetRegistrationList(dm.Course.CourseClass courseClass)
        {
            CourseClass _courseClass = this.CourseClassRepository.GetSingleOrDefault(x => x.ClassCode.Equals(courseClass.ClassCode));
            if (_courseClass != null)
            {
                List<Registration> _registrationlist = this.RegistrationRepository.GetWhere(x => x.ClassID.Equals(_courseClass.ClassID)).ToList();
                IQueryable<Participant> _participantlist = this.ParticipantRepository.GetAll();
                return (from _registration in _registrationlist
                        join _participant in _participantlist on _registration.ParticipantID equals _participant.ParticipantID
                        select new dm.Registration.Registration(
                            courseClass,    // totally believe your input!!!!!!!!!!!!!!!!!
                            new dm.Registration.Participant(){
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
                            }
                            )
                        {
                            RegID=_registration.RegistrationID,
                            status =_registration.Status.HasValue ? (dm.RegistrationStatus)_registration.Status.Value : dm.RegistrationStatus.Cancel,
                            billingInfo =new dm.Registration.Billing(){
                                PersonName =_registration.BillingPersonName,
                                Address =_registration.BillingAddress,
                                Country =_registration.BillingAddressCountry,
                                PostalCode=_registration.BillingAddressPostalCode
                            },
                            Sponsorship=_registration.Sponsorship==1 ? "Self" : "Company",
                            DietaryRequirement =_registration.DietaryRequirement,
                            OrganizationSize = _registration.OrganizationSize.HasValue ? _registration.OrganizationSize.Value : 0
                        }).ToList();
            }
            return null;
        }

        public List<dm.Registration.Registration> GetRegistrationList(dm.User user)
        {
            Participant _participant = this.ParticipantRepository.GetSingleOrDefault(x => x.IDNumber.Equals(user.LoginID)&&string.IsNullOrEmpty(x.CompanyID));
            
            if (_participant != null)
            {
                List<Registration> _registrationlist = this.RegistrationRepository.GetWhere(x => x.ParticipantID.Equals(_participant.ParticipantID)).ToList();
                IQueryable<CourseClass> _courseClasslist = this.CourseClassRepository.GetAll();
                return (from _registration in _registrationlist
                        join _courseClass in _courseClasslist on _registration.ClassID equals _courseClass.ClassID
                        select new dm.Registration.Registration(
                            GetCourseClassByCode(_courseClass.ClassCode),   
                            new dm.Registration.Participant()
                            {
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
                            }
                            )
                        {
                            RegID = _registration.RegistrationID,
                            status = _registration.Status.HasValue ? (dm.RegistrationStatus)_registration.Status.Value : dm.RegistrationStatus.Cancel,
                            billingInfo = new dm.Registration.Billing()
                            {
                                PersonName = _registration.BillingPersonName,
                                Address = _registration.BillingAddress,
                                Country = _registration.BillingAddressCountry,
                                PostalCode = _registration.BillingAddressPostalCode
                            },
                            Sponsorship = _registration.Sponsorship == 1 ? "Self" : "Company",
                            DietaryRequirement = _registration.DietaryRequirement,
                            OrganizationSize = _registration.OrganizationSize.HasValue ? _registration.OrganizationSize.Value : 0
                        }).ToList();
            }
            return null;
        }

        public List<dm.Registration.Registration> GetRegistrationList(dm.Company company)
        {
            IQueryable<Participant> _participantlist = this.ParticipantRepository.GetWhere(x => x.CompanyID.Equals(company.CompanyID));

            if (_participantlist != null && _participantlist.Count() > 0)
            {
                List<Registration> _registrationlist = this.RegistrationRepository.GetAll().ToList();

                return (from _registration in _registrationlist
                        join _participant in _participantlist on _registration.ParticipantID equals _participant.ParticipantID
                        select new dm.Registration.Registration(
                            GetCourseClassByClassID(_registration.ClassID),
                            new dm.Registration.Participant()
                            {
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
                            }
                            )
                        {
                            RegID = _registration.RegistrationID,
                            status = _registration.Status.HasValue ? (dm.RegistrationStatus)_registration.Status.Value : dm.RegistrationStatus.Cancel,
                            billingInfo = new dm.Registration.Billing()
                            {
                                PersonName = _registration.BillingPersonName,
                                Address = _registration.BillingAddress,
                                Country = _registration.BillingAddressCountry,
                                PostalCode = _registration.BillingAddressPostalCode
                            },
                            Sponsorship = _registration.Sponsorship == 1 ? "Self" : "Company",
                            DietaryRequirement = _registration.DietaryRequirement,
                            OrganizationSize = _registration.OrganizationSize.HasValue ? _registration.OrganizationSize.Value : 0
                        }).ToList();
            }
            return null;
        }

        public bool EditRegistration(dm.Registration.Registration registration)
        {
            try
            {
                Registration _registration = this.RegistrationRepository.GetSingleOrDefault(x => x.RegistrationID.Equals(registration.RegID));
                _registration.Sponsorship = registration.Sponsorship.Equals("Self",StringComparison.OrdinalIgnoreCase) ? 1 : 2;
                _registration.Status = (int)registration.status;
                _registration.BillingAddress = registration.billingInfo.Address;
                _registration.BillingAddressCountry = registration.billingInfo.Country;
                _registration.BillingAddressPostalCode = registration.billingInfo.PostalCode;
                _registration.BillingPersonName = registration.billingInfo.PersonName;
                _registration.DietaryRequirement = registration.DietaryRequirement;
                _registration.OrganizationSize = registration.OrganizationSize;
                unitOfWork.Commit();
                return true;
            }
            catch { }
            return false;
        }

        public bool DeleteRegistration(dm.Registration.Registration registration)
        {
            try
            {
                Registration _registration = this.RegistrationRepository.GetSingleOrDefault(x => x.RegistrationID.Equals(registration.RegID));

                this.RegistrationRepository.Delete(_registration);

                unitOfWork.Commit();
                return true;
            }
            catch { }
            return false;
        }


        public dm.Registration.Registration GetRegistration(string RegID)
        {
            Registration _registration = this.RegistrationRepository.GetSingleOrDefault(x => x.RegistrationID.Equals(RegID));
            Participant _participant = this.ParticipantRepository.GetSingleOrDefault(x => x.ParticipantID.Equals(_registration.ParticipantID));
            if (_registration != null)
            {
                return new dm.Registration.Registration(
                            GetCourseClassByClassID(_registration.ClassID),
                            new dm.Registration.Participant()
                            {
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
                            }
                            )
                        {
                            RegID = _registration.RegistrationID,
                            status = _registration.Status.HasValue ? (dm.RegistrationStatus)_registration.Status.Value : dm.RegistrationStatus.Cancel,
                            billingInfo = new dm.Registration.Billing()
                            {
                                PersonName = _registration.BillingPersonName,
                                Address = _registration.BillingAddress,
                                Country = _registration.BillingAddressCountry,
                                PostalCode = _registration.BillingAddressPostalCode
                            },
                            Sponsorship = _registration.Sponsorship == 1 ? "Self" : "Company",
                            DietaryRequirement = _registration.DietaryRequirement,
                            OrganizationSize=_registration.OrganizationSize.HasValue ? _registration.OrganizationSize.Value : 0
                        };
            }
            return null;
        }

        #region Helper
        public dm.Course.CourseClass GetCourseClassByClassID(string classID)
        {
            CourseClass _courseClass = this.CourseClassRepository.GetSingleOrDefault(x => x.ClassID.Equals(classID));

            return GetCourseClassByCode(_courseClass.ClassCode);
        }

        public dm.Course.CourseClass GetCourseClassByCode(string classCode)
        {
            CourseClass _courseClass = this.CourseClassRepository.GetSingleOrDefault(x => x.ClassCode.Equals(classCode));

            if (_courseClass != null)
            {
                Course _course = this.CourseRepository.GetSingleOrDefault(x => x.CourseCode.Equals(_courseClass.CourseCode));
                if (_course != null)
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
                                    Fee = _course.Fee.HasValue ? _course.Fee.Value.ToString() : "0",
                                    Instructor = new dm.CourseInstructor(_course.Instructors),
                                    Status = (dm.Course.CourseStatus)_course.Status
                                }
                            )
                        {
                            StartDate = _courseClass.StartDate,
                            EndDate = _courseClass.EndDate,
                            ClassCode = _courseClass.ClassCode,
                            Size = _courseClass.Size.HasValue ? _courseClass.Size.Value : 0,
                            Status = (dm.Course.ClassStatus)_courseClass.Status
                        };
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
