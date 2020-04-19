using Microsoft.VisualStudio.TestTools.UnitTesting;
using mixingDeskFinal.VapeClasses;
using System;

namespace UnitTestsVapeClasses
{
    [TestClass]
    public class RecipeTest
    {
        [TestMethod]
        public void TestRecipe()
        {
            //Testing the parameter-less constructor to see if a valid object is made
            Recipe tempRecipe = new Recipe();
            //Use a valid date
            tempRecipe.DateOfCreation = new DateTime(2020, 9, 4);

            DateTime expectedDateTime = new DateTime(2020, 9, 4);
            Assert.AreEqual(expectedDateTime, tempRecipe.DateOfCreation);

        }
    }
}
