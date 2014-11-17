using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journal.Data.Sql.Entities
{
    /// <summary>������������</summary>
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

        /// <summary>������������� ������������</summary>
        public int Id { get; set; }

        /// <summary>AD-�����</summary>
        [Required]
        public string LoginName { get; set; }

        /// <summary>���</summary>
        [Required]
        public String Name { get; set; }

        /// <summary>�������</summary>
        [Required]
        public String Surname { get; set; }

        /// <summary>��������</summary>
        public String Patronymic { get; set; }

        /// <summary>������ ������</summary>
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
