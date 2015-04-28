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

        private const int SESSION_TIME = 1800;   //timeout half an hour 30 * 60s
        private static Thread autoDestoryTimeoutSessionThread;
        private static SessionManager theOnlySessionManager = null;

        private SessionManager() { }

        public static SessionManager GetSessionManager()
        {
            if (SessionManager.theOnlySessionManager == null)
                SessionManager.theOnlySessionManager = new SessionManager();
            return SessionManager.theOnlySessionManager;
        }

        public void AddSession(ISession session)
        {
            // start a new thread to monitor & destory session if it is timeout
            if (autoDestoryTimeoutSessionThread == null)
            {
                autoDestoryTimeoutSessionThread = new Thread(DestoryTimeoutSession);
                autoDestoryTimeoutSessionThread.Start();
            }

            sessionList.Add(session);
        }

        private static void DestoryTimeoutSession() 
        {
            while (true) 
            {
                //hang up for 1 min 60 * 1000
                Thread.Sleep(60000);

                DateTime now = DateTime.Now;

                var timeoutSessions = (from session in sessionList
                                       where ((now - session.GetLastUpdateTime()).Seconds > SESSION_TIME)
                                       select session).ToArray();
                
                foreach (var session in timeoutSessions)
                {
                    sessionList.Remove(session);
                }
            }
        }

        public ISession GetSession(string sessionName) 
        {
            ISession session = new SessionImplement();

           

            return session;
        }
    }
}
