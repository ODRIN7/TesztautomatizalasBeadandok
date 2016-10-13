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
        private IFilesaver filesaver;
        private static List<EboTest> eboTests;
        public string filename;
        public EboXMLReader(IFilesaver filesaver)
        {
            eboTests = new List<EboTest>();
            this.filesaver = filesaver;
        }      
       
        public  void CreateToXML(string filename)
        {
            LoadEboTestcase(filesaver.loadXdoc(filename));
            this.filename = filename;
            CreateXMLPARSER();
          
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
        private void CreateXMLPARSER()
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
            }
            }

            xDoc.Add(sub);
            filesaver.saveXdoc(xDoc, "_result"+filename);
        }
    }
}
