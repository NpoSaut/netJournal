using System.Linq;
using Journal.Data.Sql.Entities;

namespace Journal.Data.Sql.Repositories
{
    public class EntityFrameworkUsersRepository : RepositoryBase, IUsersRepository
    {
        /// <summary>Находит пользователя по его Id</summary>
        /// <param name="UserId">Идентификатор пользователя</param>
        public User GetUserById(int UserId)
        {
            using (var context = new JournalDataModel())
            {
                return context.Users.Find(UserId);
            }
        }

        /// <summary>Получает список всех пользователей</summary>
        public IQueryable<User> GetUsers()
        {
            using (var context = new JournalDataModel())
            {
                return context.Users;
            }
        }
    }
}
