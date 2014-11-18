namespace Journal.Model
{
    /// <summary>Инструмент получения сведений о пользователе из сторонних источников</summary>
    public interface IUserDetailsProvider
    {
        /// <summary>Получает полное имя пользователя с указанными логином</summary>
        /// <param name="UserLogin">Логин пользователя</param>
        PersonName GetPersonName(string UserLogin);
    }
}
