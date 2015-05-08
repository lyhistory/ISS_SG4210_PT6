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
    }
}
