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
        internal AttendanceManager() { }
        internal AttendanceManager(ISession session) 
        {
            if (session.GetCurrentUser().GetRole() == null) 
            {
                throw new Exception("No permission.");
            }
        }
        public Attendance CreateAttendance(CourseClass cls)
        {
            return null;
        }

        public bool SaveAttendance(Attendance attendance)
        {
            return false;
        }

        public bool SaveParticipantAttendance(ParticipantAttendance individualAttendance)
        {
            return false;
        }

        public List<ParticipantAttendance> GetUserAttendances(Participant participant)
        {
            return null;
        }

        public List<ParticipantAttendance> GetUserAttendances(Participant participant, CourseClass cls)
        {
            return null;
        }
    }
}
