using System.Collections.Generic;
using Journal.Data.Sql.Entities;
using Journal.Data.Sql.Strategies;

namespace Journal.Data.Sql.Repositories
{
    public interface ISessionsRepository
    {
        IList<Session> GetSessions(int UserId, params IQueryStrategy<Session>[] Strategies);
    }
}