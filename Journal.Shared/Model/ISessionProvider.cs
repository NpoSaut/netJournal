using System.Linq;

namespace Journal.Model
{
    public interface ISessionProvider
    {
        IQueryable<ISessionModel> GetSessionsForUser(IUserModel User);
    }
}
