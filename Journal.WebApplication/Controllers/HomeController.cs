using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Journal.Model;
using Journal.WebApplication.Models.Burndown;
using Journal.WebApplication.ViewModels;

namespace Journal.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private const int CurrentUserId = 1;
        private readonly IBurndownModelProvider _burndownModelProvider;
        private readonly ISessionProvider _sessionProvider;
        private readonly IUserProvider _userProvider;

        public HomeController(IUserProvider UserProvider, ISessionProvider SessionProvider, IBurndownModelProvider BurndownModelProvider)
        {
            _burndownModelProvider = BurndownModelProvider;
            _sessionProvider = SessionProvider;
            _userProvider = UserProvider;
        }

        public ActionResult Index()
        {
            /*using (var context = new PrincipalContext(ContextType.Domain))
            {
                var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);
                var firstName = principal.GivenName;
                var lastName = principal.Surname;
            }*/

            IUserModel user = _userProvider.GetUserModel(User.Identity.Name);

            List<SessionViewModel> sessions = _sessionProvider.GetSessionsForUser(user)
                                                              .OrderByDescending(s => s.StartTime)
                                                              .Take(10)
                                                              .Select(s => new SessionViewModel(s.StartTime, s.EndTime))
                                                              .ToList();
            var model = new HomeViewModel(user.LoginName, string.Format("{0} {1} {2}", user.Name, user.Patronymic, user.Surname),
                                          sessions);

            return View(model);
        }

        public ActionResult OpenSession(DateTime StartTime, int UserId)
        {
            //            var session = new Session(StartTime, null, UserId);
            //            _sessionRepository.AddSession(session);
            //            return View("Success");
            throw new Exception();
        }

        public ActionResult CloseSession(DateTime EndTime, int UserId)
        {
            //            Session session = _sessionRepository.GetOpenSession(UserId);
            //            session.EndTime = EndTime;
            //            _sessionRepository.SaveSessionChanged(session);
            //            return View("Success");
            throw new Exception();
        }

        public JsonResult Burndown(DateTime From, DateTime To, string UserLogin)
        {
            IUserModel user = _userProvider.GetUserModel(UserLogin);
            BurndownModel burndownModel = _burndownModelProvider.GetBurndownModel(From, To, user);
            return Json(burndownModel, JsonRequestBehavior.AllowGet);
        }
    }
}
