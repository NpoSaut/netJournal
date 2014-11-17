using System.Linq;
using Journal.Data.Sql.Entities;
using Journal.Data.Sql.Repositories;
using Journal.Model.ModelAdapters;

namespace Journal.Model
{
    public class RepositorySessionProvider : ISessionProvider
    {
        private readonly ISessionsRepository _sessionsRepository;
        private readonly IUsersRepository _usersRepository;

        public RepositorySessionProvider(ISessionsRepository SessionsRepository, IUsersRepository UsersRepository)
        {
            _sessionsRepository = SessionsRepository;
            _usersRepository = UsersRepository;
        }

        public IQueryable<ISessionModel> GetSessionsForUser(IUserModel User)
        {
            var user = _usersRepository.Get<User>(u => u.LoginName == User.LoginName);
            return _sessionsRepository.GetAll<Session>(s => s.User == user).Select(s => new SessionModelAdapter(s));
        }
    }
}
