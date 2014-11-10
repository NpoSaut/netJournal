using System;
using System.Collections.Generic;

namespace JournalApplication.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel(int UserId, string UserName, IList<SessionViewModel> Sessions)
        {
            this.UserId = UserId;
            this.Sessions = Sessions;
            this.UserName = UserName;
        }

        public int UserId { get; private set; }
        public String UserName { get; private set; }

        public IList<SessionViewModel> Sessions { get; private set; }
    }
}
