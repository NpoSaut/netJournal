using System;
using System.Collections.Generic;

namespace Journal.WebApplication.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel(string UserLogin, string UserName, IList<SessionViewModel> Sessions)
        {
            this.Sessions = Sessions;
            this.UserLogin = UserLogin;
            this.UserName = UserName;
        }

        public String UserLogin { get; private set; }
        public String UserName { get; private set; }

        public IList<SessionViewModel> Sessions { get; private set; }
    }
}
