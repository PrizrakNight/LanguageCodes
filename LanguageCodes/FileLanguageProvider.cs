using LanguageCodes.Contracts;
using LanguageCodes.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LanguageCodes
{
    public class FileLanguageProvider : ILanguageProvider
    {
        public ILanguageConverter LanguageConverter { get; set; }

        public string FileName { get; }

        public FileLanguageProvider(string fileName)
        {
            FileName = !string.IsNullOrWhiteSpace(fileName) ? fileName : throw new ArgumentException("FileName must not be empty or null");
            LanguageConverter = new DefaultLanguageConverter();
        }

        public FileLanguageProvider(string fileName, ILanguageConverter languageConverter)
        {
            FileName = !string.IsNullOrWhiteSpace(fileName) ? fileName : throw new ArgumentException("FileName must not be empty or null");
            LanguageConverter = languageConverter ?? throw new ArgumentException("Language converter must not be null.");
        }

        public async Task<LanguageModel[]> GetLanguagesAsync()
        {
            var fileContent = await File.ReadAllTextAsync(FileName);
            var languageStrings = fileContent.Split(Environment.NewLine);
            var languageModels = new LanguageModel[languageStrings.Length];

            for (int i = 0; i < languageStrings.Length; i++)
            {
                languageModels[i] = LanguageConverter.ToLanguage(languageStrings[i]);
            }

            return languageModels;
        }
    }
}
