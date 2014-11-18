using System;
using System.Linq;
using System.Linq.Expressions;
using Journal.Data.Sql.Entities;

namespace Journal.Data.Sql.Strategies
{
    public class OrderSessionsStrategy : IQueryStrategy<Session>
    {
        public enum OrderDirection
        {
            /// <summary>От старых к новым</summary>
            Increasing,

            /// <summary>От новых к старым</summary>
            Decreasing
        }

        private readonly OrderDirection _direction;
        private readonly Expression<Func<Session, DateTime>> _selectKeyExpression;

        private OrderSessionsStrategy(Expression<Func<Session, DateTime>> SelectKeyExpression, OrderDirection Direction)
        {
            _selectKeyExpression = SelectKeyExpression;
            _direction = Direction;
        }

        public IQueryable<Session> ApplyTo(IQueryable<Session> Query)
        {
            switch (_direction)
            {
                case OrderDirection.Increasing:
                    return Query.OrderBy(_selectKeyExpression);
                case OrderDirection.Decreasing:
                    return Query.OrderByDescending(_selectKeyExpression);
            }
            throw new ApplicationException();
        }

        public static OrderSessionsStrategy GetOrderByStartDateStrategy(OrderDirection Direction = OrderDirection.Decreasing)
        {
            return new OrderSessionsStrategy(session => session.StartTime, Direction);
        }
    }
}
