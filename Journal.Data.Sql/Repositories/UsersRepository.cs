using System.Linq;
using Journal.Data.Sql.Entities;

namespace Journal.Data.Sql.Repositories
{
    public class UsersRepository : ContextRepository, IUsersRepository
    {
        public User GetUserByLogin(string UserLogin) { return Context.Users.SingleOrDefault(u => u.LoginName == UserLogin); }
    }
}
