using System;
using Journal.Model;

namespace Journal.WebApplication.Models.Burndown
{
    public interface IBurndownModelProvider
    {
        /// <summary>Строит модель Burndown-диаграммы для заданного отрезка времени</summary>
        /// <param name="StartTime">Дата начала отрезка времени для построения диаграммы</param>
        /// <param name="EndTime">Дата конца отрезка времени для построения диаграммы</param>
        /// <param name="User">Пользователь, для которого строится диаграмма</param>
        BurndownModel GetBurndownModel(DateTime StartTime, DateTime EndTime, IUserModel User);
    }
}
