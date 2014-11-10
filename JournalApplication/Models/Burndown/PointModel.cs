using System;

namespace JournalApplication.Models.Burndown
{
    public class PointModel
    {
        public PointModel(DateTime Time, double UnburnedHours)
        {
            this.Time = Time;
            this.UnburnedHours = UnburnedHours;
        }

        public DateTime Time { get; private set; }
        public Double UnburnedHours { get; private set; }
    }
}
