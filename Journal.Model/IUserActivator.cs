using System;

namespace Journal.Model
{
    /// <summary>Активатор пользователей</summary>
    /// <remarks>Инструмент для создания учётных записей пользователей</remarks>
    public interface IUserActivator
    {
        /// <summary>Создаёт учётную запись пользователя и возвращает её</summary>
        /// <param name="UserLogin">Логин пользователя</param>
        UserModel ActivateUser(String UserLogin);
    }

    public class UserActivator : IUserActivator
    {
        private readonly IUserDetailsProvider _userDetailsProvider;
        private readonly IUserModelProvider _userModelProvider;

        public UserActivator(IUserDetailsProvider UserDetailsProvider, IUserModelProvider UserModelProvider)
        {
            _userDetailsProvider = UserDetailsProvider;
            _userModelProvider = UserModelProvider;
        }

        /// <summary>Создаёт учётную запись пользователя и возвращает её</summary>
        /// <param name="UserLogin">Логин пользователя</param>
        public UserModel ActivateUser(string UserLogin)
        {
            PersonName personName = _userDetailsProvider.GetPersonName(UserLogin);
            return _userModelProvider.CreateUser(UserLogin, personName);
        }
    }
}
