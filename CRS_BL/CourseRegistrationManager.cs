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
        public Participant CreateEmployee()
        {
            //save
            Participant employee = new Participant();
            return employee;
        }

        public bool SaveEmployee(Participant employee)
        {
            return false;
        }

        //View course details


        public List<Registration> GetRegistrationList(CourseClass cls)
        {
            return null;
        }

        public List<Registration> GetRegistrationList(User user)
        {
            return null;
        }

        public List<Registration> GetRegistrationList(Company company)
        {
            return null;
        }


        /// <summary>
        /// Edit, Cancel
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        public bool EditRegistration(Registration registration)
        {
               
            return false;
        }

        public bool SaveRegistration(Registration registration)
        {
            return false;
        }

        public bool MoveRegistration(Registration registration)
        {
            return false;
        }


        public Registration GetRegistration(string RegID)
        {
            return null;
        }


    }
}
