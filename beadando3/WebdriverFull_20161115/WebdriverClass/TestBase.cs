using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebdriverClass.PagesAtClass;

namespace WebdriverClass
{
    [TestFixture]
    class TestBase
    {
        IWebDriver driver;

        public IWebDriver Driver
        {
            get
            { return driver; }
            set
            {
                driver.Quit();
                driver = value;
            }
        }

        public WikiHomePage WikiHomePage { get; set; }

        [SetUp]
        protected void Setup()
        {            
            driver = new ChromeDriver();
            WikiHomePage = new WikiHomePage(Driver);
        }

        [TearDown]
        protected void Teardown()
        {
            WikiHomePage = null;
            driver.Quit();
        }
    }
}
