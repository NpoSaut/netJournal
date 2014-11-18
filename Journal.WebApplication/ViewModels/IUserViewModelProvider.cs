using Journal.Model;

namespace Journal.WebApplication.ViewModels
{
    public interface IUserViewModelProvider
    {
        /// <summary>Конструирует модель представления для указанной модели пользователя</summary>
        /// <param name="Model">Модель пользователя</param>
        UserViewModel GetViewModel(UserModel Model);
    }
}
