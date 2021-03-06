﻿using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    public interface ISession
    {
        void Release();
        bool IsValid();
        bool Login(LogingStrategy strategy);
        DateTime GetLastUpdateTime();

        User GetCurrentUser();
        CourseManager CreateCourseManager();
        CourseRegistrationManager CreateCourseRegistrationManager();

        ClassManager CreateClassManager();
        AttendanceManager CreateAttendanceManager();
        ParticipantManager CreateParticipantManager();
        ReportManager CreateReportManager();
        UserManager CreateUserManager();
    }
}
