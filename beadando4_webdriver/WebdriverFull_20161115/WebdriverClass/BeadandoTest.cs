using System;
using System.Linq;
using NUnit.Framework;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using WebdriverClass.PagesAtClass;

namespace WebdriverClass
{
    class BeadandoTest : TestBase
    {

        [Test, TestCaseSource("testData")]
        public void TitleChangedTest(string lang, string schoolName, string linkOfCityName)
        {
            string title = "";
            WikiHomePage.OpenSchoolPage(lang, schoolName);
            title = assertTitleChange(title);
            Assert.AreEqual(title, Driver.Title);
        }

        [Test, TestCaseSource("testData")]
        public void H1TitleTest(string lang, string schoolName, string linkOfCityName)
        {         
            WikiResultPage wikiResultPage =
                WikiHomePage.OpenSchoolPage(lang, schoolName);
            Assert.True(wikiResultPage.textContainsTheTitle(schoolName));
        }

        [Test, TestCaseSource("testData")]
        public void ExistingInfoBoxTest(string lang, string schoolName, string linkOfCityName)
        {   
            Assert.IsNotNull(WikiHomePage
                .OpenSchoolPage(lang, schoolName)
                .getInfoBoxWidget().infobox);
        }

        [Test, TestCaseSource("testData")]
        public void ExistingTableOfContentTest(string lang, string schoolName, string linkOfCityName)
        {
            Assert.IsNotNull(WikiHomePage
                  .OpenSchoolPage(lang, schoolName)
                  .getTableOfContentsWidget().tableOfContent);
        }

        [Test, TestCaseSource("testData")]
        public void CheckTableOfContentLinksTest(string lang, string schoolName, string linkOfCityName)
        {
            WikiResultPage obudaiPage = WikiHomePage
                .OpenSchoolPage(lang, schoolName);

            tocAssert(obudaiPage);
        }

        [Test, TestCaseSource("testData")]
        public void CheckBudapestLinksTest(string lang, string schoolName, string linkOfCityName)
        {

            WikiResultPage budapestPage = WikiHomePage
                .OpenSchoolPage(lang, schoolName)
                .navigateToCityPage(linkOfCityName);

            tocAssert(budapestPage);
          
        }
        
        private void tocAssert(WikiResultPage obudaiPage)
        {
            foreach (var item in obudaiPage.getTableOfContentsWidget().getElementsOfToc())
            {
                var tocElement = obudaiPage.getTableOfContentsWidget().getTocTitleElement(item);
                tocElement.Click();
                CollectionAssert.IsNotEmpty(obudaiPage.geth2TitlesOfToc().Select(s => s.Text.Equals(tocElement.Text)));
            }

        }

        private String assertTitleChange(String oldTitle)
        {
            String newTitle = Driver.Title;
            Assert.AreNotEqual(oldTitle, newTitle);
            return newTitle;
        }

        static IEnumerable testData()
        {
            var doc = XElement.Load(AssemblyDirectory + "\\data.xml");
            return
                from vars in doc.Descendants("testData")
                let lang = vars.Attribute("lang").Value
                let schoolName = vars.Attribute("schoolName").Value
                let linkOfCityName = vars.Attribute("linkOfCityName").Value

                select new object[] { lang, schoolName, linkOfCityName };
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

    }
}
