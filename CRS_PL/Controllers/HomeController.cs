using CRS_COMMON.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CR_PL.Controllers
{
    public class HomeController : Controller
    {
        private static LogHelper _log = LogHelper.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            _log.Debug("test about");
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}