using nus.iss.crs.dm;
using nus.iss.crs.dm.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    public class ReportManager
    {
        internal ReportManager()
        { }

        internal ReportManager(ISession session)
        {
            if (session.GetCurrentUser().GetRole() == null)
            {
                throw new Exception("No permission.");
            }
        }
        public Attendance GetAttendanceReport(CourseClass cls)
        {

            //get list of registration based on course clas
            //get participant list based on registion list
            //
            return null;
        }
    }
}
