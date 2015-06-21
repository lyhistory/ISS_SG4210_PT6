using nus.iss.crs.dm;
using nus.iss.crs.dm.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace nus.iss.crs.pl.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAttendanceService" in both code and config file together.
    [ServiceContract]
    public interface IAttendanceService
    {
        [OperationContract]
        List<Participant> GetStudents(string courseCode, DateTime dateFrom, DateTime dateTo);

        [OperationContract]
        string  SubmitAttendance(string studentIDNo,AttendanceStatus status,string remark,  string courseCode, DateTime dateFrom, DateTime dateTo);
    }
}
