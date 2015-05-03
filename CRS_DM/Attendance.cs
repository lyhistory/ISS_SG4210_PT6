using nus.iss.crs.dm.Course;
using nus.iss.crs.dm.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm
{
    public class Attendance
    {
        public CourseClass cls { get; set; }
        //public List<Participant> ParticipantList { get; set; }
        public List<ParticipantAttendance> AttendantList { get; set; }
    }
}

