using System;

namespace Journal.Model
{
    /// <summary>Полное имя персонажа</summary>
    public class PersonName
    {
        /// <summary>Инициализирует новый экземпляр класса <see cref="T:System.Object" />.</summary>
        /// <param name="Name">Имя</param>
        /// <param name="Surname">Фамилия</param>
        /// <param name="Patronymic">Отчество</param>
        public PersonName(string Name, string Surname, string Patronymic = null)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Patronymic = Patronymic;
        }

        /// <summary>Имя</summary>
        public String Name { get; private set; }

        /// <summary>Фамилия</summary>
        public String Surname { get; private set; }

        /// <summary>Отчество</summary>
        public String Patronymic { get; private set; }
    }
}
