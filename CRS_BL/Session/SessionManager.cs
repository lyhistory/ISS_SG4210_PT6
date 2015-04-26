using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nus.iss.crs.bl.Session
{
    internal class SessionManager
    {
        public static List<ISession> sessionList = new List<ISession>();
        //timeout half an hour 30 * 60 * 1000
        private const int SESSION_TIME = 1800000;
        // start a new thread to monitor & destory session if it is timeout
        private static Thread AutoDestoryTimeoutSessionThread;
        private static SessionManager sessionManager = null;

        private SessionManager()
        { }

        public static SessionManager SingletonManager()
        {
            if (sessionManager == null)
                sessionManager = new SessionManager();
            return sessionManager;
        }

        public void AddSession(ISession session)
        {
            sessionList.Add(session);
        }

        private static void DestoryTimeoutSession() 
        {
            //hang up for 1 min 60 * 1000
            Thread.Sleep(60000);

            DateTime now = DateTime.Now;
            //var OldSessions = sessionList.Where(session => (now - session.lastUpdateTime).Seconds > SESSION_TIME)
        }
    }
}
