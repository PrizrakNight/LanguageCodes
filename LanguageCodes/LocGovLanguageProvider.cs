using HtmlAgilityPack;
using LanguageCodes.Contracts;
using LanguageCodes.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCodes
{
    public class LocGovLanguageProvider : ILanguageProvider, IDisposable
    {
        #region NestedTypes

        public enum RegionName
        {
            English,
            French,
            German
        }

        public enum CodeType
        {
            Iso639_2,
            Iso639_1
        }

        #endregion

        public RegionName Region { get; set; }
        public CodeType Code { get; set; }

        private HtmlDocument _document;

        private bool _disposed;

        public LocGovLanguageProvider(RegionName region = RegionName.English, CodeType code = CodeType.Iso639_2)
        {
            Region = region;
            Code = code;
        }

        public async Task<LanguageModel[]> GetLanguagesAsync()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LocGovLanguageProvider));

            if (_document == default)
            {
                var web = new HtmlWeb();

                _document = await web.LoadFromWebAsync("https://www.loc.gov/standards/iso639-2/php/code_list.php");
            }

            var nodes = _document.DocumentNode.SelectNodes("//tr[count(./*) = 5 and position() > 1]");

            return ToLanguageModels(nodes);
        }

        public void Dispose()
        {
            _document = default;
            _disposed = true;
        }

        private LanguageModel[] ToLanguageModels(HtmlNodeCollection nodes)
        {
            var result = new LanguageModel[nodes.Count];

            for (int i = 0; i < nodes.Count; i++)
            {
                var nodeDescendants = nodes[i].Descendants("td").ToArray();
                var languageCode = nodeDescendants[(int)Code].InnerText;
                var languageRegion = nodeDescendants[2 + (int)Region].InnerText;

                result[i] = new LanguageModel
                {
                    Region = languageRegion.Trim(),
                    Code = languageCode.Trim()
                };
            }

            return result;
        }
    }
}
