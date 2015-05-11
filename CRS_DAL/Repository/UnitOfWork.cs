using CRS_DAL.EF;
using CRS_DAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Author:LIU YUE
 * */
namespace CRS_DAL.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        UserService UserService { get; }
        CourseService CourseService { get; }
        ClassService ClassService { get; }
        CourseRegistrationService CourseRegistrationService { get; }
        void Commit();
    }

    public partial class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private CRSEntities crsContext;

        private UserService userService;
        private CourseService cousrseService;
        private ClassService classService;
        private CourseRegistrationService courseRegistrationService;

        public UserService UserService
        {
            get
            {
                if (userService == null)
                    userService = new UserService(this,new RepositoryBase<User>(crsContext),new RepositoryBase<Staff>(crsContext),
                new RepositoryBase<Company>(crsContext),new RepositoryBase<CompanyHR>(crsContext));

                return userService;
            }

        }
        public CourseService CourseService
        {
            get
            {
                if (cousrseService == null)
                    cousrseService = new CourseService(this,new RepositoryBase<Course>(crsContext),
                        new RepositoryBase<CourseCategory>(crsContext),
                        new RepositoryBase<CourseClass>(crsContext),
                        new RepositoryBase<Instructor>(crsContext));

                return cousrseService;
            }

        }
        public ClassService ClassService
        {
            get
            {
                if (classService == null)
                    classService = new ClassService(this, new RepositoryBase<CourseClass>(crsContext),
                        new RepositoryBase<Course>(crsContext),new RepositoryBase<CourseCategory>(crsContext),
                        new RepositoryBase<Participant>(crsContext), new RepositoryBase<Registration>(crsContext),
                        new RepositoryBase<Instructor>(crsContext));

                return classService;
            }

        }

        public CourseRegistrationService CourseRegistrationService
        {
            get
            {
                if (courseRegistrationService == null)
                    courseRegistrationService = new CourseRegistrationService(this, new RepositoryBase<CourseClass>(crsContext),
                        new RepositoryBase<Course>(crsContext), new RepositoryBase<CourseCategory>(crsContext),
                        new RepositoryBase<Participant>(crsContext), new RepositoryBase<Registration>(crsContext),
                        new RepositoryBase<Instructor>(crsContext));

                return courseRegistrationService;
            }

        }

        public UnitOfWork()
        {
            crsContext = new CRSEntities();
        }

        public void Commit()
        {
            crsContext.SaveChanges();
        }

        public void Refresh()
        {
            crsContext.Dispose();
            crsContext = new CRSEntities();
        }

        protected virtual void Dispose(bool isManuallyDisposing)
        {
            if (!this.disposed)
            {
                if (isManuallyDisposing)
                    crsContext.Dispose();
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
