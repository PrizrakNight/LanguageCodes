using LanguageCodes.Models;
using LanguageCodes.Tests.Fixtures;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace LanguageCodes.Tests
{
    public class FileStorageTests : IClassFixture<FilesFixture>
    {
        private readonly FilesFixture _filesFixture;

        private readonly string _filePath;

        public FileStorageTests(FilesFixture filesFixture)
        {
            _filesFixture = filesFixture;
            _filePath = Path.Combine(_filesFixture.ApplicationFilesPath, "CreatedLanguageStorage.txt");
        }

        [Fact]
        public async Task SaveLanguagesAsync_SomeLanguage_CreateNotEmptyFile()
        {
            var fileStorage = new FileStorage(_filePath);
            var languageModels = new LanguageModel[] { new LanguageModel { Region = "Russian", Code = "ru-RU" } };

            await fileStorage.SaveLanguagesAsync(languageModels);

            var fileContent = await File.ReadAllTextAsync(_filePath);

            Assert.False(string.IsNullOrWhiteSpace(fileContent));
        }
    }
}
