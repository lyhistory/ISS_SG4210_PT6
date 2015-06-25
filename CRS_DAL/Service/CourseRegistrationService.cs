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
        IRepository<Instructor> InstructorRepository;

        public CourseRegistrationService(IUnitOfWork unitOfWork, IRepository<CourseClass> courseClassRepository,
            IRepository<Course> courseRepository, IRepository<CourseCategory> courseCategoryRepository,
            IRepository<Participant> participantRepository, IRepository<Registration> registrationRepository,
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

        public List<dm.Registration.Participant> GetEmployeeListByCompanyID(string companyID)
        {
            if (string.IsNullOrEmpty(companyID))
            {
                return null;
            }
            List<Participant> _participantlist = this.ParticipantRepository.GetWhere(x => x.CompanyID.Equals(companyID)).ToList();
            if (_participantlist != null)
            {
                return (from _participant in _participantlist
                        select new dm.Registration.Participant()
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
                        }).ToList();
            }
            return null;
        }
        public List<dm.Registration.Participant> GetEmployeeListByCompanyName(string companyName)
        {
            if (string.IsNullOrEmpty(companyName))
            {
                return null;
            }
            List<Participant> _participantlist = this.ParticipantRepository.GetWhere(x => x.CompanyName.Equals(companyName)).ToList();
            if (_participantlist != null)
            {
                return (from _participant in _participantlist
                        select new dm.Registration.Participant()
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
                        }).ToList();
            }
            return null;
        }
        public dm.Registration.Participant GetParticipantByIDNumber(string idNumber, string companyID = "")
        {
            Participant _participant = string.IsNullOrEmpty(companyID) ? this.ParticipantRepository.GetFirstOrDefault(x => x.IDNumber.Equals(idNumber) && string.IsNullOrEmpty(x.CompanyID))
                :
                this.ParticipantRepository.GetFirstOrDefault(x => x.IDNumber.Equals(idNumber) && companyID.Equals(companyID));
            if (_participant != null)
            {
                return new dm.Registration.Participant()
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
            }
            return null;
        }

        public dm.Registration.Participant UpdateParticipant(dm.Registration.Participant participant, string companyID = "")
        {
            try
            {
                Participant _participant = string.IsNullOrEmpty(companyID) ? this.ParticipantRepository.GetFirstOrDefault(x => x.IDNumber.Equals(participant.IDNumber) && string.IsNullOrEmpty(x.CompanyID))
                :
                this.ParticipantRepository.GetFirstOrDefault(x => x.IDNumber.Equals(participant.IDNumber) && companyID.Equals(companyID));

                if (_participant != null)
                {
                    _participant.EmploymentStatus = participant.EmploymentStatus;
                    _participant.CompanyName = participant.CompanyName;
                    _participant.JobTitle = participant.JobTitle;
                    _participant.Department = participant.Department;
                    _participant.OrganizationSize = participant.OrganizationSize;
                    _participant.SalaryRange = participant.SalaryRange;

                    _participant.FullName = participant.FullName;
                    _participant.Gender = participant.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase) ? 1 : 2;
                    _participant.Nationality = participant.Nationality;
                    _participant.DateOfBirth = participant.DOB;
                    _participant.Email = participant.EMail;
                    _participant.ContactNumber = participant.ContactNumber;
                    _participant.DietaryRequirement = participant.DietaryRequirement;

                    this.unitOfWork.Commit();
                    return participant;
                }
            }
            catch { }

            return null;
        }

        public dm.Registration.Participant CreateParticipant(dm.Registration.Participant participant)
        {
            try
            {
                Participant _participant = new Participant()
                {
                    ParticipantID = Guid.NewGuid().ToString(),
                    IDNumber = participant.IDNumber,
                    EmploymentStatus = participant.EmploymentStatus,
                    CompanyID = participant.CompanyID,
                    CompanyName = participant.CompanyName,
                    Salutation = participant.Salutation,
                    JobTitle = participant.JobTitle,
                    Department = participant.Department,
                    FullName = participant.FullName,
                    OrganizationSize = participant.OrganizationSize,
                    Gender = participant.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase) ? 1 : 2,
                    SalaryRange = participant.SalaryRange,
                    Nationality = participant.Nationality,
                    DateOfBirth = participant.DOB,
                    Email = participant.EMail,
                    ContactNumber = participant.ContactNumber,
                    DietaryRequirement = participant.DietaryRequirement
                };
                this.ParticipantRepository.Add(_participant);
                this.unitOfWork.Commit();
                return participant;
            }
            catch { }

            return null;
        }

        public List<dm.Registration.Registration> GetRegistrationList(dm.Course.CourseClass courseClass)
        {
            CourseClass _courseClass = this.CourseClassRepository.GetFirstOrDefault(x => x.ClassCode.Equals(courseClass.ClassCode));
            if (_courseClass != null)
            {
                List<Registration> _registrationlist = this.RegistrationRepository.GetWhere(x => x.ClassID.Equals(_courseClass.ClassID)).ToList();
                IQueryable<Participant> _participantlist = this.ParticipantRepository.GetAll();
                return (from _registration in _registrationlist
                        join _participant in _participantlist on _registration.ParticipantID equals _participant.ParticipantID
                        select new dm.Registration.Registration(
                            courseClass,    // totally believe your input!!!!!!!!!!!!!!!!!
                            new dm.Registration.Participant()
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
                            }
                            )
                        {
                            RegID = _registration.RegistrationID,
                            Status = (dm.RegistrationStatus)_registration.Status,
                            billingInfo = new dm.Registration.Billing()
                            {
                                PersonName = _registration.BillingPersonName,
                                Address = _registration.BillingAddress,
                                Country = _registration.BillingAddressCountry,
                                PostalCode = _registration.BillingAddressPostalCode
                            },
                            Sponsorship = _registration.Sponsorship == 1 ? "Self" : "Company",
                            DietaryRequirement = _registration.DietaryRequirement,
                            OrganizationSize = _registration.OrganizationSize
                        }).ToList();
            }
            return null;
        }

        public List<dm.Registration.Registration> GetRegistrationListByEmployee(dm.User user)
        {
            Participant _participant = this.ParticipantRepository.GetFirstOrDefault(x => x.IDNumber.Equals(user.LoginID) && string.IsNullOrEmpty(x.CompanyID));

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
                            }
                            )
                        {
                            RegID = _registration.RegistrationID,
                            Status = (dm.RegistrationStatus)_registration.Status,
                            billingInfo = new dm.Registration.Billing()
                            {
                                PersonName = _registration.BillingPersonName,
                                Address = _registration.BillingAddress,
                                Country = _registration.BillingAddressCountry,
                                PostalCode = _registration.BillingAddressPostalCode
                            },
                            Sponsorship = _registration.Sponsorship == 1 ? "Self" : "Company",
                            DietaryRequirement = _registration.DietaryRequirement,
                            OrganizationSize = _registration.OrganizationSize
                        }).ToList();
            }
            return null;
        }

        public List<dm.Registration.Registration> GetRegistrationListByParticipant(dm.Registration.Participant pariticipant)
        {
            IQueryable<Participant> _participantlist = null;
            if (string.IsNullOrEmpty(pariticipant.IDNumber) && string.IsNullOrEmpty(pariticipant.FullName))
                return null;
            if(!string.IsNullOrEmpty(pariticipant.IDNumber))
                _participantlist=this.ParticipantRepository.GetWhere(x => x.IDNumber.Equals(pariticipant.IDNumber));
            else
                _participantlist=this.ParticipantRepository.GetAll();
            if (!string.IsNullOrEmpty(pariticipant.FullName))
            {
                _participantlist = _participantlist.Where(x => x.FullName.Contains(pariticipant.FullName));
            }

            if (_participantlist != null)
            {
                List<Registration> _registrationlist = this.RegistrationRepository.GetAll().ToList();
                IQueryable<CourseClass> _courseClasslist = this.CourseClassRepository.GetAll();
                return (from _registration in _registrationlist
                        join _courseClass in _courseClasslist on _registration.ClassID equals _courseClass.ClassID
                        join _participant in _participantlist on _registration.ParticipantID equals _participant.ParticipantID into finallist
                        from subset in finallist
                        select new dm.Registration.Registration(
                            GetCourseClassByCode(_courseClass.ClassCode),
                            new dm.Registration.Participant()
                            {
                                ParticipantID = subset.ParticipantID,
                                IDNumber = subset.IDNumber,
                                EmploymentStatus = subset.EmploymentStatus,
                                CompanyID = subset.CompanyID,
                                CompanyName = subset.CompanyName,
                                Salutation = subset.Salutation,
                                JobTitle = subset.JobTitle,
                                Department = subset.Department,
                                FullName = subset.FullName,
                                OrganizationSize = subset.OrganizationSize,
                                Gender = subset.Gender == 1 ? "Male" : "Female",
                                SalaryRange = subset.SalaryRange,
                                Nationality = subset.Nationality,
                                DOB = subset.DateOfBirth,
                                EMail = subset.Email,
                                ContactNumber = subset.ContactNumber,
                                DietaryRequirement = subset.DietaryRequirement
                            }
                            )
                        {
                            RegID = _registration.RegistrationID,
                            Status = (dm.RegistrationStatus)_registration.Status,
                            billingInfo = new dm.Registration.Billing()
                            {
                                PersonName = _registration.BillingPersonName,
                                Address = _registration.BillingAddress,
                                Country = _registration.BillingAddressCountry,
                                PostalCode = _registration.BillingAddressPostalCode
                            },
                            Sponsorship = _registration.Sponsorship == 1 ? "Self" : "Company",
                            DietaryRequirement = _registration.DietaryRequirement,
                            OrganizationSize = _registration.OrganizationSize
                        }).ToList();
            }
            return null;
        }

        public List<dm.Registration.Registration> GetRegistrationListByCompany(dm.Company company)
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
                            }
                            )
                        {
                            RegID = _registration.RegistrationID,
                            Status = (dm.RegistrationStatus)_registration.Status,
                            billingInfo = new dm.Registration.Billing()
                            {
                                PersonName = _registration.BillingPersonName,
                                Address = _registration.BillingAddress,
                                Country = _registration.BillingAddressCountry,
                                PostalCode = _registration.BillingAddressPostalCode
                            },
                            Sponsorship = _registration.Sponsorship == 1 ? "Self" : "Company",
                            DietaryRequirement = _registration.DietaryRequirement,
                            OrganizationSize = _registration.OrganizationSize
                        }).ToList();
            }
            return null;
        }

        public List<dm.Registration.Registration> GetRegistrationList()
        {
            List<Registration> _registrationlist = this.RegistrationRepository.GetAll().ToList();
            IQueryable<Participant> _participantlist = this.ParticipantRepository.GetAll();
            try
            {
                return (from _registration in _registrationlist
                        join _participant in _participantlist on _registration.ParticipantID equals _participant.ParticipantID
                        select new dm.Registration.Registration(
                            GetCourseClassByClassID(_registration.ClassID),
                            new dm.Registration.Participant()
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
                            }
                            )
                        {
                            RegID = _registration.RegistrationID,
                            Status = (dm.RegistrationStatus)_registration.Status,
                            billingInfo = new dm.Registration.Billing()
                            {
                                PersonName = _registration.BillingPersonName,
                                Address = _registration.BillingAddress,
                                Country = _registration.BillingAddressCountry,
                                PostalCode = _registration.BillingAddressPostalCode
                            },
                            Sponsorship = _registration.Sponsorship == 1 ? "Self" : "Company",
                            DietaryRequirement = _registration.DietaryRequirement,
                            OrganizationSize = _registration.OrganizationSize
                        }).ToList();
            }
            catch(Exception ex){
            
            }
            return null;
        }

        public dm.Registration.Registration CreateRegistration(dm.Course.CourseClass courseClass, dm.Registration.Participant participant, dm.Registration.Registration registration)
        {
            try
            {
                CourseClass _courseClass = this.CourseClassRepository.GetFirstOrDefault(x => x.ClassCode.Equals(courseClass.ClassCode));
                if (_courseClass == null)
                    return null;
                Participant _participant = this.ParticipantRepository.GetFirstOrDefault(
                    x => x.IDNumber.Equals(participant.IDNumber) && string.IsNullOrEmpty(x.CompanyID) && string.IsNullOrEmpty(participant.CompanyID)
                    ||
                    x.IDNumber.Equals(participant.IDNumber) && x.CompanyID.Equals(participant.CompanyID));
                if (_participant == null)
                    return null;

                Registration _registration = this.RegistrationRepository.GetFirstOrDefault(x => x.ClassID.Equals(_courseClass.ClassID) && x.ParticipantID.Equals(_participant.ParticipantID));
                if (_registration != null)
                    return null;
                _registration = new Registration();
                _registration.RegistrationID = Guid.NewGuid().ToString();
                _registration.ParticipantID = _participant.ParticipantID;
                _registration.ClassID = _courseClass.ClassID;
                _registration.Sponsorship = registration.Sponsorship.Equals("Self", StringComparison.OrdinalIgnoreCase) ? 1 : 2;
                //_registration.Status = (int)registration.Status;
                _registration.BillingAddress = registration.billingInfo.Address;
                _registration.BillingAddressCountry = registration.billingInfo.Country;
                _registration.BillingAddressPostalCode = registration.billingInfo.PostalCode;
                _registration.BillingPersonName = registration.billingInfo.PersonName;
                _registration.DietaryRequirement = registration.DietaryRequirement;
                _registration.OrganizationSize = registration.OrganizationSize;
                _registration.RegisterOn = DateTime.Now;
                this.RegistrationRepository.Add(_registration);
                unitOfWork.Commit();

                return this.GetRegistrationByRegID(_registration.RegistrationID);
            }
            catch { }
            return null;
        }

        public bool EditRegistration(dm.Registration.Registration registration)
        {
            try
            {
                Registration _registration = this.RegistrationRepository.GetFirstOrDefault(x => x.RegistrationID.Equals(registration.RegID));
                _registration.Sponsorship = registration.Sponsorship.Equals("Self", StringComparison.OrdinalIgnoreCase) ? 1 : 2;
                _registration.Status = (int)registration.Status;
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
                Registration _registration = this.RegistrationRepository.GetFirstOrDefault(x => x.RegistrationID.Equals(registration.RegID));

                this.RegistrationRepository.Delete(_registration);

                unitOfWork.Commit();
                return true;
            }
            catch { }
            return false;
        }


        public dm.Registration.Registration GetRegistrationByRegID(string RegID)
        {
            Registration _registration = this.RegistrationRepository.GetFirstOrDefault(x => x.RegistrationID.Equals(RegID));
            if (_registration == null)
                return null;
            Participant _participant = this.ParticipantRepository.GetFirstOrDefault(x => x.ParticipantID.Equals(_registration.ParticipantID));
            if (_registration != null)
            {
                return new dm.Registration.Registration(
                            GetCourseClassByClassID(_registration.ClassID),
                            new dm.Registration.Participant()
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
                            }
                            )
                        {
                            RegID = _registration.RegistrationID,
                            Status = (dm.RegistrationStatus)_registration.Status,
                            billingInfo = new dm.Registration.Billing()
                            {
                                PersonName = _registration.BillingPersonName,
                                Address = _registration.BillingAddress,
                                Country = _registration.BillingAddressCountry,
                                PostalCode = _registration.BillingAddressPostalCode
                            },
                            Sponsorship = _registration.Sponsorship == 1 ? "Self" : "Company",
                            DietaryRequirement = _registration.DietaryRequirement,
                            OrganizationSize = _registration.OrganizationSize
                        };
            }
            return null;
        }

        public dm.Registration.Registration GetLastRegistrationByParticipantID(string participantID)
        {
            Participant _participant = this.ParticipantRepository.GetFirstOrDefault(x => x.ParticipantID.Equals(participantID) && string.IsNullOrEmpty(x.CompanyID));
            if (_participant == null)
            {
                return null;
            }
            Registration _registration = this.RegistrationRepository.GetWhere(x => x.ParticipantID.Equals(participantID)).OrderByDescending(x => x.RegisterOn).FirstOrDefault();

            if (_registration != null)
            {

                return new dm.Registration.Registration(
                            GetCourseClassByClassID(_registration.ClassID),
                            new dm.Registration.Participant()
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
                            }
                            )
                {
                    RegID = _registration.RegistrationID,
                    Status = (dm.RegistrationStatus)_registration.Status,
                    billingInfo = new dm.Registration.Billing()
                    {
                        PersonName = _registration.BillingPersonName,
                        Address = _registration.BillingAddress,
                        Country = _registration.BillingAddressCountry,
                        PostalCode = _registration.BillingAddressPostalCode
                    },
                    Sponsorship = _registration.Sponsorship == 1 ? "Self" : "Company",
                    DietaryRequirement = _registration.DietaryRequirement,
                    OrganizationSize = _registration.OrganizationSize
                };
            }
            return null;
        }

        public dm.Registration.Registration GetLastRegistrationByHR(string participantID, string companyID)
        {
            Participant _participant = this.ParticipantRepository.GetFirstOrDefault(x => x.ParticipantID.Equals(participantID) && x.CompanyID.Equals(companyID));
            if (_participant == null)
            {
                return null;
            }
            Registration _registration = this.RegistrationRepository.GetWhere(x => x.ParticipantID.Equals(participantID)).OrderByDescending(x => x.RegisterOn).FirstOrDefault();

            if (_registration != null)
            {

                return new dm.Registration.Registration(
                            GetCourseClassByClassID(_registration.ClassID),
                            new dm.Registration.Participant()
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
                            }
                            )
                {
                    RegID = _registration.RegistrationID,
                    Status = (dm.RegistrationStatus)_registration.Status,
                    billingInfo = new dm.Registration.Billing()
                    {
                        PersonName = _registration.BillingPersonName,
                        Address = _registration.BillingAddress,
                        Country = _registration.BillingAddressCountry,
                        PostalCode = _registration.BillingAddressPostalCode
                    },
                    Sponsorship = _registration.Sponsorship == 1 ? "Self" : "Company",
                    DietaryRequirement = _registration.DietaryRequirement,
                    OrganizationSize = _registration.OrganizationSize
                };
            }
            return null;
        }

        public List<dm.Registration.Participant> GetParticipantListByCourse(dm.Course.Course course, DateTime date)
        {
            List<CourseClass> _courseClassList = this.CourseClassRepository.GetWhere(x => x.CourseCode.Equals(course.Code) 
                && x.StartDate.Year == date.Year
                && x.StartDate.Month==date.Month
                && x.StartDate.Day==date.Day).ToList();
            if (_courseClassList == null || _courseClassList.Count != 1)
                return null; // no such class or more than one class found
            CourseClass _courseClass = _courseClassList.FirstOrDefault();
            IQueryable<Registration> _registrationList = this.RegistrationRepository.GetWhere(x => x.ClassID.Equals(_courseClass.ClassID));

            IQueryable<Participant> _participantlistall = this.ParticipantRepository.GetAll();

            List<Participant> _participantlist = _participantlistall.Join(_registrationList, p => p.ParticipantID, r => r.ParticipantID, (p, r) => p).ToList();

            if (_participantlist != null)
            {
                return (from _participant in _participantlist
                        select new dm.Registration.Participant()
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
                        }).ToList();
            }
            return null;
        }

        #region Helper
        public dm.Course.CourseClass GetCourseClassByClassID(string classID)
        {
            CourseClass _courseClass = this.CourseClassRepository.GetFirstOrDefault(x => x.ClassID.Equals(classID));

            try
            {
                return GetCourseClassByCode(_courseClass.ClassCode);
            }
            catch (Exception e)
            {
            }
            return null;
        }

        public dm.Course.CourseClass GetCourseClassByCode(string classCode)
        {
            try
            {
                CourseClass _courseClass = this.CourseClassRepository.GetFirstOrDefault(x => x.ClassCode.Equals(classCode));

                if (_courseClass != null)
                {
                    Course _course = this.CourseRepository.GetFirstOrDefault(x => x.CourseCode.Equals(_courseClass.CourseCode));
                    if (_course != null)
                    {
                        Instructor _instructor = this.InstructorRepository.GetFirstOrDefault(x => x.InstructorID.Equals(_course.InstructorID));
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
                                            Instructor = new dm.CourseInstructor()
                                            {
                                                ID = _instructor.InstructorID,
                                                Name = _instructor.InstructorName
                                            },
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
            }
            catch (Exception ex)
            {
                //
            }
            return null;
        }
        #endregion
    }
}
