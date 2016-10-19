using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLREADER
{
   public  class EboXMLReader : IOEboXMLReader
    {
        private Filesaver filesaver;
        private static List<EboTest> eboTests;
        public string filename;

        public EboXMLReader(Filesaver filesaver)
        {
            eboTests = new List<EboTest>();
            this.filesaver = filesaver;

        }      
       
        public  void CreateToXMLFailedTests(string filename)
        {
            LoadEboTestcase(filesaver.loadXdoc(filename));
            this.filename = filename;
            CreateXMLPARSERFailedTests();
          
        }
        public void CreateToXMLPassedTests(string filename)
        {
            LoadEboTestcase(filesaver.loadXdoc(filename));
            this.filename = filename;
            CreateXMLPARSERPassedTests();

        }
        public void CreateToXMLByIdTests(string filename,string workId)
        {
            LoadEboTestcase(filesaver.loadXdoc(filename));
            this.filename = filename;
            CreateXMLPARSERByIdTests(workId);

        }
        private List<EboTest> LoadEboTestcase(XDocument xDoc)
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

                    }
                    eboTests.Add(ebotest);

                }
            }
            return eboTests;
        }
        private void CreateXMLPARSERFailedTests()
        {
        XDocument xDoc = new XDocument();
        XElement sub = new XElement("subit_result");
        foreach (var currEboTest in eboTests)
        {
            XElement testsuit = new XElement("test_suite");
            testsuit.Add(new XAttribute("id", currEboTest.Test_suiteID));
            bool isFailed = false;
            foreach (var currEboTestCase in currEboTest.EboTestCases)
            {

                XElement testcase = new XElement("test_case");
                testcase.Add(new XAttribute("id", currEboTestCase.Test_caseID));
                testcase.Add(new XElement("date", currEboTestCase.Date));
                testcase.Add(new XElement("passed", currEboTestCase.Passed));
                testcase.Add(new XElement("comment", new XCData(currEboTestCase.Comment)));
                if (currEboTestCase.Passed == "false")
                {
                    isFailed = true;
                    testsuit.Add(testcase);
                }
              
            }
            if (isFailed)
            {
                sub.Add(testsuit);
                isFailed = false;
            }
            }

            xDoc.Add(sub);
            filesaver.XDoc = xDoc;
            filesaver.setFilename("result" + filename);
            filesaver.saveXdoc();
        }
        private void CreateXMLPARSERPassedTests()
        {
            XDocument xDoc = new XDocument();
            XElement sub = new XElement("subit_result");
            foreach (var currEboTest in eboTests)
            {
                XElement testsuit = new XElement("test_suite");
                testsuit.Add(new XAttribute("id", currEboTest.Test_suiteID));
                bool passed = false;
                foreach (var currEboTestCase in currEboTest.EboTestCases)
                {

                    XElement testcase = new XElement("test_case");
                    testcase.Add(new XAttribute("id", currEboTestCase.Test_caseID));
                    testcase.Add(new XElement("date", currEboTestCase.Date));
                    testcase.Add(new XElement("passed", currEboTestCase.Passed));
                    testcase.Add(new XElement("comment", new XCData(currEboTestCase.Comment)));
                    if (currEboTestCase.Passed == "true")
                    {
                        passed = true;
                        testsuit.Add(testcase);
                    }

                }
                if (passed)
                {
                    sub.Add(testsuit);
                    passed = false;
                }
            }

            xDoc.Add(sub);
            filesaver.XDoc = xDoc;
            filesaver.setFilename("result" + filename);
            filesaver.saveXdoc();
        }
        private void CreateXMLPARSERByIdTests(string id)
        {
            XDocument xDoc = new XDocument();
            XElement sub = new XElement("subit_result");
            foreach (var currEboTest in eboTests)
            {
                XElement testsuit = new XElement("test_suite");
                testsuit.Add(new XAttribute("id", currEboTest.Test_suiteID));
                bool isgoodId = false;
                foreach (var currEboTestCase in currEboTest.EboTestCases)
                {

                    XElement testcase = new XElement("test_case");
                    testcase.Add(new XAttribute("id", currEboTestCase.Test_caseID));
                    testcase.Add(new XElement("date", currEboTestCase.Date));
                    testcase.Add(new XElement("passed", currEboTestCase.Passed));
                    testcase.Add(new XElement("comment", new XCData(currEboTestCase.Comment)));
                    if (currEboTestCase.Test_caseID == id)
                    {
                        isgoodId = true;
                        testsuit.Add(testcase);
                    }

                }
                if (isgoodId)
                {
                    sub.Add(testsuit);
                    isgoodId = false;
                }
            }

            xDoc.Add(sub);
            filesaver.XDoc = xDoc;
            filesaver.setFilename("result" + filename);
            filesaver.saveXdoc();
        }


    }
}
