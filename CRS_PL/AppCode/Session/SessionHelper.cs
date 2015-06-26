using nus.iss.crs.bl;
using nus.iss.crs.bl.Session;
using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
/*
 *AUTHOR: LIU YUE
 * */
namespace nus.iss.crs.pl.AppCode.Session
{
    public class SessionHelper
    {
        private static ISession bLSession = null;
        public static User Current
        {
            get
            {
                if (HttpContext.Current.Session != null)
                {
                    return HttpContext.Current.Session[CRSConstant. CRS_NUS_ISS] as User;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[CRSConstant.CRS_NUS_ISS] = value;
            }
        }
        public static void SetSession(User user)
        {
            Current = user;
        }

        public static ISession BLSession
        {
            get
            {
                bLSession = (ISession)HttpContext.Current.Session[CRSConstant.BLSessionKey];
                if (bLSession == null || !bLSession.IsValid())
                {
                    //redirect to login page or create a new session 
                    bLSession = SessionFactory.CreateSession();
                }
                return bLSession;
            }
        }

        public static void ReleaseBLSession()
        {
            bLSession = (ISession)HttpContext.Current.Session[CRSConstant.BLSessionKey];
            if (bLSession != null)
            {
                bLSession.Release();
            }

            bLSession = null;

        }

        public static void ReleaseSession()
        {
            try
            {
                if (HttpContext.Current != null)
                {
                    ReleaseBLSession();

                    if (HttpContext.Current.Session != null)
                    {
                        HttpContext.Current.Session.Clear();
                        HttpContext.Current.Session.Abandon();
                    }
                    FormsAuthentication.SignOut();
                }
            }
            catch { }
            
        }
    }
}