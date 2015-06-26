using CRS_DAL.Repository;
using nus.iss.crs.dm.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    public class ParticipantManager
    {
        static UnitOfWork unitOfWork = new UnitOfWork();

        internal ParticipantManager() { }
        internal ParticipantManager(ISession session) 
        {
            //if (session.GetCurrentUser().GetRole() == null) 
            //{
            //    throw new Exception("No permission.");
            //}
        }
        public List<Participant> GetParticipants(string companyName)
        {
            return unitOfWork.CourseRegistrationService.GetEmployeeListByCompanyName(companyName);
        }

        public void CreateParticipantByHR(Participant participant)
        { }

        public Participant GetParticipant(string idNumber, string companyID)
        {
            return unitOfWork.CourseRegistrationService.GetParticipantByIDNumber(idNumber, companyID);
        }
        public Participant GetParticipant(string IDNumber)
        {
            //individual participant, not for HR
            return unitOfWork.CourseRegistrationService.GetParticipantByIDNumber(IDNumber, "");
        }
        public Participant GetParticipantByParticipantID(string participantID)
        {
            //individual participant, not for HR
            return unitOfWork.CourseRegistrationService.GetParticipantByParticipantID(participantID);
        }

        public bool EditPariticipant(Participant participant)
        {
            return unitOfWork.ParticipantService.EditPariticipant(participant);
        }
    }   
}
