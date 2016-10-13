using Moq;
using NUnit.Framework;
using System.Xml.Linq;
using XMLREADER;

namespace XMLREADERTESTS
{
    [TestFixture]
    class EboXMLPareserTests
    {

        [Test]
        public void TestEboFileSaved()
        {
            string loadedxmlName= "justfortest.xml";
            Mock<Filesaver> fileSaverMocker = new Mock<Filesaver>();
            fileSaverMocker
              .Setup(fsm => fsm.saveXdoc(new XDocument(loadedxmlName), "testResult"));

            EboXMLReader eboXMLReader = new EboXMLReader(fileSaverMocker.Object);
            eboXMLReader.CreateToXML(loadedxmlName);
           
                XDocument xdoc = new XDocument("testResult.xml");
                Assert.True(xdoc!=null);
        }

        [Test]
        public void TestAllEboTestPassesTrue()
        {
         


        }
        [Test]
        public void TestEboTetsWorkByID()
        {
        }
        [Test]
        public void TestAllEboTestPassesFalse()
        {
        }
        [Test]
        public void TestAllEboTestExceptionValid()
        {
        }
        [Test]
        public void TestAllEboTestSignalValid()
        {
        }
       


    }
}
