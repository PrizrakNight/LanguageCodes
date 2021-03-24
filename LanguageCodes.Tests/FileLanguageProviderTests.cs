using LanguageCodes.Tests.Fixtures;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace LanguageCodes.Tests
{
    public class FileLanguageProviderTests : IClassFixture<FilesFixture>
    {
        private readonly FilesFixture _filesFixture;

        public FileLanguageProviderTests(FilesFixture filesFixture)
        {
            _filesFixture = filesFixture;
        }

        [Fact]
        public async Task GetLanguagesAsync_CorrectFormat_RetrunOneLanguageModel()
        {
            var provider = new FileLanguageProvider(Path.Combine(_filesFixture.ApplicationFilesPath, "LanguageStorageCorrectFormat.txt"));

            var languageModels = await provider.GetLanguagesAsync();

            Assert.Single(languageModels);
        }

        [Fact]
        public void GetLanguagesAsync_IncorrectFormat_ThrowFormatException()
        {
            var provider = new FileLanguageProvider(Path.Combine(_filesFixture.ApplicationFilesPath, "LanguageStorageIncorrectFormat.txt"));

            Assert.ThrowsAsync<FormatException>(async () => await provider.GetLanguagesAsync());
        }
    }
}
