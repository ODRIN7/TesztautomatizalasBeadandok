using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.Xml.Linq;
using XMLREADER;
using static System.Net.Mime.MediaTypeNames;

namespace XMLREADERTESTS
{
    [TestFixture]
    class EboXMLPareserTests
    {
        string fileUri;
        string loadedxmlName;
        string resultxmlName;
        string workById;
        IOEboXMLReader eboXmlReader;
        IFilesaver mockfilesaver;

      [SetUp]
        protected void Setup()
        {
            fileUri = AppDomain.CurrentDomain.BaseDirectory;
            loadedxmlName = "odrin7justfortest.xml";
            resultxmlName = "result_odrin7justfortest.xml";
            workById = "10.1";
            mockfilesaver = new MockFileSaver(fileUri, resultxmlName, loadedxmlName);
            eboXmlReader = new EboXMLReader(mockfilesaver);
        }

        [TearDown]
        protected void TearDown()
        {
           
            File.Delete(Path.Combine(fileUri, resultxmlName));
        }

        [Test]
        public void TestEboFileSaved()
        {            
            eboXmlReader.CreateToXMLFailedTests(null,null,null);
            XDocument xdoc = XDocument.Load(Path.Combine(fileUri,resultxmlName));
            Assert.True(xdoc!=null);
        }

        [Test]
        public void TestAllEboTestPassesTrue()
        {
            eboXmlReader.CreateToXMLPassedTests(null, null, null);
            XDocument xdoc = XDocument.Load(Path.Combine(fileUri, resultxmlName));
            Assert.True(allElementPassed(xdoc));
        }

        [Test]
        public void TestAllEboTestPassesFalse()
        {
            eboXmlReader.CreateToXMLFailedTests(null, null, null);
            XDocument xdoc = XDocument.Load(Path.Combine(fileUri, resultxmlName));
            Assert.True(allElementFailed(xdoc));
        }        

        [Test]
        public void TestEboTetsWorkByID()
        {
            eboXmlReader.CreateToXMLByIdTests(null, null, null,workById);
            XDocument xdoc = XDocument.Load(Path.Combine(fileUri, resultxmlName));
            Assert.True(allellementById(xdoc,workById));
        }

        [Test]
        public void TestNewXmlLessSize()
        {
            eboXmlReader.CreateToXMLByIdTests(null, null, null, workById);
            XDocument xdocResult = XDocument.Load(Path.Combine(fileUri, resultxmlName));
            XDocument xdocLoaded = mockfilesaver.loadXdoc(fileUri, loadedxmlName);
            Assert.True(lessSizeThenOld(xdocResult, xdocLoaded));
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
