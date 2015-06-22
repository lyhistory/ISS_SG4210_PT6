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
        internal ParticipantManager() { }
        internal ParticipantManager(ISession session) 
        {
            if (session.GetCurrentUser().GetRole() == null) 
            {
                throw new Exception("No permission.");
            }
        }
        public List<Participant> GetParticipants(string companyName)
        {
            return null;
        }

        public void CreateParticipantByHR(Participant participant)
        { }

        public Participant GetParticipant(string IDNumber, string companyName)
        {
            return null;
        }
        public Participant GetParticipant(string IDNumber)
        {
            //individual participant, not for HR
            return null;
        }




    }   
}
