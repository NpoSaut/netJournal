using System;

namespace Journal.WebApplication.Models.Burndown
{
    /// <summary>Считает количество рабочего времени без учёта чего-либо</summary>
    public class SimpleWorktimeCalculator : IWorktimeCalculator
    {
        /// <summary>Подсчитывает количество рабочих часов в заданном интервале времени</summary>
        /// <param name="From">От</param>
        /// <param name="To">До</param>
        /// <returns>Количество рабочего времени в часах</returns>
        public double CountWorkingHours(DateTime From, DateTime To) { return (To - From).TotalHours * 8.0 / 24.0; }
    }
}