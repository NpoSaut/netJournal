namespace Journal.Data.Sql
{
    public class EntityFrameworkUserRepository : IUsersRepository
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
    }
}
