using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
  public  class Calculator
    {
        Filesaver filesaver;
        public Calculator(Filesaver filesaver)
        {
            this.filesaver = filesaver;
        }
         public Calculator()
        {

        }

        private static char[] delimiterChars = { ';', ' ', ',', '.', ':', '\t', '\n','?','/' };
        public int add(String numbers)
        {
            List<int> parseredNumbers = new List<int>();

            parseredNumbers = StringNumbersParser(numbers);

            return parseredNumbers.Sum();
        }

        private List<int> StringNumbersParser(String numbers)
        {
            string[] words = numbers.Split(delimiterChars);
            
            List<int> resultOFNumber = new List<int>();
            for (int i = 0; i < words.Length; i++)
            {
                int result=0;
                if (words[i] != "")
                {
                    result = NumberParsing(words[i]);
                }                
                validateNegative(result);                
                resultOFNumber.Add(result);
                
            }
            return resultOFNumber;
        }

        private void validateNegative (int number) 
        {
            if (number < 0)
            {
                throw new NegativesNumberException("negatives not allowed");
            }
        }
         
        private int NumberParsing(string word)
        {
            int result=-1;
          
                if (!int.TryParse(word, out result))
                {
                    throw new NotNumberException("its not number");
                }   
          
               
            return result;
         
        }


    }
}
