using Journal.Model;
using Journal.WebApplication.ViewModels.NameFormatters;

namespace Journal.WebApplication.ViewModels
{
    /// <summary>Провайдер моделей представления пользователей</summary>
    public class UserViewModelProvider : IUserViewModelProvider
    {
        private readonly IAppealFormatter _appealFormatter;
        private readonly IFullNameFormatter _fullNameFormatter;

        public UserViewModelProvider(IAppealFormatter AppealFormatter, IFullNameFormatter FullNameFormatter)
        {
            _appealFormatter = AppealFormatter;
            _fullNameFormatter = FullNameFormatter;
        }

        /// <summary>Конструирует модель представления для указанной модели пользователя</summary>
        /// <param name="Model">Модель пользователя</param>
        public UserViewModel GetViewModel(UserModel Model)
        {
            return new UserViewModel(Model.Login,
                                     _appealFormatter.FormatAppeal(Model.FullName),
                                     _fullNameFormatter.FormatFullName(Model.FullName));
        }
    }
}
