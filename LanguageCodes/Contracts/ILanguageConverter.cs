using LanguageCodes.Models;

namespace LanguageCodes.Contracts
{
    public interface ILanguageConverter
    {
        string ToString(LanguageModel languageModel);

        LanguageModel ToLanguage(string languageString);
    }
}
