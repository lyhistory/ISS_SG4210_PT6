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
    public class ParticipantService
    {
         IUnitOfWork unitOfWork;

        IRepository<Participant> ParticipantRepository;
        IRepository<Registration> RegistrationRepository;


        public ParticipantService(IUnitOfWork unitOfWork, 
            IRepository<Participant> participantRepository,IRepository<Registration> registrationRepository)
        {
            this.unitOfWork = unitOfWork;
            this.ParticipantRepository = participantRepository;
            this.RegistrationRepository = registrationRepository;
        }

        public bool EditPariticipant(dm.Registration.Participant participant)
        {
            try
            {
                Participant _participant = this.ParticipantRepository.GetFirstOrDefault(x => x.ParticipantID.Equals(participant.ParticipantID));
                if (_participant == null)
                    _participant = this.ParticipantRepository.GetFirstOrDefault(x => x.IDNumber.Equals(participant.IDNumber) && x.CompanyID.Equals(participant.CompanyID));

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

                    _participant.CompanyID = participant.CompanyID;
                    _participant.IDNumber = participant.IDNumber;
                    _participant.IsLocal = participant.IsLocal;

                    this.unitOfWork.Commit();
                    return true;
                }
            }
            catch { }

            return false;
        }
    }
}
