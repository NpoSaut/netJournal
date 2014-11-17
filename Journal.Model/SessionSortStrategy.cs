using System;
using System.Linq.Expressions;

namespace Journal.Model
{
    public class SessionSortStrategy
    {
        private Expression<Func<ISessionModel, DateTime>> _orderExpression;
        public SessionSortStrategy(Expression<Func<ISessionModel, DateTime>> OrderExpression) { _orderExpression = OrderExpression; }

        public static SessionSortStrategy ByStartOlderFirst
        {
            get
            {
                return new SessionSortStrategy(s => s.StartTime);
            }
        }
    }
}