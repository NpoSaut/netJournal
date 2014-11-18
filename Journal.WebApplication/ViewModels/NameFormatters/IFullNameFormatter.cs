using Journal.Model;

namespace Journal.WebApplication.ViewModels.NameFormatters
{
    public interface IFullNameFormatter
    {
        string FormatFullName(PersonName PersonName);
    }
}
