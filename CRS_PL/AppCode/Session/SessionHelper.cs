using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*
 *AUTHOR: LIU YUE
 * */
namespace nus.iss.crs.pl.AppCode.Session
{
    public class SessionHelper
    {
        public static User Current
        {
            get
            {
                if (HttpContext.Current.Session != null)
                {
                    return HttpContext.Current.Session["CRS_NUS_ISS"] as User;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["CRS_NUS_ISS"] = value;
            }
        }
        public static void SetSession(User user)
        {
            Current = user;
        }
    }
}