using System;

namespace Journal.Model
{
    public class SessionModel
    {
        public SessionModel(DateTime StartTime, DateTime? EndTime)
        {
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }

        public DateTime StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }
    }
}