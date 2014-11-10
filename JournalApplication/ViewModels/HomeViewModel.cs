using System;
using System.Collections.Generic;

namespace JournalApplication.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel(string UserName, IList<SessionViewModel> Sessions)
        {
            this.Sessions = Sessions;
            this.UserName = UserName;
        }

        public String UserName { get; private set; }

        public IList<SessionViewModel> Sessions { get; private set; }
    }
}
