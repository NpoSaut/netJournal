using System.Linq;
using Journal.Data.Sql.Entities;

namespace Journal.Data.Sql.Strategies
{
    public class TakeNStrategy<TEntity> : IQueryStrategy<TEntity>
    {
        private readonly int _count;
        private TakeNStrategy(int Count) { _count = Count; }

        public IQueryable<TEntity> ApplyTo(IQueryable<TEntity> Query) { return Query.Take(_count); }
        public static TakeNStrategy<TEntity> GeTakeStrategy(int Count) { return new TakeNStrategy<TEntity>(Count); }
    }
}
