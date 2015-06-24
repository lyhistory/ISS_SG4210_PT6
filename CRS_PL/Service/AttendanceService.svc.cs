using nus.iss.crs.bl;
using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace nus.iss.crs.pl.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AttendanceService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AttendanceService.svc or AttendanceService.svc.cs at the Solution Explorer and start debugging.
    public class AttendanceService : IAttendanceService
    {
        ICRSBusinessFacade facadeObj = new CRSBusinessFacade();
        public string SubmitAttendance(string participantID, AttendanceStatus status, string remark, string courseCode, DateTime dateFrom, DateTime dateTo)
        {
            return facadeObj.SubmitAttendance(participantID, status, remark, courseCode, dateFrom, dateTo);            
        }

        public List<dm.Registration.Participant> GetStudents(string courseCode, DateTime dateFrom, DateTime dateTo)
        {
            return facadeObj.GetStudents(courseCode, dateFrom, dateTo);
        }
    }
}
