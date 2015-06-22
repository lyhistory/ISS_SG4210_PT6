using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
/*
 * Author:LIU YUE
 * */
namespace CRS_DAL.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate);
       // public IOrderedEnumerable<TEntity> OrderBy(Func<TEntity, bool> orderby, System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate,bool asc);
        TEntity GetFirst(Expression<Func<TEntity, bool>> predicate);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void Delete(TEntity entity);
    }
}
