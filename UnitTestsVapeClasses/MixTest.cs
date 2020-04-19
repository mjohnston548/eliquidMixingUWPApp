using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using mixingDeskFinal.VapeClasses;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace UnitTestsVapeClasses
{
    [TestClass]
    public class MixTest
    {
        [TestMethod]
        public void TestMix()
        {
            //Testing the parameter-less constructor
            Mix tempMix = new Mix();
            //Using a valid number
            tempMix.NicotineConcentration = 12.4;

            double expectedNumber = 12.4;
            Assert.AreEqual(expectedNumber, tempMix.NicotineConcentration);
        }

        [UITestMethod]
        public void TestNicotineWeightCalculator()
        {
            //Testing the nicotine weight calculator with a known g/ml value
            // of 48mg nicotine base(in PG) https://www.liquidbarn.com/pages/calculating-the-specific-gravity-of-your-nicotine-solution
            //This should weigh 1.035g/ml
            Mix tempMix = new Mix();
            TextBox tempBox = new TextBox();
            tempBox.Text = "48";
            //sets the NicotineGramsPerMl property
            tempMix.NicotineWeightCalculator(tempBox); 

            double expectedValue = 1.035;
            expectedValue.CompareTo(tempMix.NicotineGramsPerMl);
            //Doesn't pass because we are comparing doubles that are very
            //close but not the same
            Assert.AreEqual(expectedValue, tempMix.NicotineGramsPerMl);

        }

        [UITestMethod]
        public void TestPGVGValidator()
        {
            //PGVGValidator makes sure the pg and vg text boxes add up to 100
            TextBox vgBox = new TextBox();
            vgBox.Text = "43";
            TextBox pgBox = new TextBox();
            pgBox.Text = "57";
            
            Assert.AreEqual(true, Mix.PGVGValidator(pgBox,vgBox));
        }

        [UITestMethod]
        public void TestCalculateMixInVolume()
        {
            //Testing if one of the volume properties are set after running
            //the method
            TextBox nicBaseConc = new TextBox();
            nicBaseConc.Text = "72";
            TextBox desiredNicConc = new TextBox();
            desiredNicConc.Text = "24";
            TextBox volumeRequired = new TextBox();
            volumeRequired.Text = "30";
            TextBox vgBox = new TextBox();
            vgBox.Text = "45";
            TextBox pgBox= new TextBox();
            pgBox.Text = "55";

            TextBox[] flavouringPercentages= { new TextBox()};
            flavouringPercentages[0].Text = "4.3";

            Mix tempMix = new Mix();
            //sets the volume properties
            tempMix.CalculateMixInVolume(desiredNicConc, volumeRequired, nicBaseConc, vgBox, pgBox, flavouringPercentages);

            Assert.IsNotNull(tempMix.FlavouringsVolumeInMix);

        }
        //The next four methods DisplayMixResultsVolume, DisplayMixResultsWeight,
        //DisplayMixResultsPercentage and DisplayTotals simply take Textblocks as input
        //parameters and populate them on screen. Since these parameters are local to 
        //these methods I cannot verify if they are null or not after these methods are called.
        

        [UITestMethod]
        public void TestSaveMix()
        {
            //Checking if the Task return of the SaveMix method is not null
            TextBox nicBaseConc = new TextBox();
            nicBaseConc.Text = "72";
            TextBox desiredNicConc = new TextBox();
            desiredNicConc.Text = "24";
            TextBox volumeRequired = new TextBox();
            volumeRequired.Text = "30";
            TextBox vgBox = new TextBox();
            vgBox.Text = "45";
            TextBox pgBox = new TextBox();
            pgBox.Text = "55";
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(new Ingredient("banana", 4.0));

            TextBlock userInfo = new TextBlock();
            Assert.IsNotNull(Mix.SaveMix(userInfo, desiredNicConc, nicBaseConc, volumeRequired, ingredients, pgBox, vgBox));
        }

        [UITestMethod]
        public void TestLoadMix()
        {
            //Checking if the StorageFile file that is returned is not null
            TextBlock userInfoText = new TextBlock();
            Assert.IsNotNull(Mix.LoadMix(userInfoText));
        }
    }
}
