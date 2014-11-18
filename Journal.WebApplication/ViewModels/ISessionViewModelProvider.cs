using Journal.Model;

namespace Journal.WebApplication.ViewModels
{
    public interface ISessionViewModelProvider
    {
        SessionViewModel GetViewModel(SessionModel Model);
    }

    public class SessionViewModelProvider : ISessionViewModelProvider
    {
        public SessionViewModel GetViewModel(SessionModel Model) { return new SessionViewModel(Model.StartTime, Model.EndTime); }
    }
}
