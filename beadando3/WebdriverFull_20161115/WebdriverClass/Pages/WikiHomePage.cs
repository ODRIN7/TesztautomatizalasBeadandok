using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using WebdriverClass.Pages;
using WebdriverClass.Widgets;

namespace WebdriverClass.PagesAtClass
{
    class WikiHomePage : BasePage
    {
        private SearchWidget searchWidget;

        public WikiHomePage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public static WikiHomePage navigate(IWebDriver webDriver)
        {
            webDriver.Navigate().GoToUrl("https://www.wikipedia.org/");
            return new WikiHomePage(webDriver);
        }

        public SearchWidget getSearchWidget()
        {
            searchWidget = new SearchWidget(driver);
            PageFactory.InitElements(driver, searchWidget);
            return searchWidget;
        }

        public WikiResultPage OpenSchoolPage(string lang, string schoolName)
        {
            navigate(driver);            
            getSearchWidget().SelectSearchLanguage(lang);
            getSearchWidget().Search(schoolName);
            return new WikiResultPage(driver);
        }

    }
}
