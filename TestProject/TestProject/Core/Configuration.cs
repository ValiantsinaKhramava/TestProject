﻿using Microsoft.Extensions.Configuration;

namespace TestProject.Core
{
    public class Configuration
    {
        public static string BrowserType = GetAppSettingsValue("BrowserType", "Chrome");
        public static string AppUrl = GetAppSettingsValue("ApplicationUrl", string.Empty);
        public static string TestDataPath = GetAppSettingsValue("TestDataPath", string.Empty);
        public static bool Headless = GetAppSettingsBoolValue("Headless", false);

        public static string GetAppSettingsValue(string value, string defaultValue)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            return configuration[$"{value}"] ?? defaultValue;
        }

        private static bool GetAppSettingsBoolValue(string value, bool defaultValue)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string configValue = configuration[$"{value}"];

            if (bool.TryParse(configValue, out bool result))
            {
                return result;
            }

            return defaultValue;
        }
    }
}
