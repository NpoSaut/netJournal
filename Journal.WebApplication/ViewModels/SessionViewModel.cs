using System;

namespace Journal.WebApplication.ViewModels
{
    public class SessionViewModel
    {
        public SessionViewModel(DateTime StartTime, DateTime? EndTime)
        {
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }

        public DateTime StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }

        public TimeSpan Duration
        {
            get { return (EndTime ?? DateTime.Now) - StartTime; }
        }

        public bool IsActive
        {
            get { return EndTime == null; }
        }
    }
}
