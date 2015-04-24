using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CRS_COMMON.Logs
{

    public class LogHelper
    {
        private ILog logger;

        static LogHelper()
        {

            string path = HttpContext.Current.Server.MapPath("/");

            log4net.Config.XmlConfigurator.Configure(new FileInfo(Path.Combine(path, "Config","log4net.xml")));
        }

        private LogHelper(Type _type)
        {
            logger = LogManager.GetLogger(_type);
        }

        public static LogHelper GetLogger(Type _type)
        {
            return new LogHelper(_type);
        }

        public void Debug(string _Message, params object[] objs)
        {
            if (logger.IsDebugEnabled)
            {
                if (objs == null || objs.Length == 0)
                {
                    logger.Debug("DEBUG:" + _Message);
                    return;
                }
                logger.Debug("DEBUG:" + string.Format(_Message, objs));
            }
        }
    }
}
