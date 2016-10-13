using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;

namespace XMLREADER
{
   public  class Filesaver : IFilesaver
    {
        public Filesaver()
        {
            
        }
        public void saveXdoc(XDocument xDoc,string fileName )
        {
            //    FolderBrowserDialog folderbrowser = new FolderBrowserDialog();
            //      folderbrowser.ShowDialog();
            //   xDoc.Save(folderbrowser.SelectedPath+"/"+ folderbrowser.Site);           
            xDoc.Save(fileName+".xml");
        }
        public XDocument loadXdoc(string filename )
        {
            return XDocument.Load(filename);
        }

    }
}
