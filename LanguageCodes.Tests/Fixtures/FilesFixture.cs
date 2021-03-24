using System;
using System.IO;
using System.Reflection;

namespace LanguageCodes.Tests.Fixtures
{
    public class FilesFixture
    {
        public string ApplicationFilesPath { get; set; }
        public string ApplicationPath { get; }

        public FilesFixture()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var path = Uri.UnescapeDataString(new UriBuilder(codeBase).Path);

            ApplicationPath = Path.GetDirectoryName(path);
            ApplicationFilesPath = Path.Combine(ApplicationPath, "Files");
        }
    }
}
