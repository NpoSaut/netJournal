namespace Journal.WebApplication.ViewModels
{
    /// <summary>Модель представления пользователя</summary>
    public class UserViewModel
    {
        public UserViewModel(string Login, string Appeal, string FullName)
        {
            this.Login = Login;
            this.Appeal = Appeal;
            this.FullName = FullName;
        }

        /// <summary>Логин</summary>
        public string Login { get; private set; }

        /// <summary>Обращение</summary>
        public string Appeal { get; private set; }

        /// <summary>Полное имя</summary>
        public string FullName { get; private set; }
    }
}
