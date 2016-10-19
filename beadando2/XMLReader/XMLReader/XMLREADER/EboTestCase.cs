using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLREADER
{
    public class EboTestCase
    {
        private string test_caseID;

        public string Test_caseID
        {
            get { return test_caseID; }
            set { test_caseID = value; }
        }
        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        private string passed;

        public string Passed
        {
            get { return passed; }
            set { passed = value; }
        }
        private string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }


        public EboTestCase()
        {
            
        }
        public EboTestCase(string test_caseID, string date, string passed, string comment)
        {
            this.test_caseID = test_caseID;
            this.date = date;
            this.passed = passed;
            this.comment = comment;
        }

        public override string ToString()
        {
            return    test_caseID +"!";
        }

    }
}
