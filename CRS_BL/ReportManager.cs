using CRS_DAL.Repository;
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
        UnitOfWork unitOfWork = new UnitOfWork();

        internal ReportManager()
        { }

        internal ReportManager(ISession session)
        {
            //if (session.GetCurrentUser().GetRole() == null)
            //{
            //    throw new Exception("No permission.");
            //}
        }
        public List<ParticipantAttendance> GetAttendanceReport(CourseClass cls)
        {
            string classCode = cls.ClassCode;
            if (string.IsNullOrEmpty(classCode))
                return null;
            return unitOfWork.AttendanceService.GetUserAttendancesByClassCode(classCode);
        }

        public List<ParticipantAttendance> GetUserAttendances(CourseClass cls,DateTime date)
        {
            string classCode = cls.ClassCode;
            if (string.IsNullOrEmpty(classCode))
                return null;
            return unitOfWork.AttendanceService.GetUserAttendancesByClassCode(classCode, date);
        }
    }
}
