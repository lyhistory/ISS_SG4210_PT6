﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.dm.Course
{
    public class CourseCalendar
    {
        private List<CourseClass> courseClass;
        public DateTime date { get; set; }

        public bool isHoliday()
        {
            throw new NotImplementedException();
        }
    }
}
