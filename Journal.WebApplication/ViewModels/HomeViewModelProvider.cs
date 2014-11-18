using System.Collections.Generic;
using System.Linq;
using Journal.Model;

namespace Journal.WebApplication.ViewModels
{
    public class HomeViewModelProvider : IHomeViewModelProvider
    {
        private readonly ISessionModelProvider _sessionModelProvider;
        private readonly ISessionViewModelProvider _sessionViewModelProvider;
        private readonly IUserViewModelProvider _userViewModelProvider;

        public HomeViewModelProvider(IUserViewModelProvider UserViewModelProvider, ISessionViewModelProvider SessionViewModelProvider,
                                     ISessionModelProvider SessionModelProvider)
        {
            _userViewModelProvider = UserViewModelProvider;
            _sessionViewModelProvider = SessionViewModelProvider;
            _sessionModelProvider = SessionModelProvider;
        }

        public HomeViewModel GetViewModel(UserModel User)
        {
            UserViewModel userViewModel = _userViewModelProvider.GetViewModel(User);
            List<SessionViewModel> lastSessions = _sessionModelProvider.GetLastSessions(User, 10).Select(_sessionViewModelProvider.GetViewModel).ToList();
            return new HomeViewModel(userViewModel, lastSessions);
        }
    }
}
