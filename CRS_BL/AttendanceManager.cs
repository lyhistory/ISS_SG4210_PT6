using CRS_DAL.Repository;
using nus.iss.crs.dm;
using nus.iss.crs.dm.Course;
using nus.iss.crs.dm.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    public class AttendanceManager
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        internal AttendanceManager() { }
        internal AttendanceManager(ISession session) 
        {
            //if (session.GetCurrentUser().GetRole() == null) 
            //{
            //    throw new Exception("No permission.");
            //}
        }

        public bool SaveParticipantAttendance(ParticipantAttendance attendance)
        {
            string participantID = attendance.Attendant.ParticipantID;
            string courseCode = attendance.CourseObj.Code;

            return unitOfWork.AttendanceService.SaveParticipantAttendance(participantID,courseCode,attendance.ClassDate,(int)attendance.Status,attendance.Remark);
        }

        public List<ParticipantAttendance> GetUserAttendances(Participant participant)
        {
            string pariticipantID = participant.ParticipantID;
            return unitOfWork.AttendanceService.GetUserAttendances(pariticipantID);
        }

        public List<ParticipantAttendance> GetUserAttendances(Participant participant, CourseClass cls)
        {
            string pariticipantID = participant.ParticipantID;
            string classCode = cls.ClassCode;
            return unitOfWork.AttendanceService.GetUserAttendances(pariticipantID, classCode);
        }

        
    }
}
