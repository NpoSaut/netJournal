using System;
using System.Collections.Generic;
using System.Linq;
using Journal.Data.Sql.Entities;
using Journal.Data.Sql.Repositories;
using Journal.Data.Sql.Strategies;

namespace Journal.Model
{
    public class RepositorySessionModelProvider : ISessionModelProvider
    {
        private readonly ISessionsRepository _sessionsRepository;
        private readonly IUsersRepository _usersRepository;

        public RepositorySessionModelProvider(ISessionsRepository SessionsRepository, IUsersRepository UsersRepository)
        {
            _sessionsRepository = SessionsRepository;
            _usersRepository = UsersRepository;
        }

        /// <summary>Находит список сессий для пользователя в указанном интервале времени</summary>
        /// <param name="User">Пользователь</param>
        /// <param name="StartTime">Начало интервала для поиска</param>
        /// <param name="EndTime">Конец интервала для поиска</param>
        /// <param name="IntervalSearchOption">Опция поиска в интервале времени</param>
        public IList<SessionModel> GetSessionsForUser(UserModel User, DateTime StartTime, DateTime EndTime,
                                                      TimeIntervalSearchOption IntervalSearchOption = TimeIntervalSearchOption.Outer)
        {
            FilterSessionsStrategy filterStrategy;
            switch (IntervalSearchOption)
            {
                case TimeIntervalSearchOption.Outer:
                    filterStrategy = FilterSessionsStrategy.GetSessionCoversIntervalStrategy(StartTime, EndTime);
                    break;
                case TimeIntervalSearchOption.Inner:
                    filterStrategy = FilterSessionsStrategy.GetSessionWithinIntervalStrategy(StartTime, EndTime);
                    break;
                default:
                    filterStrategy = FilterSessionsStrategy.GetEmptyStrategy();
                    break;
            }
            return _sessionsRepository.GetSessions(User.Id, filterStrategy)
                                      .Select(GetSessionModel)
                                      .ToList();
        }

        /// <summary>Получает <paramref name="Count" /> последних сессий для указанного пользователя</summary>
        /// <param name="User">Пользователь</param>
        /// <param name="Count">Количество последних сессий</param>
        public IList<SessionModel> GetLastSessions(UserModel User, int Count)
        {
            return _sessionsRepository.GetSessions(User.Id,
                                                   OrderSessionsStrategy.GetOrderByStartDateStrategy(),
                                                   TakeNStrategy<Session>.GeTakeStrategy(Count))
                                      .Select(GetSessionModel)
                                      .ToList();
        }

        private static SessionModel GetSessionModel(Session Session) { return new SessionModel(Session.StartTime, Session.EndTime); }
    }
}
