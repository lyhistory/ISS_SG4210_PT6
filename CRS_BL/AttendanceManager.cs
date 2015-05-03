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
        public Attendance CreateAttendance(CourseClass cls)
        {
            return null;
        }

        public bool SaveAttendance(Attendance attendance)
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
