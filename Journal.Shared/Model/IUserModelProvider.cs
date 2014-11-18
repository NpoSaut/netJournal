namespace Journal.Model
{
    /// <summary>Провайдер моделей пользователей</summary>
    public interface IUserModelProvider
    {
        /// <summary>Получает модель пользователя по логину</summary>
        /// <param name="UserLogin">AD-логин пользователя</param>
        /// <returns>Модель пользователя, соответствующая указанному логину</returns>
        UserModel GetUserModel(string UserLogin);

        /// <summary>Создаёт пользователя с указанными логином и именем</summary>
        /// <param name="UserLogin">Логин пользователя</param>
        /// <param name="PersonName">Имя пользователя</param>
        /// <returns>Модель созданного пользователя</returns>
        UserModel CreateUser(string UserLogin, PersonName PersonName);
    }
}
