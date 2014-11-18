using Journal.Data.Sql.Entities;
using Journal.Data.Sql.Repositories;

namespace Journal.Model
{
    /// <summary>��������� ���������������� �������, ���������� ����� ����������� <see cref="IUsersRepository" />
    /// </summary>
    public class RepositoryUserModelProvider : IUserModelProvider
    {
        private readonly IUsersRepository _repository;
        public RepositoryUserModelProvider(IUsersRepository Repository) { _repository = Repository; }

        /// <summary>�������� ������ ������������ �� ������</summary>
        /// <param name="UserLogin">AD-����� ������������</param>
        /// <returns>������ ������������, ��������������� ���������� ������</returns>
        public UserModel GetUserModel(string UserLogin)
        {
            User user = _repository.GetUserByLogin(UserLogin);
            return GetUserModel(user);
        }

        /// <summary>������ ������������ � ���������� ������� � ������</summary>
        /// <param name="UserLogin">����� ������������</param>
        /// <param name="PersonName">��� ������������</param>
        /// <returns>������ ���������� ������������</returns>
        public UserModel CreateUser(string UserLogin, PersonName PersonName)
        {
            var dalUser = new User(UserLogin, PersonName.Name, PersonName.Surname, PersonName.Patronymic);
            _repository.AddUser(dalUser);
            return GetUserModel(dalUser);
        }

        /// <summary>�������� ������ ��� ���������� ������������</summary>
        private static UserModel GetUserModel(User user)
        {
            if (user == null) return null;
            return new UserModel(user.Id,
                                 user.LoginName,
                                 new PersonName(user.Name, user.Surname, user.Patronymic));
        }
    }
}
