using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLREADER
{
    class Program
    {

        static void Main(string[] args)
        {
            IOEboXMLReader eboxmlread = new EboXMLReader(new Filesaver());
            eboxmlread.CreateToXMLFailedTests("00subitresults.xml");
            Console.ReadLine();

        }
       
        // mock-->másik fájlt húzzon be 
        //  >>>>>>>>>>>>>>> csak true
        //  >>>>>>>>>>>>>>> csak false
        //  >>>>>>>>>>>>>>> Signalra működik-e 
        //  >>>>>>>>>>>>>>> Exception helyes
        // 
    }
}
