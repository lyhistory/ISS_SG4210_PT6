using CRS_DAL.Repository;
using nus.iss.crs.dm.Course;
using nus.iss.crs.dm.Registration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    public class ClassManager
    {
        static UnitOfWork unitOfWork = new UnitOfWork();

        internal ClassManager() { }
        internal ClassManager(ISession session) 
        {
            //if (session.GetCurrentUser().GetRole() == null) 
            //{
            //    throw new Exception("No permission.");
            //}
        } 

        public bool CreateCourseClass(CourseClass courseClass)
        {
            if (courseClass.GetCourse() != null)
            {
                return unitOfWork.ClassService.CreateCourseClass(courseClass);
            }
            return false;
        }

        public bool CloseCourseClass(CourseClass courseClass)
        {
            courseClass.Status = ClassStatus.Close;
            return unitOfWork.ClassService.ChangeCourseClassStatus(courseClass);
        }

        public bool ConfirmCourseClass(CourseClass courseClass)
        {
            courseClass.Status = ClassStatus.Confirmed;
            return unitOfWork.ClassService.ChangeCourseClassStatus(courseClass);
        }

        public bool CancelCourseClass(CourseClass courseClass)
        {
            courseClass.Status = ClassStatus.Canceled;
            return unitOfWork.ClassService.ChangeCourseClassStatus(courseClass);
        }

        public bool ToConfirmCourseClass(CourseClass courseClass)
        {
            courseClass.Status = ClassStatus.ToConfirm;
            return unitOfWork.ClassService.ChangeCourseClassStatus(courseClass);
        }

        public bool AdjustCourseClassSchedule(CourseClass courseClass, DateTime startDate, DateTime endDate)
        {
            return unitOfWork.ClassService.EditCourseClassDate(courseClass, startDate, endDate);
        }

        public bool EditCourseClass(CourseClass courseClass)
        {
            return unitOfWork.ClassService.EditCourseClass(courseClass);

        }
        public CourseClass GetCourseClassByCode(string classCode)
        {
            return unitOfWork.ClassService.GetCourseClassByCode(classCode);
        }

        public List<Participant> GetCourseClassParticipantList(CourseClass courseClass)
        {
            return unitOfWork.ClassService.GetCourseClassParticipantList(courseClass);
        }

        public DateTime AutoGenerateCourseClassEndDate(Course course, DateTime startDate)
        {
            DateTime tempDate = new DateTime();
            int duration = course.Duration;

            tempDate = startDate;
            while(duration-- > 0)
            {
                tempDate = tempDate.AddDays(1);
                while(tempDate.DayOfWeek == DayOfWeek.Saturday || tempDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    tempDate = tempDate.AddDays(1);
                }
            }

            foreach(DateTime holiday in SingaporeHolidaySchedule(tempDate.Year))
            {
                if (holiday >= startDate && holiday <= tempDate)
                {
                    tempDate = tempDate.AddDays(1);
                }
            }

            return tempDate;
        }

        /// <summary>
        /// Holiday List for New Year's Day,Chinese New Year,Good Friday,Labour Day,Vesak Day,Hari Raya Puasa,National Day,Hari Raya Haji,Deepavali,Christmas Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<DateTime> SingaporeHolidaySchedule(int year)
        {
            List<DateTime> holidayList = new List<DateTime>();

            DateTime newYearDay = AdjustWeekendHoliday(new DateTime(year, 1, 1,0,0,0).Date);

            ChineseLunisolarCalendar clsc = new ChineseLunisolarCalendar();
            DateTime chineseNewYearDate = clsc.ToDateTime(year, 1, 1,0,0,0,0);

            DateTime goodFriday = AdjustWeekendHoliday(EasterSunday(year).AddDays(-2));

            DateTime labourDay = AdjustWeekendHoliday(new DateTime(year, 5, 1, 0, 0, 0).Date);
            DateTime nationalDay = AdjustWeekendHoliday(new DateTime(year, 8, 9, 0, 0, 0).Date);
            DateTime christmasDay = AdjustWeekendHoliday(new DateTime(year, 12, 25, 0, 0, 0).Date);

            
            return holidayList;
        }

        public DateTime AdjustWeekendHoliday(DateTime holiday)
        {
            if(holiday.DayOfWeek == DayOfWeek.Sunday)
            {
                return holiday.AddDays(1);
            }

            return holiday;
        }

        /// <summary>
        ///get easter day for calculating good friday 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DateTime EasterSunday(int year)
        {
            int day = 0;
            int month = 0;

            int g = year % 19;
            int c = year / 100;
            int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            return new DateTime(month, day, year);
        }
    }
}
