using CRS_DAL.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
/*
 * Author:LIU YUE
 * */
namespace CRS_DAL.Repository
{
    internal class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private bool isDisposed;

        private DbSet<TEntity> dbSet;
        public DbSet<TEntity> DbSet
        {
            get { return dbSet; }
        }

        private CRSEntities crsContext;

        public RepositoryBase(CRSEntities crsContext)
        {
            this.crsContext = crsContext;
            this.dbSet = crsContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public IQueryable<TEntity> GetWhere(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public TEntity GetSingle(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Single(predicate);
        }

        public TEntity GetSingleOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Dispose(bool isManuallyDisposing)
        {
            if (!isDisposed)
            {
                if (isManuallyDisposing)
                    crsContext.Dispose();
            }

            isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~RepositoryBase()
        {
            Dispose(false);
        }

    } 
}
