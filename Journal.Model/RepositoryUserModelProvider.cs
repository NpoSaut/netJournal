using Journal.Data.Sql.Entities;
using Journal.Data.Sql.Repositories;

namespace Journal.Model
{
    /// <summary>Поставщик пользовательских моделей, работающий через репозиторий <see cref="IUsersRepository" />
    /// </summary>
    public class RepositoryUserModelProvider : IUserModelProvider
    {
        private readonly IUsersRepository _repository;
        public RepositoryUserModelProvider(IUsersRepository Repository) { _repository = Repository; }

        /// <summary>Получает модель пользователя по логину</summary>
        /// <param name="UserLogin">AD-логин пользователя</param>
        /// <returns>Модель пользователя, соответствующая указанному логину</returns>
        public UserModel GetUserModel(string UserLogin)
        {
            User user = _repository.GetUserByLogin(UserLogin);
            return GetUserModel(user);
        }

        /// <summary>Создаёт пользователя с указанными логином и именем</summary>
        /// <param name="UserLogin">Логин пользователя</param>
        /// <param name="PersonName">Имя пользователя</param>
        /// <returns>Модель созданного пользователя</returns>
        public UserModel CreateUser(string UserLogin, PersonName PersonName)
        {
            var dalUser = new User(UserLogin, PersonName.Name, PersonName.Surname, PersonName.Patronymic);
            _repository.AddUser(dalUser);
            return GetUserModel(dalUser);
        }

        /// <summary>Получает Модель для указанного пользователя</summary>
        private static UserModel GetUserModel(User user)
        {
            if (user == null) return null;
            return new UserModel(user.Id,
                                 user.LoginName,
                                 new PersonName(user.Name, user.Surname, user.Patronymic));
        }
    }
}
