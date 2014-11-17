using Journal.Data.Sql.Entities;
using Journal.Data.Sql.Repositories;
using Journal.Model.ModelAdapters;

namespace Journal.Model
{
    /// <summary>ѕоставщик пользовательских моделей, работающий через репозиторий <see cref="IUsersRepository" />
    /// </summary>
    public class RepositoryUserProvider : IUserProvider
    {
        private readonly IUsersRepository _repository;
        public RepositoryUserProvider(IUsersRepository Repository) { _repository = Repository; }

        /// <summary>ѕолучает модель пользовател€ по логину</summary>
        /// <param name="UserLogin">AD-логин пользовател€</param>
        /// <returns>ћодель пользовател€, соответствующа€ указанному логину</returns>
        public IUserModel GetUserModel(string UserLogin) { return new UserModelAdapter(_repository.Get<User>(u => u.LoginName == UserLogin)); }
    }
}
