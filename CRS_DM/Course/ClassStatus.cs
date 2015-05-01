using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm.Course
{
    public enum ClassStatus
    {
        New, //To be open
        Open, //allow to registrater
        Close, //close to registrator
        Confirmed, // start to run class
        Canceled, //cancel class
        Running, //active and running the course based on scheudle
        Over //finish or expired class, be in history
    }
}
