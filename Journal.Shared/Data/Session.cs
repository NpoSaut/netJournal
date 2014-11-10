using System;

namespace Journal.Data
{
    public class Session
    {
        public Session() { }

        public Session(DateTime StartTime, DateTime EndTime, int UserId) : this()
        {
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.UserId = UserId;
        }

        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
