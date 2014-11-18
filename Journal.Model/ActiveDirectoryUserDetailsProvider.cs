using System.DirectoryServices.AccountManagement;

namespace Journal.Model
{
    /// <summary>Инструмент получения сведений о пользователе из Active Directory</summary>
    public class ActiveDirectoryUserDetailsProvider : IUserDetailsProvider
    {
        /// <summary>Получает полное имя пользователя с указанными логином</summary>
        /// <param name="UserLogin">Логин пользователя</param>
        public PersonName GetPersonName(string UserLogin)
        {
            using (var context = new PrincipalContext(ContextType.Domain))
            {
                UserPrincipal principal = UserPrincipal.FindByIdentity(context, UserLogin);
                if (principal == null) return new PersonName("Неизвестно", "Неизвестно", "Неизвестно");
                string[] nameAndPatronymic = principal.GivenName.Split(' ');
                return new PersonName(nameAndPatronymic[0],
                                      Patronymic: nameAndPatronymic[1],
                                      Surname: principal.Surname);
            }
        }
    }
}
