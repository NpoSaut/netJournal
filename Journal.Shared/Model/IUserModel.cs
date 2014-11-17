using System;
using System.Linq;

namespace Journal.Model
{
    /// <summary>Пользователь</summary>
    public interface IUserModel
    {
        /// <summary>AD-Логин</summary>
        string LoginName { get; set; }

        /// <summary>Имя</summary>
        String Name { get; set; }

        /// <summary>Фамилия</summary>
        String Surname { get; set; }

        /// <summary>Отчество</summary>
        String Patronymic { get; set; }
    }
}
