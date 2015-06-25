using CRS_DAL.Repository;
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
    public class CourseRegistrationManager
    {
        static UnitOfWork unitOfWork = new UnitOfWork();

        internal CourseRegistrationManager() { }
        internal CourseRegistrationManager(ISession session)
        {
            //only course admin can do  
            //tempory comment by lanxm
            //if (session.GetCurrentUser().GetRole() == null)
            //{
            //    throw new Exception("No permisison");
            //}
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
        public List<Participant> GetEmployeeListByCompanyID(string companyID) 
        {
            return unitOfWork.CourseRegistrationService.GetEmployeeListByCompanyID(companyID);
        }
        public List<Participant> GetEmployeeListByCompanyName(string companyName)
        {
            return unitOfWork.CourseRegistrationService.GetEmployeeListByCompanyName(companyName);
        }
        
        
        //Populate employee details by ID Number
        public Participant GetIndividualParticipantByIDNumber(string idNumber)
        {
            return unitOfWork.CourseRegistrationService.GetParticipantByIDNumber(idNumber);
        }
        public Participant GetParticipantByHR(string idNumber,string companyID)
        {
            if (string.IsNullOrEmpty(companyID))
            {
                return null;//not allowed to see individual
            }
            return unitOfWork.CourseRegistrationService.GetParticipantByIDNumber(idNumber,companyID);
        }

        public Participant UpdateIndividualParticipant(dm.Registration.Participant participant, string companyID = "")
        {
            return unitOfWork.CourseRegistrationService.UpdateParticipant(participant);
        }
        public Participant UpdateParticipantByHR(dm.Registration.Participant participant, string companyID)
        {
            if (string.IsNullOrEmpty(companyID))
            {
                return null;//not allowed to see individual
            }
            return unitOfWork.CourseRegistrationService.UpdateParticipant(participant,companyID);
        }
        //Create new employee
        public Participant CreateParticipant(Participant participant)
        {
            return unitOfWork.CourseRegistrationService.CreateParticipant(participant);
        }

        //View course details
        public List<Registration> GetRegistrationList(CourseClass cls)
        {
            return unitOfWork.CourseRegistrationService.GetRegistrationList(cls);
        }

        public List<Registration> GetRegistrationList()
        {
            return unitOfWork.CourseRegistrationService.GetRegistrationList();
        }

        public List<Registration> GetRegistrationListByEmployee(User user)
        {
            return unitOfWork.CourseRegistrationService.GetRegistrationListByEmployee(user);
        }

        public List<Registration> GetRegistrationListByParticipant(Participant participant)
        {
            return unitOfWork.CourseRegistrationService.GetRegistrationListByParticipant(participant);
        }

        public List<Registration> GetRegistrationListByCompany(Company_DM company)
        {
            return unitOfWork.CourseRegistrationService.GetRegistrationListByCompany(company);
        }

        /// <summary>
        /// Edit, Cancel
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        public bool EditRegistration(Registration registration)
        {
            return unitOfWork.CourseRegistrationService.EditRegistration(registration);
        }

        public bool DeleteRegistration(Registration registration)
        {
            return unitOfWork.CourseRegistrationService.DeleteRegistration(registration);
        }

        public Registration GetRegistration(string RegID)
        {
            return unitOfWork.CourseRegistrationService.GetRegistrationByRegID(RegID);
        }

        public Registration GetLastIndividualRegistrationByParticipantID(string participantID)
        {
            return unitOfWork.CourseRegistrationService.GetLastRegistrationByParticipantID(participantID);
        }
        public Registration GetLastRegistrationByHR(string participantID,string companyID)
        {
            if (string.IsNullOrEmpty(companyID))
            {
                return null;
            }
            return unitOfWork.CourseRegistrationService.GetLastRegistrationByHR(participantID,companyID);
        }

        public Registration CreateRegistration(CourseClass courseClass, Participant participant, Registration registration)
        {
            return unitOfWork.CourseRegistrationService.CreateRegistration(courseClass, participant, registration);
        }

        public List<Participant> GetParticipantListByCourse(Course course,DateTime date)
        {
            return unitOfWork.CourseRegistrationService.GetParticipantListByCourse(course, date);
        }

        public List<CourseClass> GetCourseClassWithRegisterCount(DateTime date, ClassStatus status)
        {
            if (date == null)
                return null;

            return unitOfWork.CourseRegistrationService.GetCourseClassWithRegisterCount(date, (int)status);
        }
    }
}
