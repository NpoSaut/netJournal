using System;

namespace Journal.Shared.Data
{
    public class Session
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
