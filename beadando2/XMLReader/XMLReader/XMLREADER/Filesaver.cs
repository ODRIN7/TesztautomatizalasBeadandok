using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;

namespace XMLREADER
{
   public  class Filesaver 
    {
        XDocument xDoc;
        public XDocument XDoc
        {
            get { return this.xDoc; }
            set { this.xDoc = value; }
        }
        string filename;
        public virtual void setFilename(string filename)
        {
            this.filename=filename;
        }
        public Filesaver()
        {
            xDoc = new XDocument();
        }

        public virtual void saveXdoc(string filename)
        {
            xDoc.Save(filename);
        }
        public XDocument loadXdoc(string filename )
        {
            return XDocument.Load(filename);
        }


    }
}
