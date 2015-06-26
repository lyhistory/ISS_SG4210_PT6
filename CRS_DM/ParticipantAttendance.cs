using nus.iss.crs.dm.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm
{
    public class ParticipantAttendance
    {
        public string ClassCode { get; set; }
        public DateTime ClassDate { get; set; }

        public Participant Attendant { get; set; }
        public AttendanceStatus Status { get; set; }
        
        
        public string Remark { get; set; }

        public Course.Course CourseObj { get; set; }
    }
}
