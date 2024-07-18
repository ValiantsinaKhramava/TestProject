using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using TestProject.Core;

namespace TestProject.WebDriver
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService();
                        ChromeOptions options = new();
                        options.AddArgument("--no-sandbox");
                        options.AddArgument("disable-infobars");
                        options.AddArgument("--incognito");
                        options.AddArgument("--disable-dev-shm-usage");

                        // Add headless run option
                        if (Configuration.Headless)
                        {
                            options.AddArgument("--headless");
                        }
                        return new ChromeDriver(service, options, TimeSpan.FromSeconds(30));
                    }
                case BrowserType.Edge:
                    return new EdgeDriver();
                case BrowserType.Firefox:
                    return new FirefoxDriver();
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
        }
    }

    public enum BrowserType
    {
        Chrome,
        Edge,
        Firefox
    }
}