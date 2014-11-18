using System.Collections.Generic;

namespace Journal.WebApplication.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel(UserViewModel User) { this.User = User; }
        public UserViewModel User { get; private set; }

        public IList<SessionViewModel> Sessions { get; private set; }
    }
}
