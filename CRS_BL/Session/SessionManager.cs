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

        private const int SESSION_TIME = 1800000;   //timeout half an hour 30 * 60 * 1000
        private static Thread autoDestoryTimeoutSessionThread;
        private static SessionManager theOnlySessionManager = null;

        private SessionManager() { }

        public static SessionManager getSessionManager()
        {
            if (SessionManager.theOnlySessionManager == null)
                SessionManager.theOnlySessionManager = new SessionManager();
            return SessionManager.theOnlySessionManager;
        }

        public void addSession(ISession session)
        {
            // start a new thread to monitor & destory session if it is timeout
            if (autoDestoryTimeoutSessionThread == null)
            {
                autoDestoryTimeoutSessionThread = new Thread(destoryTimeoutSession);
                autoDestoryTimeoutSessionThread.Start();
            }

            sessionList.Add(session);
        }

        private static void destoryTimeoutSession() 
        {
            while (true) 
            {
                //hang up for 1 min 60 * 1000
                Thread.Sleep(60000);

                DateTime now = DateTime.Now;
                //var timeoutSessions = sessionList.Where(session => (now - session.).Seconds > SESSION_TIME)
            }
        }

        public ISession getSession(string sessionName) 
        {
            ISession session = new SessionImplement();

           

            return session;
        }
    }
}
