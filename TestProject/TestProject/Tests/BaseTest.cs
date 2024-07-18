using NUnit.Framework;
using TestProject.Core;
using TestProject.Core.WebDriver;
using TestProject.WebDriver;

namespace TestProject.TestsUI
{
    public abstract class BaseTest
    {
        protected WebDriverWrapper WebDriverWrapper { get; private set; }
        protected Logger Logger { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            var browserType = (BrowserType)Enum.Parse(typeof(BrowserType),
                Configuration.BrowserType);

            WebDriverWrapper = new WebDriverWrapper(browserType);
            WebDriverWrapper.StartBrowser();
            WebDriverWrapper.NavigateTo(Configuration.AppUrl);

            Logger ??= new Logger();
        }

        [TearDown]
        public virtual void TearDown()
        {
            WebDriverWrapper.Close();
        }
    }
}
