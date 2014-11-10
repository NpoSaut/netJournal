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

    public class SessionViewModel
    {
        /// <summary>Инициализирует новый экземпляр класса <see cref="T:System.Object" />.</summary>
        public SessionViewModel(DateTime StartTime, DateTime EndTime)
        {
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public TimeSpan Duration
        {
            get { return EndTime - StartTime; }
        }
    }
}
