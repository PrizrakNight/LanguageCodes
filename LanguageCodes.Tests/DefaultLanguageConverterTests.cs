using LanguageCodes.Models;
using System;
using Xunit;

namespace LanguageCodes.Tests
{
    public class DefaultLanguageConverterTests
    {
        [Fact]
        public void ToString_EmptyLanguage_ReturnEmptyString()
        {
            var converter = new DefaultLanguageConverter();
            var emptyLanguage = new LanguageModel();

            var languageString = converter.ToString(emptyLanguage);

            Assert.True(string.IsNullOrWhiteSpace(languageString));
        }

        [Fact]
        public void ToString_LanguageWithContent_ReturnLanguageString()
        {
            var converter = new DefaultLanguageConverter();
            var languageModel = new LanguageModel { Region = "Russian", Code = "ru-Ru" };
            var expectedLanguageString = "Russian => ru-Ru";

            var languageString = converter.ToString(languageModel);

            Assert.Equal(expectedLanguageString, languageString);
        }

        [Fact]
        public void ToLanguage_EmptyLanguageString_ThrowArgumentException()
        {
            var converter = new DefaultLanguageConverter();
            var languageString = string.Empty;

            Assert.Throws<ArgumentException>(() => converter.ToLanguage(languageString));
        }

        [Fact]
        public void ToLanguage_IncorrectLanguageStringFormat_ThrowFormatException()
        {
            var converter = new DefaultLanguageConverter();
            var languageString = "Russian - ru-Ru";

            Assert.Throws<FormatException>(() => converter.ToLanguage(languageString));
        }

        [Fact]
        public void ToLanguage_SomeLanguageString_ReturnLanguageModel()
        {
            var converter = new DefaultLanguageConverter();
            var languageString = "Russian => ru-Ru";

            var languageModel = converter.ToLanguage(languageString);

            Assert.Equal("Russian", languageModel.Region);
            Assert.Equal("ru-Ru", languageModel.Code);
        }
    }
}
