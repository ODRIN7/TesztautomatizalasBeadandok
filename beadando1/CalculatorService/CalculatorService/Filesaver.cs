using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
  public  class Filesaver
    {
        string path = @"C:\Users\WriteLines.txt";
        string text;
        List<string> texts = new List<string>();
        public virtual void  writetoTxt()
        {
           
            texts.Add("asdas");
        }
        public string loadTxt(string name)
        {
            return name;
        }
    }
}
