using Journal.Model;

namespace Journal.WebApplication.ViewModels.NameFormatters
{
    public class NameAndPatronymicAppealFormatter : IAppealFormatter
    {
        /// <summary>Форматирует обращение к пользователю</summary>
        /// <param name="PersonName">Полное наименование пользователя</param>
        public string FormatAppeal(PersonName PersonName) { return string.Join(" ", new[] { PersonName.Name, PersonName.Patronymic }); }
    }
}