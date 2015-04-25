using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl.Session
{
    internal class SessionManager
    {
        int sessionTime = 1800000;//30 * 60 * 1000;//half an hour
        List<ISession> sessions = new List<ISession> ();

        //TODO: start a new thread to monitor session 

        private static SessionManager manager = null;
        private SessionManager()
        { }

        public static SessionManager SingltonManager()
        {
            if (manager == null)
                manager = new SessionManager();
            return manager;
        }
        public void AddSession(ISession session)
        {
            sessions.Add(session);
        }
    }
}
