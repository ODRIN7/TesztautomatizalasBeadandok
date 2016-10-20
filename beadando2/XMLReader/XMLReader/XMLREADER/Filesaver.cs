using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;

namespace XMLREADER
{
   public  class Filesaver :IFilesaver
    {
        public Filesaver()
        {
        }

           
        public void saveXdoc(XDocument xDoc, string fileUri, string fileName)
        {
            xDoc.Save(Path.Combine(fileUri, fileName));
        }

        public XDocument loadXdoc(string fileUri, string fileName)
        {
            return XDocument.Load(fileName);
        }
    }
}
