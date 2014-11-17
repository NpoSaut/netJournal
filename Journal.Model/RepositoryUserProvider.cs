using Journal.Data.Sql.Entities;
using Journal.Data.Sql.Repositories;
using Journal.Model.ModelAdapters;

namespace Journal.Model
{
    /// <summary>��������� ���������������� �������, ���������� ����� ����������� <see cref="IUsersRepository" />
    /// </summary>
    public class RepositoryUserProvider : IUserProvider
    {
        private readonly IUsersRepository _repository;
        public RepositoryUserProvider(IUsersRepository Repository) { _repository = Repository; }

        /// <summary>�������� ������ ������������ �� ������</summary>
        /// <param name="UserLogin">AD-����� ������������</param>
        /// <returns>������ ������������, ��������������� ���������� ������</returns>
        public IUserModel GetUserModel(string UserLogin) { return new UserModelAdapter(_repository.Get<User>(u => u.LoginName == UserLogin)); }
    }
}
