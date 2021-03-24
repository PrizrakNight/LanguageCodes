using LanguageCodes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LanguageCodes.Contracts
{
    public interface ILanguageStorage
    {
        Task SaveLanguagesAsync(IEnumerable<LanguageModel> languageModels);
    }
}
