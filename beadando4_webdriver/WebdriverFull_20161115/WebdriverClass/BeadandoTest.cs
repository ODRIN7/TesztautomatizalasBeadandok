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
        public void EndToEndTest(string lang, string schoolName, string linkOfCityName)
        {         
            WikiResultPage wikiResultPage =
                WikiHomePage.OpenSchoolPage(lang, schoolName)
                .setPageSizeMax();
            //1
            Assert.True(wikiResultPage.textContainsTheTitle(schoolName));
            Assert.True(wikiResultPage.H1Element.Displayed);
            //2
            Assert.True(wikiResultPage
              .getInfoBoxWidget()
              .infobox
              .Displayed);
            //3
            Assert.True(wikiResultPage
                 .getTableOfContentsWidget()
                 .tableOfContent
                 .Displayed);
            //4
            Assert.True(wikiResultPage
                .getTableOfContentsWidget()
                .tableOfContent
                .Displayed);
            //5
            tocAssert(wikiResultPage);
            //6
            tocAssert(wikiResultPage);
            //7
            wikiResultPage
                .navigateToCityPage(linkOfCityName)
                .setPageSizeMax();
            Assert.True(wikiResultPage.textContainsTheTitle("Budapest"));
            Assert.True(wikiResultPage.H1Element.Displayed);

            Assert.True(wikiResultPage
              .getTableOfContentsWidget()
              .tableOfContent
              .Displayed);

            Assert.True(wikiResultPage
               .getInfoBoxWidget()
               .infobox
               .Displayed);
            tocAssert(wikiResultPage);
        }     
        
        private void tocAssert(WikiResultPage obudaiPage)
        {
            foreach (var item in obudaiPage.getTableOfContentsWidget().getElementsOfToc())
            {
                var tocElement = obudaiPage.getTableOfContentsWidget().getTocTitleElement(item);
                tocElement.Click();
                CollectionAssert.IsNotEmpty(obudaiPage.geth2TitlesOfToc().Select(s => s.Text.Equals(tocElement.Text) && s.Displayed));

            }

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
