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

        private void AssignRole(User user, UserRole role)
        {
            UserExt ext = new UserExt(user);
            ext.AssignRole(role);
        }

        public static bool CreateIndIndividualUser(User user)
        {
            user.Password = GenerateRandomPassword();
            return unitOfWork.UserService.CreateIndIndividualUser(user);
        }

        public static bool CreateStaff(User user)
        {
            return unitOfWork.UserService.CreateStaff(user);
        }

        public static bool CreateHRUser(User user, Company company)
        {
            user.Password = GenerateRandomPassword();
            return unitOfWork.UserService.CreateHRUser(user,company);
        }

        public static bool CreateCompany(Company company)
        {
            return unitOfWork.UserService.CreateCompany(company);
        }

        public static Company GetCompanyByID(string companyUEN)
        {
            return unitOfWork.UserService.GetCompanyByID(companyUEN);
        }

        public static List<Company> GetCompanyList()
        {
            return unitOfWork.UserService.GetCompanyList();
        }


        public static User LoginUser(string loginID, string password)
        {
            return unitOfWork.UserService.LoginUser(loginID, password);
        }

        public static User LoginStaff(string loginID, string password)
        {
            return unitOfWork.UserService.LoginStaff(loginID, password);
        }

        public static List<User> GetUserList()
        {
            return unitOfWork.UserService.GetUserList(); 
        }

        /// <summary>
        /// update, disable/enable, reset password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool EditUser(User user)
        {
            return unitOfWork.UserService.EditUser(user);
        }

        public static string GenerateRandomPassword()
        {
            string password = Guid.NewGuid().ToString();
            return password;
        }
    }
}
