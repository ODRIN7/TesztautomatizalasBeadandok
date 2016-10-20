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
            Console.WriteLine(">>>>>>go, press enter");
            Console.ReadLine();
            string fileUri = AppDomain.CurrentDomain.BaseDirectory;
            string loadedxmlName = "00subitresults.xml";
            string resultxmlName = "result00subitresults.xml";
            IOEboXMLReader eboxmlread = new EboXMLReader(new Filesaver());
            eboxmlread.CreateToXMLFailedTests(loadedxmlName, fileUri, resultxmlName);
            Console.WriteLine(">>>>>>File generated, See in the folder");
            Console.ReadLine();

        }
    }
}
