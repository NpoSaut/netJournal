using Journal.Model;

namespace Journal.WebApplication.ViewModels.NameFormatters
{
    /// <summary>Конструктор обращений</summary>
    public interface IAppealFormatter
    {
        /// <summary>Форматирует обращение к пользователю</summary>
        /// <param name="PersonName">Полное наименование пользователя</param>
        string FormatAppeal(PersonName PersonName);
    }
}