using System;

namespace Journal.WebApplication.Models.Burndown
{
    /// <summary>Калькулятор рабочего времени</summary>
    public interface IWorktimeCalculator
    {
        /// <summary>Подсчитывает количество рабочих часов в заданном интервале времени</summary>
        /// <param name="From">От</param>
        /// <param name="To">До</param>
        /// <returns>Количество рабочего времени в часах</returns>
        double CountWorkingHours(DateTime From, DateTime To);
    }
}
