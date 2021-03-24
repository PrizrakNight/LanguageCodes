using LanguageCodes.Contracts;
using LanguageCodes.Models;
using System;

namespace LanguageCodes
{
    public class DefaultLanguageConverter : ILanguageConverter
    {
        public LanguageModel ToLanguage(string languageString)
        {
            if (string.IsNullOrWhiteSpace(languageString))
                throw new ArgumentException("LanguageString must not be empty or null");

            var args = languageString.Split("=>");

            if (args.Length != 2)
                throw new FormatException("Incorrect languageString format");

            return new LanguageModel
            {
                Region = args[0].Trim(),
                Code = args[1].Trim()
            };
        }

        public string ToString(LanguageModel languageModel)
        {
            if (string.IsNullOrWhiteSpace(languageModel.Region) && string.IsNullOrWhiteSpace(languageModel.Code))
                return string.Empty;

            return $"{languageModel.Region} => {languageModel.Code}";
        }
    }
}
