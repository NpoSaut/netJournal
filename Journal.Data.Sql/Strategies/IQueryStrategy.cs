using System.Linq;

namespace Journal.Data.Sql.Strategies
{
    public interface IQueryStrategy<TEntity>
    {
        IQueryable<TEntity> ApplyTo(IQueryable<TEntity> Query);
    }
}