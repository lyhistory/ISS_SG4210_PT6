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
        private ISession _Session;

        public ReportManager(ISession session)
        {
            _Session = session;
        }
        internal ReportManager()
        {
        }

        public List<ParticipantAttendance> GetAttendanceReport(string classCode)
        {
            if (string.IsNullOrEmpty(classCode))
                return null;
            return unitOfWork.AttendanceService.GetUserAttendancesByClassCode(classCode);
        }

        public List<ParticipantAttendance> GetUserAttendances(string classCode, DateTime date)
        {
            if (string.IsNullOrEmpty(classCode))
                return null;
            return unitOfWork.AttendanceService.GetUserAttendancesByClassCode(classCode, date);
        }

        public List<ParticipantAttendance> GetUserAttendancesByCourseCode(string courseCode)
        {
            if (string.IsNullOrEmpty(courseCode))
                return null;
            return unitOfWork.AttendanceService.GetUserAttendancesByCourseCode(courseCode);
        }

        public List<ParticipantAttendance> GetUserAttendancesByCourseCode(string courseCode, DateTime date)
        {
            if (string.IsNullOrEmpty(courseCode))
                return null;
            return unitOfWork.AttendanceService.GetUserAttendancesByCourseCode(courseCode, date);
        }
    }
}
