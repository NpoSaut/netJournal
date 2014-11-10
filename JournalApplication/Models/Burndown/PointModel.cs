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

        public override string ToString() { return string.Format("Time: {0}, Unburned: {1:F1} hours", Time, UnburnedHours); }
    }
}
