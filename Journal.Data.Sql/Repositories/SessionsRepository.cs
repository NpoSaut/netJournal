using System.Collections.Generic;
using System.Linq;
using Journal.Data.Sql.Entities;
using Journal.Data.Sql.Strategies;

namespace Journal.Data.Sql.Repositories
{
    /// <summary>Репозиторий сессий, работающий через EntityFramework</summary>
    public class SessionsRepository : ContextRepository, ISessionsRepository
    {
        public IList<Session> GetSessions(int UserId, params IQueryStrategy<Session>[] Strategies)
        {
            return Strategies
                .Aggregate(
                    Context.Sessions.Where(s => s.UserId == UserId),
                    (query, strategy) => query.ApplyStrategy(strategy))
                .ToList();
        }
    }
}
