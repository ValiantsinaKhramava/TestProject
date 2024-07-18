using Microsoft.Extensions.Configuration;

namespace TestProject.Core
{
    public class Configuration
    {
        public static string BrowserType { get; private set; }
        public static string AppUrl { get; private set; }
        public static string TestDataPath { get; private set; }
        public static bool Headless { get; private set; }

        static Configuration()
        {
            Init();
        }

        public static void Init()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();

            BrowserType = configuration["BrowserType"] ?? "Chrome";
            AppUrl = configuration["ApplicationUrl"] ?? string.Empty;
            TestDataPath = configuration["TestDataPath"] ?? string.Empty;

            string headless = configuration["Headless"] ?? "False";
            Headless = bool.TryParse(headless, out bool result) ? result : false;
        }
    }
}
