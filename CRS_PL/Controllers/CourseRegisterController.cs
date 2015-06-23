using CRS_COMMON.Logs;
using nus.iss.crs.bl;
using nus.iss.crs.dm;
using nus.iss.crs.dm.Course;
using nus.iss.crs.dm.Registration;
using nus.iss.crs.pl.AppCode.Filter;
using nus.iss.crs.pl.AppCode.FormAuthentication;
using nus.iss.crs.pl.AppCode.Session;
using nus.iss.crs.pl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nus.iss.crs.pl.Controllers
{
    public class CourseRegisterController : BaseController
    {
        private static LogHelper _log = LogHelper.GetLogger(typeof(CourseRegisterController));

         UserManager manager = null;

         public CourseRegisterController()
        {
            manager = new UserManager(BLSession);
        }

         #region Individual Register
         // GET: CourseRegister
        public ActionResult IndividualRegister(string code,string message="")
        {
            CourseManager courseManager = this.BLSession.CreateCourseManager();

            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.Message = message;
            }
            CRForm crform = GetModelForCourseRegister( "", true);
            var model = courseManager.GetCourseByCode(code);
            if (model == null)
            {
                ViewBag.Message = "This course currently Not Available!";
            }else{
                crform.CourseTitle = model.CourseTitle;
                crform.CourseCode = model.Code;

                List<SelectItem> classlist = new List<SelectItem>();
                foreach (var item in model.CourseClasses)
                {
                    classlist.Add(new SelectItem() { Value = item.ClassCode, Name = string.Format("{0}-{1}", item.StartDate.ToString("MMM dd, yyyy"), item.EndDate.ToString("MMM dd, yyyy")) });
                }
                ViewBag.ClassList = classlist;
            }
            

            return View(crform);
        }

        [HttpPost]
        public ActionResult PostIndividualRegister(CRForm crform)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("IndividualRegister", new { code = crform.CourseCode, message = "something wrong!!!" });
            }
            string IDNumber = crform.IDNumber;
            if (SessionHelper.Current == null)
            {
                var user = manager.GetIndividualUserByIDNumber(IDNumber);
                if (user != null)
                {   //if exists ask him to login!
                    //string toPage = "?code="+code;
                    return Json(new { Code = -100, Message = "user exist,please login" });
                }
                else
                {
                    //auto register and login
                    user = manager.CreateIndIndividualUser(new dm.User() { LoginID = IDNumber });
                    user.RoleName = "User";
                    _log.Debug(string.Format("Your userid:{0},password:{1}", user.LoginID, user.Password));
                    SessionHelper.SetSession(user);
                    CRSFormsAuthentication<User>.SetAuthCookie(user.LoginID, user, true);
                }
            }

            ClassManager classManager = this.BLSession.CreateClassManager();
            CourseRegistrationManager courseRegistrationManager = this.BLSession.CreateCourseRegistrationManager();

            CourseClass courseClass = classManager.GetCourseClassByCode(crform.ClassCode);

            Participant participant = null;
            participant = courseRegistrationManager.GetIndividualParticipantByIDNumber(IDNumber);
            if (participant != null) {
                participant.EmploymentStatus = crform.EmploymentStatus;
                participant.CompanyName = crform.Company;
                participant.JobTitle = crform.JobTitle;
                participant.Department = crform.Department;
                participant.OrganizationSize = crform.OrganizationSize;
                participant.SalaryRange = crform.SalaryRage;

                participant.FullName = crform.FullName;
                participant.Gender = crform.Gender;
                participant.Nationality = crform.Nationality;
                participant.DOB = crform.DateOfBirth;
                participant.EMail = crform.Email;
                participant.ContactNumber = crform.ContactNumber;
                participant.DietaryRequirement = crform.DietaryRequirement;
                courseRegistrationManager.UpdateIndividualParticipant(participant);
            }
            else
            {
                participant = courseRegistrationManager.CreateParticipant(new Participant()
                {
                    IDNumber = IDNumber,
                    CompanyID = crform.CompanyID,
                    Salutation = crform.Salutation,
                    FullName = crform.FullName,
                    Gender = crform.Gender,
                    Nationality = crform.Nationality,
                    DOB = crform.DateOfBirth,
                    EMail = crform.Email,
                    ContactNumber = crform.ContactNumber,
                    DietaryRequirement = crform.DietaryRequirement,

                    EmploymentStatus = crform.EmploymentStatus,
                    CompanyName = crform.Company,
                    JobTitle = crform.JobTitle,
                    Department = crform.Department,
                    OrganizationSize = crform.OrganizationSize,
                    SalaryRange = crform.SalaryRage
                });
            }
            Registration registration = new Registration();

            registration.Sponsorship = crform.Sponsorship;
            registration.DietaryRequirement = crform.DietaryRequirement;
            registration.OrganizationSize = crform.OrganizationSize;

            registration.billingInfo.Address = crform.BillingAddress;
            registration.billingInfo.PersonName = crform.BillingPersonName;
            registration.billingInfo.Country = crform.BillingAddressCountry;
            registration.billingInfo.PostalCode = crform.BillingAddressPostalCode;

            courseRegistrationManager.CreateRegistration(courseClass, participant, registration);


            return Json(new { Code = 1, redirectUrl = Url.Action("ViewIndividualRegister", "CourseRegister") });
        }
        [CRSAuthorize(Roles = "Individual")]
        public ActionResult ViewIndividualRegister()
        {
            if (SessionHelper.Current == null)
                return RedirectToAction("Logon", "home");

            CourseRegistrationManager courseRegistrationManager = this.BLSession.CreateCourseRegistrationManager();
            List<Registration> list = courseRegistrationManager.GetRegistrationList(SessionHelper.Current);
            return View(list);
        }
        #endregion

        #region HR Register
        [CRSAuthorize(Roles="HR")]
        public ActionResult HRRegister(string code)
        {
            if (SessionHelper.Current == null)
                return RedirectToAction("logon", "home");

            CourseManager courseManager = this.BLSession.CreateCourseManager();
            CourseRegistrationManager courseRegistrationManager = this.BLSession.CreateCourseRegistrationManager();

            var model = courseManager.GetCourseByCode(code);
            CRForm crform = new CRForm();
            if (model == null)
            {
                ViewBag.Message = "This course currently Not Available!";
            }
            else
            {
                crform.CourseTitle = model.CourseTitle;
                crform.CourseCode = model.Code;

                List<SelectItem> classlist = new List<SelectItem>();
                foreach (var item in model.CourseClasses)
                {
                    classlist.Add(new SelectItem() { Value = item.ClassCode, Name = string.Format("{0}-{1}", item.StartDate.ToString("MMM dd, yyyy"), item.EndDate.ToString("MMM dd, yyyy")) });
                }
                ViewBag.ClassList = classlist;

                Company company = manager.GetCompanyByID(SessionHelper.Current.CompanyID);
                if (company != null)
                {
                    crform.CompanyID = company.CompanyID;
                    crform.EmploymentStatus = "Regular Full Time";
                    crform.Company = company.CompanyName;

                    crform.OrganizationSize = company.OrganizationSize;
                }
            }

            List<SelectItem> employlist = new List<SelectItem>();
            var employs = courseRegistrationManager.GetEmployeeListByCompanyID(SessionHelper.Current.CompanyID);
            employlist.Add(new SelectItem() { Value = "-1", Name = "New Employee" });
            foreach (var item in employs)
            {
                employlist.Add(new SelectItem() { Value = item.IDNumber, Name = string.Format("{0}.{1}", item.Salutation, item.FullName) });
            }
            ViewBag.EmployeeList = employlist;

            return View(crform);
        }

        [HttpPost]
        public ActionResult PostHRRegister(CRForm crform)
        {
            if (!this.ModelState.IsValid)
            {
                //log 
                return Content("wrong");
            }
            string IDNumber = crform.IDNumber;
            if (SessionHelper.Current == null)
            {
                //log
                return Content("wrong");
            }

            ClassManager classManager = this.BLSession.CreateClassManager();
            CourseRegistrationManager courseRegistrationManager = this.BLSession.CreateCourseRegistrationManager();

            CourseClass courseClass = classManager.GetCourseClassByCode(crform.ClassCode);
            Participant participant = null;
            participant = courseRegistrationManager.GetParticipantByHR(IDNumber, SessionHelper.Current.CompanyID);
            if (participant != null)
            {
                participant.EmploymentStatus = crform.EmploymentStatus;
                participant.CompanyName = crform.Company;
                participant.JobTitle = crform.JobTitle;
                participant.Department = crform.Department;
                participant.OrganizationSize = crform.OrganizationSize;
                participant.SalaryRange = crform.SalaryRage;

                participant.FullName = crform.FullName;
                participant.Gender = crform.Gender;
                participant.Nationality = crform.Nationality;
                participant.DOB = crform.DateOfBirth;
                participant.EMail = crform.Email;
                participant.ContactNumber = crform.ContactNumber;
                participant.DietaryRequirement = crform.DietaryRequirement;
                courseRegistrationManager.UpdateIndividualParticipant(participant);
            }
            else
            {
                participant = courseRegistrationManager.CreateParticipant(new Participant()
                {
                    IDNumber = IDNumber,
                    CompanyID = SessionHelper.Current.CompanyID,//crform.CompanyID,
                    Salutation = crform.Salutation,
                    FullName = crform.FullName,
                    Gender = crform.Gender,
                    Nationality = crform.Nationality,
                    DOB = crform.DateOfBirth,
                    EMail = crform.Email,
                    ContactNumber = crform.ContactNumber,
                    DietaryRequirement = crform.DietaryRequirement,

                    EmploymentStatus = crform.EmploymentStatus,
                    CompanyName = crform.Company,
                    JobTitle = crform.JobTitle,
                    Department = crform.Department,
                    OrganizationSize = crform.OrganizationSize,
                    SalaryRange = crform.SalaryRage
                });
            }
            Registration registration = new Registration();

            registration.Sponsorship = crform.Sponsorship;
            registration.DietaryRequirement = crform.DietaryRequirement;
            registration.OrganizationSize = crform.OrganizationSize;

            registration.billingInfo.Address = crform.BillingAddress;
            registration.billingInfo.PersonName = crform.BillingPersonName;
            registration.billingInfo.Country = crform.BillingAddressCountry;
            registration.billingInfo.PostalCode = crform.BillingAddressPostalCode;

            courseRegistrationManager.CreateRegistration(courseClass, participant, registration);


            return Json(new { Code = 1, redirectUrl = Url.Action("ViewHRRegister", "CourseRegister") });
        }

        public ActionResult RenderCourseRegister(string courseCode,string idNumber)
        {
            if (string.IsNullOrEmpty(courseCode))
            {
                return Content("No Course Selected");
            }
            CourseManager courseManager = this.BLSession.CreateCourseManager();

            CRForm crform = null;
            if (idNumber.Equals("-1"))
            {
                crform = new CRForm();
            }
            else
            {
               crform=GetModelForCourseRegister(idNumber, false);
            }
            var model = courseManager.GetCourseByCode(courseCode);
            crform.CourseTitle = model.CourseTitle;
            crform.CourseCode = model.Code;
            List<SelectItem> classlist = new List<SelectItem>();
            foreach (var item in model.CourseClasses)
            {
                classlist.Add(new SelectItem() { Value = item.ClassCode, Name = string.Format("{0}-{1}", item.StartDate.ToString("MMM dd, yyyy"), item.EndDate.ToString("MMM dd, yyyy")) });
            }
            ViewBag.ClassList = classlist;

            return PartialView("~/views/courseregister/_courseregister.cshtml", crform);
        }
        [CRSAuthorize(Roles = "HR")]
        public ActionResult ViewHRRegister()
        {
            if (SessionHelper.Current == null)
                return RedirectToAction("Logon", "home");
            CourseRegistrationManager courseRegistrationManager = this.BLSession.CreateCourseRegistrationManager();
            List<Registration> list = courseRegistrationManager.GetRegistrationList(new Company() { CompanyID = SessionHelper.Current.CompanyID });
            return View(list);
        }
        [CRSAuthorize(Roles = "HR")]
        public ActionResult ViewCompanyEmployee()
        {
            if (SessionHelper.Current == null)
            {
                return RedirectToAction("Logon", "home");
            }

            CourseRegistrationManager courseRegistrationManager = this.BLSession.CreateCourseRegistrationManager();
            List<Participant> list = courseRegistrationManager.GetEmployeeListByCompanyID(SessionHelper.Current.CompanyID);
            return View(list);
        }
        #endregion

        #region Common View
        [CRSAuthorize(Roles = "Individual,HR")]
        public ActionResult ViewRegistrationDetail(string regid)
        {
            if (SessionHelper.Current == null)
            {
                return RedirectToAction("logon", "home");
            }
            CourseRegistrationManager courseRegistrationManager = this.BLSession.CreateCourseRegistrationManager();
            var model = courseRegistrationManager.GetRegistration(regid);
            return View(model);
        }
        #endregion

        #region Helper
        private CRForm GetModelForCourseRegister(string idnumber,bool isIndividual=false)
        {
            CRForm crform = new CRForm();
            
            Participant participant=null;
            Registration registration = null;
            if (SessionHelper.Current != null)
            {
                CourseRegistrationManager courseRegistrationManager = this.BLSession.CreateCourseRegistrationManager();
                if (isIndividual)
                { 
                    participant = courseRegistrationManager.GetIndividualParticipantByIDNumber(SessionHelper.Current.LoginID);
                    if(participant!=null)
                        registration = courseRegistrationManager.GetLastIndividualRegistrationByParticipantID(participant.ParticipantID);
                }
                else
                {
                    participant = courseRegistrationManager.GetParticipantByHR(idnumber, SessionHelper.Current.CompanyID);
                    if (participant != null)
                        registration = courseRegistrationManager.GetLastRegistrationByHR(participant.ParticipantID, SessionHelper.Current.CompanyID);
                }
            }

            if (participant != null)
            {
                crform.Salutation = participant.Salutation;
                crform.FullName = participant.FullName;
                crform.Gender = participant.Gender;
                crform.Nationality = participant.Nationality;
                crform.DateOfBirth = participant.DOB.Date;
                crform.Email = participant.EMail;
                crform.ContactNumber = participant.ContactNumber;
                crform.DietaryRequirement = participant.DietaryRequirement;

                crform.EmploymentStatus = participant.EmploymentStatus;
                crform.Company = participant.CompanyName;
                crform.JobTitle = participant.JobTitle;
                crform.Department = participant.Department;
                crform.OrganizationSize = participant.OrganizationSize;
                crform.SalaryRage = participant.SalaryRange;
            }
            
            if (registration != null)
            {
                crform.Sponsorship = registration.Sponsorship;
                crform.DietaryRequirement = registration.DietaryRequirement;
                crform.OrganizationSize = registration.OrganizationSize;
                crform.BillingAddress = registration.billingInfo.Address;
                crform.BillingPersonName = registration.billingInfo.PersonName;
                crform.BillingAddressCountry = registration.billingInfo.Country;
                crform.BillingAddressPostalCode = registration.billingInfo.PostalCode;
            }
            return crform;
        }
        #endregion

    }
}