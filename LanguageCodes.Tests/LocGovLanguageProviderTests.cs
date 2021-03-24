using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LanguageCodes.Tests
{
    public class LocGovLanguageProviderTests
    {
        private readonly LocGovLanguageProvider _provider = new LocGovLanguageProvider();

        [Fact]
        public async Task GetLanguagesAsync_ShouldReturn507()
        {
            var languageModels = await _provider.GetLanguagesAsync();

            Assert.Equal(507, languageModels.Length);
        }

        [Fact]
        public async Task GetLanguagesAsync_RegionEnglish_ReturnFirstEnglish()
        {
            _provider.Region = LocGovLanguageProvider.RegionName.English;

            var firstModel = (await _provider.GetLanguagesAsync()).First();

            Assert.Equal("Afar", firstModel.Region);
        }

        [Fact]
        public async Task GetLanguagesAsync_RegionFrench_ReturnFirstFrench()
        {
            _provider.Region = LocGovLanguageProvider.RegionName.French;

            var firstModel = (await _provider.GetLanguagesAsync()).First();

            Assert.Equal("afar", firstModel.Region);
        }

        [Fact]
        public async Task GetLanguagesAsync_RegionGerman_ReturnFirstGerman()
        {
            _provider.Region = LocGovLanguageProvider.RegionName.German;

            var firstModel = (await _provider.GetLanguagesAsync()).First();

            Assert.Equal("Danakil-Sprache", firstModel.Region);
        }

        [Fact]
        public async Task GetLanguagesAsync_CodeIso639_2_ReturnFirst()
        {
            _provider.Code = LocGovLanguageProvider.CodeType.Iso639_2;

            var firstModel = (await _provider.GetLanguagesAsync()).First();

            Assert.Equal("aar", firstModel.Code);
        }

        [Fact]
        public async Task GetLanguagesAsync_CodeIso639_1_ReturnFirst()
        {
            _provider.Code = LocGovLanguageProvider.CodeType.Iso639_1;

            var firstModel = (await _provider.GetLanguagesAsync()).First();

            Assert.Equal("aa", firstModel.Code);
        }

        [Fact]
        public void GetLanguagesAsync_DisposedProvider_ThrowObjectDisposedException()
        {
            var provider = new LocGovLanguageProvider();

            provider.Dispose();

            Assert.ThrowsAsync<ObjectDisposedException>(async () => await provider.GetLanguagesAsync());
        }
    }
}
