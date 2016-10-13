using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLREADER
{
    class EboTest
    {
        private string test_suiteID;

        public string Test_suiteID
        {
            get { return test_suiteID; }
            set { test_suiteID = value; }
        }
        private List<EboTestCase> eboTestCases;

        public List<EboTestCase> EboTestCases
        {
            get { return eboTestCases; }
            set { eboTestCases = value; }
        }
        public EboTest()
        {
            EboTestCases = new List<EboTestCase>();
        }
        public EboTest(string test_suiteID)
        {
            this.test_suiteID = test_suiteID;
            EboTestCases = new List<EboTestCase>();
        }
        public override string ToString()
        {
            string sum="";
            foreach (var item in eboTestCases)
            {
                sum += item.ToString() + "; ";
            }
            return "Test: " + Test_suiteID + "; ";
        }
    }
}
