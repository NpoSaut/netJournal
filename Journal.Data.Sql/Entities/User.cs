using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journal.Data.Sql.Entities
{
    /// <summary>Пользователь</summary>
    public class User
    {
        public User() { Sessions = new HashSet<Session>(); }

        public User(string LoginName, string Name, string Surname, string Patronymic = null) : this()
        {
            this.LoginName = LoginName;
            this.Name = Name;
            this.Surname = Surname;
            this.Patronymic = Patronymic;
        }

        /// <summary>Идентификатор пользователя</summary>
        public int Id { get; set; }

        /// <summary>AD-Логин</summary>
        [Required]
        public string LoginName { get; set; }

        /// <summary>Имя</summary>
        [Required]
        public String Name { get; set; }

        /// <summary>Фамилия</summary>
        [Required]
        public String Surname { get; set; }

        /// <summary>Отчество</summary>
        public String Patronymic { get; set; }

        /// <summary>Список сессий</summary>
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
