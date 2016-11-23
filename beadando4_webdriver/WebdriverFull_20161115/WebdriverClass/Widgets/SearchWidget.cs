using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using WebdriverClass.Pages;

namespace WebdriverClass.Widgets
{
    class SearchWidget : BasePage
    {
        public SearchWidget(IWebDriver driver) : base(driver)
        {
        }
        [FindsBy(How = How.Id, Using = "searchLanguage")]
        public IWebElement searchLanguage { get; set; }

        [FindsBy(How = How.Id, Using = "searchInput")]
        public IWebElement searchInput { get; set; }
        
        public void SelectSearchLanguage(String selectLanguage)
        {
            var elementSelector = new SelectElement(searchLanguage);
            elementSelector.SelectByValue(selectLanguage);
        }

        public void Search(String text)
        {         
            searchInput.SendKeys(text);
            searchInput.Submit();
        }
    }
}
