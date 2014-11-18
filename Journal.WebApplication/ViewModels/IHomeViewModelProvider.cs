using Journal.Model;

namespace Journal.WebApplication.ViewModels
{
    public interface IHomeViewModelProvider
    {
        HomeViewModel GetViewModel(UserModel User);
    }
}