using Moq;
using NUnit.Framework;
using System.IO;
using System.Xml.Linq;
using XMLREADER;
using static System.Net.Mime.MediaTypeNames;

namespace XMLREADERTESTS
{
    [TestFixture]
    class EboXMLPareserTests
    {

        [Test]
        public void TestEboFileSaved()
        {
            string loadedxmlName = "odrin7justfortest.xml";
            string resultxmlName = "result_odrin7justfortest.xml";

            Mock<Filesaver> fileSaverMocker = new Mock<Filesaver>();
            fileSaverMocker.When((Filesaver fsm) => fsm.saveXdoc(It.IsAny<string>())).Setup();
            fileSaverMocker
              .Setup(fsm => fsm.saveXdoc(It.IsAny<string>()));
            EboXMLReader eboxmlReader = new EboXMLReader(fileSaverMocker.Object);

            eboxmlReader.CreateToXMLFailedTests(loadedxmlName);
            XDocument xdoc = XDocument.Load(resultxmlName);
                Assert.True(xdoc!=null);
        }

        [Test]
        public void TestAllEboTestPassesTrue()
        {
            string loadedxmlName = "odrin7justfortest.xml";
            string resultxmlName = "result_odrin7justfortest.xml";
            string path = System.IO.Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            Mock<Filesaver> fileSaverMocker = new Mock<Filesaver>();
 //           fileSaverMocker
  //            .Setup(fsm => fsm.saveXdoc(Path.Combine(path,resultxmlName)));
            EboXMLReader eboxmlReader = new EboXMLReader(fileSaverMocker.Object);
            eboxmlReader.CreateToXMLFailedTests(loadedxmlName);          
            XDocument xDoc = XDocument.Load(Path.Combine(path, resultxmlName));
            Assert.True(allElementPassed(xDoc));
        }
        [Test]
        public void TestAllEboTestPassesFalse()
        {
            string loadedxmlName = "justfortest.xml";
            Mock<Filesaver> fileSaverMocker = new Mock<Filesaver>();
            fileSaverMocker
              .Setup(fsm => fsm.setFilename(loadedxmlName));
            EboXMLReader eboxmlReader = new EboXMLReader(fileSaverMocker.Object);

            eboxmlReader.CreateToXMLPassedTests(loadedxmlName);
            XDocument xDoc = XDocument.Load(loadedxmlName);
            Assert.True(allElementFailed(xDoc));
        }        
        [Test]
        public void TestEboTetsWorkByID()
        {
            string loadedxmlName = "justfortest.xml";
            Mock<Filesaver> fileSaverMocker = new Mock<Filesaver>();
            fileSaverMocker
              .Setup(fsm => fsm.setFilename(loadedxmlName));
            EboXMLReader eboxmlReader = new EboXMLReader(fileSaverMocker.Object);

            eboxmlReader.CreateToXMLByIdTests(loadedxmlName,"1");
            XDocument xDoc = XDocument.Load(loadedxmlName);
            Assert.True(allElementFailed(xDoc));
        }
        [Test]
        public void TestNewXmlLessSize()
        {
            string loadedxmlName = "justfortest.xml";
            string savedxmlName = "Resultjustfortest.xml";
            Mock<Filesaver> fileSaverMocker = new Mock<Filesaver>();
            fileSaverMocker
              .Setup(fsm => fsm.setFilename(savedxmlName));
            EboXMLReader eboxmlReader = new EboXMLReader(fileSaverMocker.Object);
            XDocument xDoc1 = XDocument.Load(loadedxmlName);
            eboxmlReader.CreateToXMLByIdTests(loadedxmlName, "1");
            XDocument xDoc2 = XDocument.Load(loadedxmlName);
            Assert.True(lessSizeThenOld(xDoc2, xDoc1));
        }


        private bool allElementPassed(XDocument xDoc)
        {

            foreach (var sub in xDoc.Descendants("subit_result"))
            {


                foreach (var item in sub.Descendants("test_suite"))
                {
                    EboTest ebotest = new EboTest(item.Attribute("id").Value);
                    foreach (var item1 in item.Descendants("test_case"))
                    {
                        EboTestCase ebotestcase = new EboTestCase()
                        {
                            Test_caseID = item1.Attribute("id").Value,
                            Date = item1.Element("date").Value,
                            Passed = item1.Element("passed").Value,
                            Comment = item1.Element("comment").Value

                        };
                        ebotest.EboTestCases.Add(ebotestcase);
                        if (ebotestcase.Passed == "false")
                        {
                            return false;
                        }
                    }

                }
            }
            return true;
        }
        private bool allElementFailed(XDocument xDoc)
        {
            foreach (var sub in xDoc.Descendants("subit_result"))
            {


                foreach (var item in sub.Descendants("test_suite"))
                {
                    EboTest ebotest = new EboTest(item.Attribute("id").Value);
                    foreach (var item1 in item.Descendants("test_case"))
                    {
                        EboTestCase ebotestcase = new EboTestCase()
                        {
                            Test_caseID = item1.Attribute("id").Value,
                            Date = item1.Element("date").Value,
                            Passed = item1.Element("passed").Value,
                            Comment = item1.Element("comment").Value

                        };
                        ebotest.EboTestCases.Add(ebotestcase);
                        if (ebotestcase.Passed == "true")
                        {
                            return false;
                        }
                    }

                }
            }
            return true;
        }
        private bool allellementById(XDocument xDoc, string workId)
        {
            foreach (var sub in xDoc.Descendants("subit_result"))
            {


                foreach (var item in sub.Descendants("test_suite"))
                {
                    EboTest ebotest = new EboTest(item.Attribute("id").Value);
                    foreach (var item1 in item.Descendants("test_case"))
                    {
                        EboTestCase ebotestcase = new EboTestCase()
                        {
                            Test_caseID = item1.Attribute("id").Value,
                            Date = item1.Element("date").Value,
                            Passed = item1.Element("passed").Value,
                            Comment = item1.Element("comment").Value

                        };
                        ebotest.EboTestCases.Add(ebotestcase);
                        if (ebotestcase.Test_caseID != "workId")
                        {
                            return false;
                        }
                    }

                }
            }
            return true;
        }
        private bool lessSizeThenOld(XDocument xdoc1, XDocument xdoc2)
        {
            return countLineNum(xdoc2) > countLineNum(xdoc1);
        }
        private int countLineNum(XDocument xDoc)
        {
            int count = 0;
            foreach (var sub in xDoc.Descendants("subit_result"))
            {


                foreach (var item in sub.Descendants("test_suite"))
                {
                    EboTest ebotest = new EboTest(item.Attribute("id").Value);
                    foreach (var item1 in item.Descendants("test_case"))
                    {
                        EboTestCase ebotestcase = new EboTestCase()
                        {
                            Test_caseID = item1.Attribute("id").Value,
                            Date = item1.Element("date").Value,
                            Passed = item1.Element("passed").Value,
                            Comment = item1.Element("comment").Value

                        };
                        ebotest.EboTestCases.Add(ebotestcase);
                        count++;
                    }

                }
            }
            return count;
        }

    }
}
