using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Journal.Data;
using Journal.Data.Sql;
using JournalApplication.Models.Burndown;
using JournalApplication.ViewModels;

namespace JournalApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private const int CurrentUserId = 1;
        private readonly ISessionRepository _sessionRepository = new EntityFrameworkSessionsRepository();
        private readonly IUsersRepository _usersRepository = new EntityFrameworkUserRepository();

        public ActionResult Index()
        {
            User user = _usersRepository.GetUserById(CurrentUserId);

            var model = new HomeViewModel(user.Id, user.Name,
                                          _sessionRepository.GetSessions(user.Id)
                                                            .OrderByDescending(s => s.StartTime)
                                                            .Take(10)
                                                            .Select(s => new SessionViewModel(s.StartTime, s.EndTime))
                                                            .ToList());
            return View(model);
        }

        public ActionResult OpenSession(DateTime StartTime, int UserId)
        {
            var session = new Session(StartTime, null, UserId);
            _sessionRepository.AddSession(session);
            return View("Success");
        }

        public ActionResult CloseSession(DateTime EndTime, int UserId)
        {
            Session session = _sessionRepository.GetOpenSession(UserId);
            session.EndTime = EndTime;
            _sessionRepository.SaveSessionChanged(session);
            return View("Success");
        }

        public JsonResult Burndown(DateTime From, DateTime To)
        {
            var r = new Random();
            const int pointsCount = 10;
            const double hoursCount = 40;
            TimeSpan dur = To - From;
            List<PointModel> points = Enumerable
                .Range(0, pointsCount)
                .Select(i => new PointModel(From.AddTicks((long)((double)dur.Ticks * i / pointsCount)),
                                            (1.0 + 0.3 * r.NextDouble()) * hoursCount * i / pointsCount)).ToList();
            return Json(new
                        {
                            StartTime = From,
                            EndTime = To,
                            PointsData = points
                        }, JsonRequestBehavior.AllowGet);
        }
    }
}
