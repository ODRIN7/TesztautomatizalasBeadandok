using System;
using CalculatorService;
using NUnit.Framework;

namespace CalculatorServiceTests
{
    [TestFixture]
    public class TestCalculator
    {

        [Test]
        public void TestAddDelimitersInNumberString()
        {
            var calc = new Calculator();
            int result = calc.add("1 1:1;1.1?1\t1\n1");
            Assert.AreEqual(8, result);
        }
        [Test]
        public void TestAddMoreDelimiters()
        {
            var calc = new Calculator();

            try
            {
                int result = calc.add("1 1:1;1. 1 ? \n?1\t1\n1");
                Assert.Fail();
            }
            catch (NotNumberException nne)
            {

                Assert.That(nne.Message, Is.EqualTo("its not number"));
            }
        }
        [Test]
        public void TestAddNegativeNumber()
        {
            var calc = new Calculator();
            try
            {
                int result = calc.add("1 1:1;1 -1 .1?1\t1\n1");
                Assert.Fail();
            }
            catch(NegativesNumberException nne)
            {
              
                Assert.That(nne.Message, Is.EqualTo("negatives not allowed"));
            }
           

        }
        [Test]
        public void TestAddNotNumber()
        {
            var calc = new Calculator();

            try
            {
                int result = calc.add("1 1:a;sdfdsf -1.1?1\t1\n1");
                Assert.Fail();
            }
            catch (NotNumberException nne)
            {

                Assert.That(nne.Message, Is.EqualTo("its not number"));
            }

        }
        [Test]
        public void TestAddValidSumm()
        {
            var calc = new Calculator();

            int result = calc.add("1 1:1;1\n1\n1?1\t1");

            Assert.AreEqual(8, result);
        }
    }
}
