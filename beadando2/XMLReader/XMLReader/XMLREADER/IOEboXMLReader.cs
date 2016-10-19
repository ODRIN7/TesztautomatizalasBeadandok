using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLREADER
{
   public interface IOEboXMLReader
    {
          void CreateToXMLFailedTests(string filename);
        void CreateToXMLPassedTests(string filename);
        void CreateToXMLByIdTests(string filename,string workId);
    }
}
