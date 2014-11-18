using System;
using System.Web.Mvc;
using Journal.Model;
using Journal.WebApplication.Models.Burndown;
using Journal.WebApplication.ViewModels;

namespace Journal.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBurndownModelProvider _burndownModelProvider;
        private readonly IHomeViewModelProvider _homeViewModelProvider;
        private readonly IUserModelProvider _userProvider;

        public HomeController(IBurndownModelProvider BurndownModelProvider, IUserModelProvider UserProvider, IHomeViewModelProvider HomeViewModelProvider)
        {
            _burndownModelProvider = BurndownModelProvider;
            _userProvider = UserProvider;
            _homeViewModelProvider = HomeViewModelProvider;
        }

        public ActionResult Index()
        {
            /*using (var context = new PrincipalContext(ContextType.Domain))
            {
                var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);
                var firstName = principal.GivenName;
                var lastName = principal.Surname;
            }*/

            UserModel userModel = _userProvider.GetUserModel(User.Identity.Name);
            HomeViewModel model = _homeViewModelProvider.GetViewModel(userModel);

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
            UserModel user = _userProvider.GetUserModel(UserLogin);
            BurndownModel burndownModel = _burndownModelProvider.GetBurndownModel(From, To, user);
            return Json(burndownModel, JsonRequestBehavior.AllowGet);
        }
    }
}
