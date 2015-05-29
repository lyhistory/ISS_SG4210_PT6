using CRS_DAL.EF;
using CRS_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dm = nus.iss.crs.dm;
namespace CRS_DAL.Service
{
    public class UserService
    {
        IUnitOfWork unitOfWork;
        IRepository<User> userRepository;
        IRepository<Company> companyRepository;
        IRepository<CompanyHR> companyHRRepository;
        IRepository<Staff> staffRepository;

        public UserService(IUnitOfWork uow, IRepository<User> userRepository,IRepository<Staff> staffRepository, IRepository<Company> companyRepository, IRepository<CompanyHR> companyHRRepository)
        {
            this.unitOfWork = uow;
            this.userRepository = userRepository;
            this.staffRepository = staffRepository;
            this.companyRepository = companyRepository;
            this.companyHRRepository = companyHRRepository;
        }

        public dm.User GetByLoginID(string loginID)
        {
            var _user = userRepository.GetFirstOrDefault(g => g.LoginID == loginID);
            if (_user != null)
            {
                return new dm.User()
                {
                    UserID = _user.UserID,
                    LoginID=_user.LoginID,
                    Password = _user.Password,
                    RoleName = _user.UserType.Equals("2") ? "HR" : "User"
                };
            }
            return null;
        }

