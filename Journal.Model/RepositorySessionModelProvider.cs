using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Journal.Data.Sql.Entities;
using Journal.Data.Sql.Repositories;

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
    }
}
