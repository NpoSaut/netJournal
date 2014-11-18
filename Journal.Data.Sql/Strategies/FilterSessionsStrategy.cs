using System;
using System.Linq;
using System.Linq.Expressions;
using Journal.Data.Sql.Entities;

namespace Journal.Data.Sql.Strategies
{
    public class FilterSessionsStrategy : IQueryStrategy<Session>
    {
        private readonly Expression<Func<Session, bool>> _filterSessionExpression;
        private FilterSessionsStrategy(Expression<Func<Session, bool>> FilterSessionExpression) { _filterSessionExpression = FilterSessionExpression; }
        public IQueryable<Session> ApplyTo(IQueryable<Session> Query) { return Query.Where(_filterSessionExpression); }

        public static FilterSessionsStrategy GetEmptyStrategy() { return new FilterSessionsStrategy(s => true); }

        public static FilterSessionsStrategy GetSessionCoversIntervalStrategy(DateTime StartTime, DateTime EndTime)
        {
            return new FilterSessionsStrategy(s => (s.EndTime <= EndTime && s.EndTime >= StartTime)
                                                   || (s.StartTime >= StartTime && s.StartTime <= EndTime));
        }

        public static FilterSessionsStrategy GetSessionWithinIntervalStrategy(DateTime StartTime, DateTime EndTime)
        {
            return new FilterSessionsStrategy(s => s.StartTime >= StartTime && s.EndTime <= EndTime);
        }
    }
}
