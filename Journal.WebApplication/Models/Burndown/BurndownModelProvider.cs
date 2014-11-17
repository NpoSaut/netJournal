using System;
using System.Collections.Generic;
using System.Linq;
using Journal.Model;

namespace Journal.WebApplication.Models.Burndown
{
    /// <summary>Инструмент построения Burndown-диаграмм</summary>
    public class BurndownModelProvider : IBurndownModelProvider
    {
        private readonly ISessionProvider _sessionProvider;
        private readonly IWorktimeCalculator _worktimeCalculator;
        private IUserProvider _userProvider;

        public BurndownModelProvider(IUserProvider UserProvider, IWorktimeCalculator WorktimeCalculator, ISessionProvider SessionProvider)
        {
            _userProvider = UserProvider;
            _worktimeCalculator = WorktimeCalculator;
            _sessionProvider = SessionProvider;
        }

        /// <summary>Строит модель Burndown-диаграммы для заданного отрезка времени</summary>
        /// <param name="StartTime">Дата начала отрезка времени для построения диаграммы</param>
        /// <param name="EndTime">Дата конца отрезка времени для построения диаграммы</param>
        /// <param name="User">Пользователь, для которого строится диаграмма</param>
        public BurndownModel GetBurndownModel(DateTime StartTime, DateTime EndTime, IUserModel User)
        {
            double totalWorktime = _worktimeCalculator.CountWorkingHours(StartTime, EndTime);
            List<ISessionModel> sessions = _sessionProvider.GetSessionsForUser(User)
                                                           .Where(s => (s.EndTime <= EndTime && s.EndTime >= StartTime)
                                                                       || (s.StartTime >= StartTime && s.StartTime <= EndTime))
                                                           .ToList();

            double burndown = totalWorktime;
            var points = new List<PointModel>(sessions.Count() + 2) { new PointModel(StartTime, burndown) };

            foreach (ISessionModel session in sessions)
            {
                burndown -= ((session.EndTime ?? DateTime.Now) - session.StartTime).TotalHours;
                points.Add(new PointModel(session.EndTime ?? EndTime, burndown));
            }

            return new BurndownModel(StartTime, EndTime, points);
        }
    }
}
