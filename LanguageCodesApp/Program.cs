using LanguageCodes;
using LanguageCodes.Contracts;
using System;

namespace LanguageCodesApp
{
    public class Program
    {
        private static readonly ILanguageProvider _languageProvider = new AndiamoLanguageProvider();

        private static void Main(string[] args)
        {
            Console.WriteLine("Parsing the site of language codes...");

            var languages = _languageProvider.GetLanguagesAsync().Result;

            Console.WriteLine($"Received '{languages.Length}' language codes");

            Array.ForEach(languages, Console.WriteLine);

            Console.WriteLine("Press any key for exit.");
            Console.ReadKey(true);
        }
    }
}
