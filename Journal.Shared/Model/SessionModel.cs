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

        public override string ToString() { return string.Format("StartTime: {0}, EndTime: {1}", StartTime, EndTime); }
    }
}
