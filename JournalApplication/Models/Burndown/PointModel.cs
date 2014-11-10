using System;

namespace JournalApplication.Models.Burndown
{
    public class PointModel
    {
        public PointModel(DateTime Time, double HoursBurned)
        {
            this.Time = Time;
            this.HoursBurned = HoursBurned;
        }

        public DateTime Time { get; private set; }
        public Double HoursBurned { get; private set; }
    }
}
