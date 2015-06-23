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
    public interface ICRSBusinessFacade 
    {
        bool RegistrateCourse(Registration registration, string companyName, string participantID, string courseCode, DateTime dateFrom, DateTime dateTo);

        string SubmitAttendance(string studentIDNo, AttendanceStatus status, string remark, string courseCode, DateTime dateFrom, DateTime dateTo);

        List<Participant> GetStudents(string courseCode, DateTime dateFrom, DateTime dateTo);

        List<Participant> GetEmployees(string companyName); 

        List<Course> GetCourses(DateTime dateFrom, DateTime dateTo);
    }
}
