﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl.Session
{
    public class SessionFactory
    {
        public static ISession CreateSession()
        {
            ISession session =  new SessionImplement();
            SessionManager.SingletonManager().AddSession(session);
            return session;
        }
    }
}
