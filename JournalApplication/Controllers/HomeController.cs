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

        private const int UserId = 1;
        private readonly ISessionRepository _sessionRepository = new EntityFrameworkSessionsRepository();
        private readonly IUsersRepository _usersRepository = new EntityFrameworkUserRepository();

        public ActionResult Index()
        {
            User user = _usersRepository.GetUserById(UserId);

            var model = new HomeViewModel(user.Name,
                                          _sessionRepository.GetSessions(user.Id)
                                                            .Select(s => new SessionViewModel(s.StartTime, s.EndTime))
                                                            .ToList());
            return View(model);
        }

        public ActionResult OpenSession(DateTime StartTime)
        {
            var session = new Session(StartTime, null, UserId);
            _sessionRepository.AddSession(session);
            return View("AddRecord");
        }

        public ActionResult AddRecord(DateTime Start, DateTime End)
        {
            var session = new Session(Start, End, UserId);
            _sessionRepository.AddSession(session);
            return View();
        }
    }
}