        public bool CreateIndIndividualUser(dm.User user)
        {
            try
            {
                if (!ExistsUser(user.UserID))
                {

                    userRepository.Add(new User()
                    {
                        UserID = Guid.NewGuid().ToString(),
                        LoginID = user.LoginID,
                        Password = user.Password,
                        UserType = 1
                    });

                    this.unitOfWork.Commit();
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }
        public bool CreateHRUser(dm.User user,dm.Company company)
        {
            try
            {
                if (!ExistsUser(user.LoginID))
                {
                    //INSERT TABLE USER
                    userRepository.Add(new User()
                    {
                        UserID = Guid.NewGuid().ToString(),
                        LoginID = user.LoginID,
                        Password = user.Password,
                        UserType = user.RoleName.Equals("HR") ? 2 : 1
                    });

                    Company _company;
                    //INSERT TABLE COMPANY
                    if (!ExistsCompany(company.CompanyUEN))
                    {
                        _company = new Company()
                        {
                            CompanyID = Guid.NewGuid().ToString(),
                            CompanyName = company.CompanyName,
                            CompanyUEN = company.CompanyUEN,
                            OrganizationSize = company.OrganizationSize,
                            CompanyAddress = company.CompanyAddress,
                            Country = company.Country,
                            PostalCode = company.PostalCode
                        };
                        companyRepository.Add(_company);
                    }
                    else
                    {
                        _company = companyRepository.GetFirstOrDefault(x => x.CompanyUEN.Equals(company.CompanyUEN));
                    }

                    //INSERT TABLE COMPANYHR
                    if (!ExistsCompanyHR(user.Email, company.CompanyUEN) && _company != null)
                    {
                        companyHRRepository.Add(new CompanyHR()
                        {
                            HRID = Guid.NewGuid().ToString(),
                            CompanyID = _company.CompanyID,
                            Email = user.Email,
                            Name = user.Name,
                            ContactNumber = user.ContactNumber,
                            JobTitle = user.JobTitle,
                            FaxNumber = user.FaxNumber
                        });
                    }

                    this.unitOfWork.Commit();
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }

        public bool CreateStaff(dm.User staff)
        {
            try
            {
                if (!ExistsStaff(staff.LoginID))
                {

                    userRepository.Add(new User()
                    {
                        UserID = Guid.NewGuid().ToString(),
                        LoginID = staff.LoginID,
                        Password = staff.Password,
                        UserType = staff.RoleName.Equals("SYSTEM", StringComparison.OrdinalIgnoreCase) ? 2 : 1
                    });

                    this.unitOfWork.Commit();
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }

        public bool CreateCompany(dm.Company company)
        {
            try
            {
                if (!ExistsCompany(company.CompanyUEN))
                {
                    companyRepository.Add(new Company()
                    {
                        CompanyID = Guid.NewGuid().ToString(),
                        CompanyName = company.CompanyName,
                        CompanyUEN = company.CompanyUEN,
                        OrganizationSize = company.OrganizationSize,
                        CompanyAddress = company.CompanyAddress,
                        Country = company.Country,
                        PostalCode = company.PostalCode
                    });
                }
                this.unitOfWork.Commit();
                return true;
            }
            catch
            {

            }
            return false;
        }

        public dm.Company GetCompanyByID(string companyUEN)
        {
            var _company=companyRepository.GetFirstOrDefault(x => x.CompanyUEN.Equals(companyUEN));
            return new dm.Company()
            {
                CompanyID = _company.CompanyID,
                CompanyName = _company.CompanyName,
                CompanyUEN = _company.CompanyUEN,
                OrganizationSize = _company.OrganizationSize,
                CompanyAddress = _company.CompanyAddress,
                Country = _company.Country,
                PostalCode = _company.PostalCode
            };
        }
        public List<dm.Company> GetCompanyList()
        {
            var _companylist = companyRepository.GetAll();
            return (from _company in _companylist
                    select new dm.Company()
                    {
                        CompanyID = _company.CompanyID,
                        CompanyName = _company.CompanyName,
                        CompanyUEN = _company.CompanyUEN,
                        OrganizationSize = _company.OrganizationSize,
                        CompanyAddress = _company.CompanyAddress,
                        Country = _company.Country,
                        PostalCode = _company.PostalCode
                    }).ToList();
        }

        public dm.User LoginUser(string loginID, string password)
        {
            var _user = userRepository.GetFirstOrDefault(x => x.LoginID.Equals(loginID) && x.Password.Equals(password));
            return new dm.User()
            {
                UserID=_user.UserID,
                LoginID=_user.LoginID,
                Password=_user.Password,
                RoleName = _user.UserType == 2 ? "HR" : "Individual"
            };
        }

        public dm.User LoginStaff(string loginID, string password)
        {
            var _staff = staffRepository.GetFirstOrDefault(x => x.LoginID.Equals(loginID) && x.Password.Equals(password));
            return new dm.User()
            {
                UserID = _staff.StaffID,
                LoginID = _staff.LoginID,
                Password = _staff.Password,
                RoleName = _staff.Role == 1 ? "SYSTEM" : "COURSE"
            };
        }

        public List<dm.User> GetUserList()
        {
            var _userlist = userRepository.GetAll();
            return (from _user in _userlist
                    select new dm.User()
                    {
                        UserID = _user.UserID,
                        LoginID = _user.LoginID,
                        Password = _user.Password,
                        RoleName = _user.UserType == 2 ? "HR" : "Individual"

                    }).ToList();
        }

        public bool EditUser(dm.User user)
        {
            try
            {
                int usertype = user.RoleName.Equals("HR", StringComparison.OrdinalIgnoreCase) ? 2 : 1;

                var _user = userRepository.GetFirstOrDefault(x => x.LoginID.Equals(user.LoginID) && x.Password.Equals(user.Password)
                    && x.UserType == usertype);
                _user.Password = user.Password;
                unitOfWork.Commit();
                return true;
            }
            catch
            {
            }
            return false;
        }

        public bool ExistsUser(string loginID)
        {
            return userRepository.GetAll().SingleOrDefault(g => g.LoginID.Equals(loginID)) != null;
        }

        public bool ExistsStaff(string loginID)
        {
            return staffRepository.GetFirstOrDefault(g => g.LoginID.Equals(loginID)) != null;
        }

        public bool ExistsCompany(string companyUEN)
        {
            return companyRepository.GetFirstOrDefault(g => g.CompanyUEN.Equals(companyUEN))!=null;
        }
        public bool ExistsCompanyHR(string email, string companyUEN)
        {
            var company = companyRepository.GetFirstOrDefault(g => g.CompanyUEN.Equals(companyUEN));
            if (company != null)
            {
                return companyHRRepository.GetFirstOrDefault(g => g.Email.Equals(email)&&g.CompanyID.Equals(company.CompanyID))!=null;
            }
            return false;
        }
    }
}
