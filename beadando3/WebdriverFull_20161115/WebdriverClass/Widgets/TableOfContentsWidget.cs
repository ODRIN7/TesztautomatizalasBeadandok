using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverClass.Pages;

namespace WebdriverClass.Widgets
{
    class TableOfContentsWidget  : BasePage
    {
        [FindsBy(How = How.Id, Using = "toc")]
        public IWebElement tableOfContent { get; set; }
       
        public TableOfContentsWidget(IWebDriver driver) : base(driver)
        {

        }
        public IWebElement getTocTitleElement(IWebElement element)
        {
            return element.FindElement(By.ClassName("toctext"));
        }
        public ReadOnlyCollection<IWebElement> getElementsOfToc()
        {
            return driver.FindElements(By.CssSelector("li.toclevel-1"));
        }

    }
}
