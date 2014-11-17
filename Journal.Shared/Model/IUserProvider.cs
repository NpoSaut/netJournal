namespace Journal.Model
{
    /// <summary>Провайдер моделей пользователей</summary>
    public interface IUserProvider
    {
        /// <summary>Получает модель пользователя по логину</summary>
        /// <param name="UserLogin">AD-логин пользователя</param>
        /// <returns>Модель пользователя, соответствующая указанному логину</returns>
        IUserModel GetUserModel(string UserLogin);
    }
}
