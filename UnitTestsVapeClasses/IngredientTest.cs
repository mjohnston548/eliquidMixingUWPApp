using Microsoft.VisualStudio.TestTools.UnitTesting;
using mixingDeskFinal.VapeClasses;


namespace UnitTestsVapeClasses
{
    [TestClass]
    public class IngredientTest
    {
        [TestMethod]
        public void TestIngredientOverload()
        {
            //Testing the overloaded Ingredient constructor. This is the only 
            //Ingredient constructor
            Ingredient tempIngredient = new Ingredient("Strawberry", 4.5);

            double expectedNumber = 4.5;
            Assert.AreEqual(expectedNumber, tempIngredient.UsagePercentage);
        }
    }
}
