using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverClass.Pages;
using WebdriverClass.Widgets;

namespace WebdriverClass.PagesAtClass
{
    class WikiResultPage : BasePage
    {
        private InfoBoxWidget infoBoxWidget;
        private TableOfContentsWidget tableOfContentsWidget;

        [FindsBy(How = How.Id, Using = "firstHeading")]
        public IWebElement H1Element { get; set; }

       

        public WikiResultPage(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
        public InfoBoxWidget getInfoBoxWidget()
        {
            infoBoxWidget = new InfoBoxWidget(driver);
            PageFactory.InitElements(driver, infoBoxWidget);
            return infoBoxWidget;
        }

        public TableOfContentsWidget getTableOfContentsWidget()
        {
            tableOfContentsWidget = new TableOfContentsWidget(driver);
            PageFactory.InitElements(driver, tableOfContentsWidget);
            return tableOfContentsWidget;
        }

        public WikiResultPage navigateToCityPage(string cityName)
        {
            var city = driver.FindElement(By.LinkText(cityName));
            city.Click();
            return this;
        }

        public bool textContainsTheTitle(string text)
        {
           return H1Element.Text.Contains(text);
        }
        public ReadOnlyCollection<IWebElement> geth2TitlesOfToc()
        {
            ReadOnlyCollection<IWebElement> h2TitlesOfToc = driver.FindElements(By.ClassName("mw-headline"));
            return h2TitlesOfToc;
        }

    }
}
