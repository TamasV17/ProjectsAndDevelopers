using NUnit.Framework;
using ProjectsAndDevelopersMintaZH;

namespace TesterProj
{
    [TestFixture]
    public class TesterClass
    {
        XMLExporter exp = new XMLExporter();
            [Test]
            public void PropertyTpXElementTest()
            { 
               CustomerData data = new CustomerData();
               data.CustomerName = "Béla";
            //ACT
            var result = exp.PropertyToXElement(data.GetType().GetProperty("CustomerName"),data);

            //ASSERT
            Assert.That(result.Name == "MegrendeloNev");
            Assert.That(result.Value == "Béla");
            }        
    }
}