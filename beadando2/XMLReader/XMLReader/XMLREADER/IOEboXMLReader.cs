using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLREADER
{
   public interface IOEboXMLReader
    {
        void CreateToXMLFailedTests(string loadedXmlName, string fileUri, string fileName);
        void CreateToXMLPassedTests(string loadedXmlName, string fileUri, string fileName);
        void CreateToXMLByIdTests(string loadedXmlName, string fileUri, string fileName, string workId);
    }
}
