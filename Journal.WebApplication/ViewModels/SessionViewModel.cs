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

        public override string ToString()
        {
            return string.Format("{0} -- {1} Duration: {2:F1}, IsActive: {3}", StartTime, EndTime, Duration.TotalHours, IsActive);
        }
    }
}
