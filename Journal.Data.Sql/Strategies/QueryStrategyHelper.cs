using System.Linq;

namespace Journal.Data.Sql.Strategies
{
    internal static class QueryStrategyHelper
    {
        public static IQueryable<TEntity> ApplyStrategy<TEntity>(this IQueryable<TEntity> Query, IQueryStrategy<TEntity> Strategy)
        {
            return Strategy.ApplyTo(Query);
        }
    }
}
