using System;
using System.Linq.Expressions;

namespace Journal.Model
{
    public class SessionSortStrategy
    {
        private Expression<Func<SessionModel, DateTime>> _orderExpression;
        public SessionSortStrategy(Expression<Func<SessionModel, DateTime>> OrderExpression) { _orderExpression = OrderExpression; }

        public static SessionSortStrategy ByStartOlderFirst
        {
            get { return new SessionSortStrategy(s => s.StartTime); }
        }
    }
}
