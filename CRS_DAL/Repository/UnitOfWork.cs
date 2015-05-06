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
        void Commit();
    }

    public partial class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private CRSEntities crsContext;

        private UserService userService;
        private CourseService cousrseService;

        public UserService UserService
        {
            get
            {
                if (userService == null)
                    userService = new UserService(this,new RepositoryBase<User>(crsContext));

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
                        new RepositoryBase<CourseClass>(crsContext));

                return cousrseService;
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
