using HtmlAgilityPack;
using LanguageCodes.Contracts;
using LanguageCodes.Models;
using System;
using System.Threading.Tasks;

namespace LanguageCodes
{
    public class AndiamoLanguageProvider : ILanguageProvider, IDisposable
    {
        private HtmlDocument _document;

        private bool _disposed;

        public async Task<LanguageModel[]> GetLanguagesAsync() 
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AndiamoLanguageProvider));

            if (_document == default)
            {
                var web = new HtmlWeb();

                _document = await web.LoadFromWebAsync("https://www.andiamo.co.uk/resources/iso-language-codes/");
            }

            var tableRows = _document.DocumentNode.SelectNodes("//table//tbody//tr");

            return ToLanguageModels(tableRows);
        }

        public void Dispose()
        {
            _document = default;
            _disposed = true;
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
