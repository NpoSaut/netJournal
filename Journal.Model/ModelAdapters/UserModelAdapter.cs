using System.Linq;
using Journal.Data.Sql.Entities;

namespace Journal.Model.ModelAdapters
{
    internal class UserModelAdapter : IUserModel
    {
        private readonly User _user;
        public UserModelAdapter(User User) { _user = User; }

        /// <summary>AD-Логин</summary>
        public string LoginName
        {
            get { return _user.LoginName; }
            set { _user.LoginName = value; }
        }

        /// <summary>Имя</summary>
        public string Name
        {
            get { return _user.Name; }
            set { _user.Name = value; }
        }

        /// <summary>Фамилия</summary>
        public string Surname
        {
            get { return _user.Surname; }
            set { _user.Surname = value; }
        }

        /// <summary>Отчество</summary>
        public string Patronymic
        {
            get { return _user.Patronymic; }
            set { _user.Patronymic = value; }
        }
    }
}
