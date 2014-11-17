using System;
using System.Linq;
using System.Linq.Expressions;

namespace Journal.Data.Sql.Repositories
{
    public class RepositoryBase
    {
        private JournalDataModel _context;

        protected virtual JournalDataModel DataContext
        {
            get { return _context ?? (_context = new JournalDataModel()); }
        }

        public virtual TEntity Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return DataContext.Set<TEntity>().Where(predicate).SingleOrDefault();
        }

        public virtual IQueryable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            try
            {
                return DataContext.Set<TEntity>().Where(predicate);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
            return null;
        }

        public virtual IQueryable<TEntity> GetAll<TEntity, TKey>(Expression<Func<TEntity, bool>> predicate,
                                                                 Expression<Func<TEntity, TKey>> orderBy) where TEntity : class
        {
            try
            {
                return GetAll(predicate).OrderBy(orderBy);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
            return null;
        }

        public virtual IQueryable<TEntity> GetAll<TEntity, TKey>(Expression<Func<TEntity, TKey>> orderBy) where TEntity : class
        {
            try
            {
                return GetAll<TEntity>().OrderBy(orderBy);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
            return null;
        }

        public virtual IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            try
            {
                return DataContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
            return null;
        }

        public void Dispose() { if (DataContext != null) DataContext.Dispose(); }

        public virtual bool Save<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                return DataContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
            return false;
        }

        public virtual bool Update<TEntity>(TEntity entity, params string[] propsToUpdate) where TEntity : class
        {
            try
            {
                DataContext.Set<TEntity>().Attach(entity);
                return DataContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
            return false;
        }

        /*public virtual bool Delete<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                ObjectSet<TEntity> objectSet = ((IObjectContextAdapter)DataContext).ObjectContext.CreateObjectSet<TEntity>();
                objectSet.Attach(entity);
                objectSet.DeleteObject(entity);
                return DataContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                LoggerHelper.Logger.ErrorException("Error deleting " + typeof(TEntity), ex);
                throw;
            }

        }*/

        private void ProcessException(Exception e) { throw e; }
    }
}
