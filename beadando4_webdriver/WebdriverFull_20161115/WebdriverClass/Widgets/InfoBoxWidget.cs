using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverClass.Pages;

namespace WebdriverClass.Widgets
{
    class InfoBoxWidget : BasePage
    {
        [FindsBy(How = How.ClassName, Using = "infobox")]
        public IWebElement infobox { get; set; }

        public InfoBoxWidget(IWebDriver driver) : base(driver)
        {

        }

    }
}
