using System;
using System.Linq;
using System.Linq.Expressions;

namespace Journal.Data.Sql.Repositories
{
    public interface IRepository
    {
        TEntity Get<TEntity>(Expression<Func<TEntity, bool>> Predicate) where TEntity : class;
        IQueryable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> Predicate) where TEntity : class;

        IQueryable<TEntity> GetAll<TEntity, TKey>(Expression<Func<TEntity, bool>> Predicate,
                                                  Expression<Func<TEntity, TKey>> OrderBy) where TEntity : class;

        IQueryable<TEntity> GetAll<TEntity, TKey>(Expression<Func<TEntity, TKey>> OrderBy) where TEntity : class;
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
    }
}
