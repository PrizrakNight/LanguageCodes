using LanguageCodes.Models;
using System.Threading.Tasks;

namespace LanguageCodes.Contracts
{
    public interface ILanguageProvider
    {
        Task<LanguageModel[]> GetLanguagesAsync();
    }
}
