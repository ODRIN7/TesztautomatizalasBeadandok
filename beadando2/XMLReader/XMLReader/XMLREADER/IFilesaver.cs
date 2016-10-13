using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLREADER
{
   public interface IFilesaver
    {
         void saveXdoc(XDocument xDoc, string fileName);
         XDocument loadXdoc(string fileName);

    }
}
