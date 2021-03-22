using HtmlAgilityPack;
using LanguageCodes.Contracts;
using LanguageCodes.Models;
using System.Threading.Tasks;

namespace LanguageCodes
{
    public class AndiamoLanguageProvider : ILanguageProvider
    {
        public Task<LanguageModel[]> GetLanguagesAsync()
        {
            var web = new HtmlWeb();
            var document = web.Load("https://www.andiamo.co.uk/resources/iso-language-codes/");
            var tableRows = document.DocumentNode.SelectNodes("//table//tbody//tr");

            return Task.FromResult(ToLanguageModels(tableRows));
        }

        private LanguageModel[] ToLanguageModels(HtmlNodeCollection tableRows)
        {
            var result = new LanguageModel[tableRows.Count];

            for (int i = 0; i < tableRows.Count; i++)
            {
                result[i] = new LanguageModel
                {
                    Region = tableRows[i].ChildNodes[0].InnerText.Trim(),
                    Code = tableRows[i].ChildNodes[1].InnerText.Trim()
                };
            }

            return result;
        }
    }
}
