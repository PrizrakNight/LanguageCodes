using LanguageCodes.Contracts;
using LanguageCodes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LanguageCodes
{
    public class FileStorage : ILanguageStorage
    {
        public ILanguageConverter LanguageConverter { get; }

        public string FileName { get; }

        public FileStorage(string fileName)
        {
            FileName = !string.IsNullOrWhiteSpace(fileName) ? fileName : throw new ArgumentException("FileName must not be empty or null");
            LanguageConverter = new DefaultLanguageConverter();
        }

        public FileStorage(string fileName, ILanguageConverter languageConverter)
        {
            FileName = !string.IsNullOrWhiteSpace(fileName) ? fileName : throw new ArgumentException("FileName must not be empty or null");
            LanguageConverter = languageConverter ?? throw new ArgumentException("Language converter must not be null.");
        }

        public async Task SaveLanguagesAsync(IEnumerable<LanguageModel> languageModels)
        {
            var stringBuilder = new StringBuilder();

            foreach (var languageModel in languageModels)
                stringBuilder.AppendLine(LanguageConverter.ToString(languageModel));

            await File.WriteAllTextAsync(FileName, stringBuilder.ToString());
        }
    }
}
