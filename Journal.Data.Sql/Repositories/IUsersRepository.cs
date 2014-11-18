using Journal.Data.Sql.Entities;

namespace Journal.Data.Sql.Repositories
{
    public interface IUsersRepository
    {
        User GetUserByLogin(string UserLogin);
        void AddUser(User User);
    }
}