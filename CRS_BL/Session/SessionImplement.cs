using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl.Session
{
    public class SessionImplement:ISession
    {
        public string sessionID;
        public DateTime lastUpdateTime;
        User currentUser;
        private AttendanceManager attendanceManager = null;
        private CourseManager courseManager = null;
        private CourseRegistrationManager courseRegistrationManager = null;
        private ParticipantManager participantManager = null;
        private ReportManager reportManager = null;
        private UserManager userManager = null;
        private ClassManager classManager = null;

        public SessionImplement() 
        {
            sessionID = Guid.NewGuid().ToString();
            lastUpdateTime = DateTime.Now;
            currentUser = null;
        }

        public string GetSessionID()
        {
            return sessionID;
        }

        public DateTime GetLastUpdateTime() 
        {
            return lastUpdateTime;
        }

        public dm.User GetCurrentUser()
        {
            return this.currentUser;
        }

        public bool Login()
        {
            //throw new NotImplementedException();
            return true;
        }

        public bool Login(LogingStrategy strategy)
        {
            //throw new NotImplementedException();
            LoginManager loginManager = new LoginManager();
            currentUser = loginManager.Login(strategy);

           if (currentUser == null)
               return false;
           else
               return true;
        }

        public bool IsValid()
        {
            //throw new NotImplementedException();
            return true;
        }

        public void Release()
        {
            //throw new NotImplementedException();
        }

        public CourseManager CreateCourseManager()
        {
            if (courseManager == null)
            {
                courseManager = new CourseManager(this);
            }
            return courseManager;
        }

        public CourseRegistrationManager CreateCourseRegistrationManager()
        {
            if (courseRegistrationManager == null)
            {
                courseRegistrationManager = new CourseRegistrationManager(this);
            }
            return courseRegistrationManager;
        }

        public ClassManager CreateClassManager()
        {
            if (classManager == null)
            {
                classManager = new ClassManager(this);
            }
            return classManager;
        }

        public AttendanceManager CreateAttendanceManager()
        {
            if (attendanceManager == null)
            {
                attendanceManager = new AttendanceManager(this);
            }
            return attendanceManager;
        }

        public ParticipantManager CreateParticipantManager()
        {
            if (participantManager == null)
            {
                participantManager = new ParticipantManager(this);
            }
            return participantManager;
        }

        public ReportManager CreateReportManager()
        {
            if (reportManager == null)
            {
                reportManager = new ReportManager(this);
            }
            return reportManager;
        }

        public UserManager CreateUserManager() {
            if (userManager == null)
            {
                userManager = new UserManager(this);
            }
            return userManager;
        }
    }
}
