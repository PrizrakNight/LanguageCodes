using System;
using System.Threading.Tasks;
using Xunit;

namespace LanguageCodes.Tests
{
    public class AndiamoLanguageProviderTests
    {
        [Fact]
        public async Task GetLanguagesAsync_ShouldReturn125()
        {
            var provider = new AndiamoLanguageProvider();

            var languageModels = await provider.GetLanguagesAsync();

            Assert.Equal(125, languageModels.Length);
        }

        [Fact]
        public void GetLanguagesAsync_DisposedProvider_ThrowObjectDisposedException()
        {
            var provider = new AndiamoLanguageProvider();

            provider.Dispose();

            Assert.ThrowsAsync<ObjectDisposedException>(async () => await provider.GetLanguagesAsync());
        }
    }
}
