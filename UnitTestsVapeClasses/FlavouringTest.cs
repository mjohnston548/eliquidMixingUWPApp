
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mixingDeskFinal.VapeClasses;


namespace UnitTestsVapeClasses
{
    [TestClass]
    public class FlavouringTest
    {
        [TestMethod]
        public void TestFlavouring()
        {
            //Testing the parameter-less constuctor
            Flavouring tempFlavouring = new Flavouring();
            tempFlavouring.Name = "Apple";

            string expectedString = "Apple";
            Assert.AreEqual(expectedString, tempFlavouring.Name);
        }

        [TestMethod]
        public void TestFlavouringOverload()
        {
            //Testing the overloaded Flavouring constructor
            Flavouring tempFlavouring = new Flavouring("Apple", 1, true, "Capella");

            Boolean expectedBool = true;
            Assert.AreEqual(expectedBool, tempFlavouring.InPersonalStash);
        }
    }
}
