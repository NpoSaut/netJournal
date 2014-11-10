namespace Journal.Data
{
    /// <summary>Репозиторий пользователей</summary>
    public interface IUsersRepository
    {
        /// <summary>Находит пользователя по его Id</summary>
        /// <param name="UserId">Идентификатор пользователя</param>
        User GetUserById(int UserId);
    }
}
