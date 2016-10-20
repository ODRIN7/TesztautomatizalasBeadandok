using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMLREADER;

namespace XMLREADERTESTS
{
    class MockFileSaver : IFilesaver
    {
        private string mockFileuri;
        private string mockResultFileName;
        private string mockLoadFileName;

        public MockFileSaver(string mockFileuri, string mockResultFileName,string mockLoadFileName)
        {
            this.mockFileuri = mockFileuri;
            this.mockResultFileName = mockResultFileName;
            this.mockLoadFileName = mockLoadFileName;
        }

        public XDocument loadXdoc(string fileUri, string fileName)
        {
            return XDocument.Load((Path.Combine(mockFileuri, mockLoadFileName)));
        }

        public void saveXdoc(XDocument xDoc, string fileUri, string fileName)
        {
            xDoc.Save(Path.Combine(mockFileuri, mockResultFileName));
        }
    }
}
