using System;
using System.Collections.Generic;
using System.Linq;
using Journal.Data;

namespace Journal.WebApplication.Models.Burndown
{
    /// <summary>Инструмент построения Burndown-диаграмм</summary>
    public class BurndownModelProvider : IBurndownModelProvider
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IWorktimeCalculator _worktimeCalculator;

        public BurndownModelProvider(IWorktimeCalculator WorktimeCalculator, ISessionRepository SessionRepository)
        {
            _worktimeCalculator = WorktimeCalculator;
            _sessionRepository = SessionRepository;
        }

        /// <summary>Строит модель Burndown-диаграммы для заданного отрезка времени</summary>
        /// <param name="StartTime">Дата начала отрезка времени для построения диаграммы</param>
        /// <param name="EndTime">Дата конца отрезка времени для построения диаграммы</param>
        /// <param name="UserId">Идентификатор пользователя, для которого строится диаграмма</param>
        public BurndownModel GetBurndownModel(DateTime StartTime, DateTime EndTime, int UserId)
        {
            double totalWorktime = _worktimeCalculator.CountWorkingHours(StartTime, EndTime);
            IEnumerable<Session> sessions =
                _sessionRepository.GetSessions(UserId)
                                  .Where(s => (s.EndTime <= EndTime && s.EndTime >= StartTime)
                                              || (s.StartTime >= StartTime && s.StartTime <= EndTime))
                                  .ToList();

            double burndown = totalWorktime;
            var points = new List<PointModel>(sessions.Count() + 2) { new PointModel(StartTime, burndown) };

            foreach (Session session in sessions)
            {
                burndown -= ((session.EndTime ?? DateTime.Now) - session.StartTime).TotalHours;
                points.Add(new PointModel(session.EndTime ?? EndTime, burndown));
            }

            return new BurndownModel(StartTime, EndTime, points);
        }
    }
}
