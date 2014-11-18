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
            return new UserModel(user.Id,
                                 user.LoginName,
                                 new PersonName(user.Name, user.Surname, user.Patronymic));
        }
    }
}
