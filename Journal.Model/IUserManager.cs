namespace Journal.Model
{
    public interface IUserManager
    {
        UserModel GetOrCreateUserModel(string UserLogin);
    }

    public class UserManager : IUserManager
    {
        private readonly IUserActivator _activator;
        private readonly IUserModelProvider _provider;

        public UserManager(IUserModelProvider Provider, IUserActivator Activator)
        {
            _provider = Provider;
            _activator = Activator;
        }

        public UserModel GetOrCreateUserModel(string UserLogin)
        {
            return _provider.GetUserModel(UserLogin)
                   ?? _activator.ActivateUser(UserLogin);
        }
    }
}
