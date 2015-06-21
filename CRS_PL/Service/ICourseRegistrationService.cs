using nus.iss.crs.dm.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace nus.iss.crs.pl.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICourseRegistrationService" in both code and config file together.
    [ServiceContract]
    public interface ICourseRegistrationService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        void RegistrateCourse(dm.Registration.Registration reg, string companyName, string participantIDNumber, string courseCode, DateTime dateFrom, DateTime dateTo);
    }
}
