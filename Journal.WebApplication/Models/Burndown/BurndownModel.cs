using System;
using System.Collections.Generic;

namespace Journal.WebApplication.Models.Burndown
{
    /// <summary>Модель данных для построения Burndown-диаграммы</summary>
    public class BurndownModel
    {
        public BurndownModel(DateTime StartTime, DateTime EndTime, IList<PointModel> PointsData)
        {
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.PointsData = PointsData;
        }

        /// <summary>Время начала диаграммы</summary>
        public DateTime StartTime { get; private set; }

        /// <summary>Время конца диаграммы</summary>
        public DateTime EndTime { get; private set; }

        /// <summary>Точки диаграммы</summary>
        public IList<PointModel> PointsData { get; private set; }
    }
}
