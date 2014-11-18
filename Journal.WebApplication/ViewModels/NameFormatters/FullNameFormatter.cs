using Journal.Model;

namespace Journal.WebApplication.ViewModels.NameFormatters
{
    internal class FullNameFormatter : IFullNameFormatter
    {
        public string FormatFullName(PersonName PersonName) { return string.Join(" ", new[] { PersonName.Surname, PersonName.Name, PersonName.Patronymic }); }
    }
}
