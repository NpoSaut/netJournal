using System;
using System.Collections.Generic;
using System.Linq;
using Journal.Model;

namespace Journal.WebApplication.Models.Burndown
{
    /// <summary>Инструмент построения Burndown-диаграмм</summary>
    public class BurndownModelProvider : IBurndownModelProvider
    {
        private readonly ISessionModelProvider _sessionModelProvider;
        private readonly IWorktimeCalculator _worktimeCalculator;
        private IUserModelProvider _userModelProvider;

        public BurndownModelProvider(IUserModelProvider UserModelProvider, IWorktimeCalculator WorktimeCalculator, ISessionModelProvider SessionModelProvider)
        {
            _userModelProvider = UserModelProvider;
            _worktimeCalculator = WorktimeCalculator;
            _sessionModelProvider = SessionModelProvider;
        }

        /// <summary>Строит модель Burndown-диаграммы для заданного отрезка времени</summary>
        /// <param name="StartTime">Дата начала отрезка времени для построения диаграммы</param>
        /// <param name="EndTime">Дата конца отрезка времени для построения диаграммы</param>
        /// <param name="User">Пользователь, для которого строится диаграмма</param>
        public BurndownModel GetBurndownModel(DateTime StartTime, DateTime EndTime, UserModel User)
        {
            double totalWorktime = _worktimeCalculator.CountWorkingHours(StartTime, EndTime);
            IList<SessionModel> sessions = _sessionModelProvider.GetSessionsForUser(User, StartTime, EndTime);

            double burndown = totalWorktime;
            var points = new List<PointModel>(sessions.Count() + 2) { new PointModel(StartTime, burndown) };

            foreach (SessionModel session in sessions)
            {
                burndown -= ((session.EndTime ?? DateTime.Now) - session.StartTime).TotalHours;
                points.Add(new PointModel(session.EndTime ?? EndTime, burndown));
            }

            return new BurndownModel(StartTime, EndTime, points);
        }
    }
}
