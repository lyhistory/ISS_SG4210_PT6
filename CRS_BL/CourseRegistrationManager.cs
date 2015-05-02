using nus.iss.crs.dm;
using nus.iss.crs.dm.Course;
using nus.iss.crs.dm.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    class CourseRegistrationManager
    {
        internal CourseRegistrationManager() { }
        internal CourseRegistrationManager(ISession session)
        {
            //only course admin can do  
            if (session.GetCurrentUser().GetRole() == null)
            {
                throw new Exception("No permisison");
            }
        }

        //how to find out the list of selected course?
        //public List<Course> GetSelectedCourseList()
        //{
        //    List<Course> courseList = new List<Course>();
        //    return courseList;
        //}

        //public bool RegisterCourse(CourseClass courseClass)
        //{
        //    //Registration(courseClass,)
        //    return false;
        //}

        //get employee list by HR
        public List<Participant> GetEmployeeList(string companyID) 
        {
            List<Participant> participantList = new List<Participant>();
            return participantList;
        }
        
        //Populate employee details by ID Number
        public Participant GetEmployeeDetail(string idNumber)
        {
            Participant employee = new Participant();
            return employee;
        }

        //Create new employee
        public bool createEmployee(Participant employee)
        {
            //save
            return false;
        }

        //View course details

    }
}
