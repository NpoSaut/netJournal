using System;
using System.Linq;
using System.Web.Mvc;
using Journal.Data;
using Journal.Data.Sql;
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
    }
}
