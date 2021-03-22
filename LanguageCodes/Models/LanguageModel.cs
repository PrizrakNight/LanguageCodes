namespace LanguageCodes.Models
{
    public class LanguageModel
    {
        public string Region { get; set; }
        public string Code { get; set; }

        public override string ToString()
        {
            return $"{Region} - {Code}";
        }
    }
}
