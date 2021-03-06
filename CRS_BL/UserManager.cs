﻿using CRS_DAL.Repository;
using nus.iss.crs.dm;
using nus.iss.crs.dm.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    public class UserManager
    {
        private ISession _Session;
        static UnitOfWork unitOfWork = new UnitOfWork();
        public UserManager(ISession session)
        {
            _Session = session;
        }
        internal  UserManager()
        {
        }

        private void AssignRole(User user, UserRole role)
        {
            UserExt ext = new UserExt(user);
            ext.AssignRole(role);
        }

        public  User CreateIndIndividualUser(User user)
        {
            user.Password = GenerateRandomPassword();
            return unitOfWork.UserService.CreateIndIndividualUser(user);
        }
        public dm.User GetStaffByUserid(string userid)
        {
            return unitOfWork.UserService.GetStaffByUserid(userid);
        }
        public bool EditStaff(dm.User staff)
        {
            return unitOfWork.UserService.EditStaff(staff);
        }
        public  bool CreateStaff(User user)
        {
            return unitOfWork.UserService.CreateStaff(user);
        }
        public  bool CreateHRUser(User user)
        {
            return unitOfWork.UserService.CreateHRUser(user);
        }
        public  bool CreateHRUser(User user, Company_DM company)
        {
            return unitOfWork.UserService.CreateHRUser(user,company);
        }

        public  bool CreateCompany(Company_DM company)
        {
            return unitOfWork.UserService.CreateCompany(company);
        }

        public  Company_DM GetCompanyByID(string companyID)
        {
            return unitOfWork.UserService.GetCompanyByID(companyID);
        }
        public  Company_DM GetCompanyByUEN(string companyUEN)
        {
            return unitOfWork.UserService.GetCompanyByUEN(companyUEN);
        }
        public Company_DM GetCompanyByName(string companyName)
        {
            return unitOfWork.UserService.GetCompanyByName(companyName);
        }

        public  List<Company_DM> GetCompanyList()
        {
            return unitOfWork.UserService.GetCompanyList();
        }


        public  User LoginUser(string loginID, string password)
        {
            return unitOfWork.UserService.LoginUser(loginID, password);
        }

        public  User LoginStaff(string loginID, string password)
        {
            return unitOfWork.UserService.LoginStaff(loginID, password);
        }

        public  List<User> GetUserList()
        {
            return unitOfWork.UserService.GetUserList(); 
        }

        /// <summary>
        /// update, disable/enable, reset password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public  bool EditUser(User user)
        {
            return unitOfWork.UserService.EditUser(user);
        }

        public  bool ResetPassword(string usertype,string loginId,string oldpassword,string newpassword)
        {
            return unitOfWork.UserService.ResetPassword(usertype,loginId, oldpassword,newpassword);
        }

        public  string GenerateRandomPassword()
        {
            string password = new Random().Next(1000,9999).ToString();
            return password;
        }

        public  User GetIndividualUserByIDNumber(string idNumber)
        {
            return unitOfWork.UserService.GetIndividualUserByIDNumber(idNumber);
        }
        public  User GetHRUserByLoginID(string loginID)
        {
            return unitOfWork.UserService.GetHRUserByLoginID(loginID);
        }
        public  dm.CompanyHR_DM GetCompanyHRByLoginID(string loginID)
        {
            return unitOfWork.UserService.GetCompanyHRByLoginID(loginID);
        }

        public List<dm.User> GetCourseAdminList()
        {
            return unitOfWork.UserService.GetCourseAdminList();
        }
    }
}
