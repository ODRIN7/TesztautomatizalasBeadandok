using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Console.WriteLine(">>>>>>>Input:");
            string mytestcase = "1\na";
            Console.WriteLine(mytestcase);
            Console.WriteLine();
            try
            {
                int result = calc.add(mytestcase);
                Console.WriteLine(">>>>>>>Result:");
                Console.WriteLine(result.ToString());
            }
            catch(NotNumberException notnumberexcep)
            {
                Console.WriteLine(">>>>>>>Excpetion");
                Console.WriteLine(notnumberexcep.Message);
            }
            catch(NegativesNumberException negativex)
            {
                Console.WriteLine(">>>>>>>Excpetion:");
                Console.WriteLine(negativex.Message);
            }
                       
            Console.ReadLine();

        }
    }
}
