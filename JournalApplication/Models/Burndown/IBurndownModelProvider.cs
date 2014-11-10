using System;

namespace JournalApplication.Models.Burndown
{
    public interface IBurndownModelProvider
    {
        /// <summary>Строит модель Burndown-диаграммы для заданного отрезка времени</summary>
        /// <param name="StartTime">Дата начала отрезка времени для построения диаграммы</param>
        /// <param name="EndTime">Дата конца отрезка времени для построения диаграммы</param>
        /// <param name="UserId">Идентификатор пользователя, для которого строится диаграмма</param>
        BurndownModel GetBurndownModel(DateTime StartTime, DateTime EndTime, int UserId);
    }
}
