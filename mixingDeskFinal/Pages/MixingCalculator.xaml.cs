﻿using mixingDeskFinal.VapeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace mixingDeskFinal.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MixingCalculator : Page
    {
        Boolean mixMadeSuccesfully = false;

        

        public MixingCalculator()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Putting default values in appropriate textboxes. In future we will want to get these from saved settings or preferences.
            nicotineBaseConcInput.Text = Convert.ToString(72);
            desiredNicotineConcInput.Text = Convert.ToString(18);
            volumeRequiredInput.Text = Convert.ToString(30);
            desiredPGPercentageInput.Text = Convert.ToString(50);
            desiredVGPercentageInput.Text = Convert.ToString(50);

            //need to check if Ingredients list was passed into this page when navigated to
            try
            {
                base.OnNavigatedTo(e);
                List<Ingredient> ingredientsList = (List<Ingredient>)e.Parameter;

                //checking for null reference here
                if (ingredientsList !=null)
                {
                    
                    
                    TextBox[] flavouringNamesInputs = { flavouring1NameInput, flavouring2NameInput, flavouring3NameInput, flavouring4NameInput, flavouring5NameInput, flavouring6NameInput, flavouring7NameInput };
                    TextBox[] percentageInputs = {flavouring1PercentageInput,flavouring2PercentageInput,flavouring3PercentageInput,flavouring4PercentageInput,flavouring5PercentageInput,flavouring6PercentageInput
                    ,flavouring7PercentageInput};
                    int i = 0;
                    foreach (Ingredient ingredient in ingredientsList)
                    {
                        flavouringNamesInputs[i].Text = ingredient.FlavouringName;
                        percentageInputs[i].Text = Convert.ToString(ingredient.UsagePercentage);
                        i += 1;
                    }
                }
                
            }
            catch (NullReferenceException)
            {
                throw;
                
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {

            //Most of the inards of this method should be delegated to other methods if we want to return a Mix object.
            Mix tempMix = new Mix();

            //make sure the mix has at least one flavouring percentage and the neccasary information to calculate it
            if (String.IsNullOrWhiteSpace(flavouring1PercentageInput.Text) || String.IsNullOrWhiteSpace(nicotineBaseConcInput.Text) || String.IsNullOrWhiteSpace(desiredNicotineConcInput.Text)
                || String.IsNullOrWhiteSpace(volumeRequiredInput.Text) || String.IsNullOrWhiteSpace(desiredPGPercentageInput.Text) || String.IsNullOrWhiteSpace(desiredVGPercentageInput.Text))
            {
                userErrorInfo.Text = "You are missing key information to calculate this mix.";
                
            }
            else
            {
                //make sure the mix makes mathematical sense
                try
                {
                    //make sure pg vg ratio adds up to 100 put this in if statement
                    Mix.PGVGValidator(desiredPGPercentageInput, desiredVGPercentageInput);

                    
                    TextBox[] flavouringNamesInput = { flavouring1NameInput, flavouring2NameInput, flavouring3NameInput, flavouring4NameInput, flavouring5NameInput, flavouring6NameInput, flavouring7NameInput };
                    TextBlock[] flavouringNamesOutput = { flavouring1NameOutput, flavouring2NameOutput, flavouring3NameOutput, flavouring4NameOutput, flavouring5NameOutput, flavouring6NameOutput, flavouring7NameOutput };
                    int i = 0;
                    foreach (TextBox flavouringName in flavouringNamesInput)
                    {
                        if (String.IsNullOrWhiteSpace(flavouringName.Text))
                        {
                            i += 1;
                            continue;
                        }
                        else
                        {
                            flavouringNamesOutput[i].Text = Convert.ToString(flavouringName.Text);
                            i += 1;
                        }
                    }

                    
                    tempMix.NicotineWeightCalculator(nicotineBaseConcInput);
                    
                    TextBox[] flavouringPercentagesInput = {flavouring1PercentageInput,flavouring2PercentageInput,flavouring3PercentageInput,flavouring4PercentageInput,flavouring5PercentageInput
                    ,flavouring6PercentageInput,flavouring7PercentageInput};
                    tempMix.CalculateMixInVolume(desiredNicotineConcInput, volumeRequiredInput, nicotineBaseConcInput, desiredVGPercentageInput, desiredPGPercentageInput, flavouringPercentagesInput);

                    TextBlock[] flavouringVolumeOutput = {flavouring1VolumeOutput,flavouring2VolumeOutput,flavouring3VolumeOutput,flavouring4VolumeOutput,flavouring5VolumeOutput,flavouring6VolumeOutput
                    ,flavouring7VolumeOutput};
                    tempMix.DisplayMixResultsVolume(nicotineBaseVolumeOutput, pgBaseVolumeOutput, vgVolumeOutput, flavouringVolumeOutput);

                    TextBlock[] flavouringWeightOutput = {flavouring1GramsOutput,flavouring2GramsOutput,flavouring3GramsOutput,flavouring4GramsOutput,flavouring5GramsOutput,flavouring6GramsOutput
                    ,flavouring7GramsOutput};
                    tempMix.DisplayMixResultsWeight(nicotineBaseGramsOutput, pgGramsOutput, vgGramsOutput, flavouringWeightOutput);

                    TextBlock[] flavouringPercentageOutput = {flavouring1PercentageOutput,flavouring2PercentageOutput,flavouring3PercentageOutput,flavouring4PercentageOutput,flavouring5PercentageOutput
                    ,flavouring6PercentageOutput,flavouring7PercentageOutput};

                    tempMix.DisplayMixResultsPercentage(nicotineBasePercentageOutput, vgPercentageOutput, pgPercentageOutput, flavouringPercentagesInput, flavouringPercentageOutput);


                    //Displaying totals.          Could do this with a generic?
                    List<TextBlock> percentageOutputList = new List<TextBlock>();
                    percentageOutputList.AddRange(flavouringPercentageOutput);
                    percentageOutputList.Add(nicotineBasePercentageOutput);
                    percentageOutputList.Add(pgPercentageOutput);
                    percentageOutputList.Add(vgPercentageOutput);

                    List<TextBlock> volumeOutputList = new List<TextBlock>();
                    volumeOutputList.AddRange(flavouringVolumeOutput);
                    volumeOutputList.Add(nicotineBaseVolumeOutput);
                    volumeOutputList.Add(vgVolumeOutput);
                    volumeOutputList.Add(pgBaseVolumeOutput);

                    List<TextBlock> weightOutputList = new List<TextBlock>();
                    weightOutputList.AddRange(flavouringWeightOutput);
                    weightOutputList.Add(nicotineBaseGramsOutput);
                    weightOutputList.Add(vgGramsOutput);
                    weightOutputList.Add(pgGramsOutput);

                    tempMix.DisplayTotals(volumeOutputList, weightOutputList, percentageOutputList, flavouringPercentagesInput, totalVolumeOutput, totalGramsOutput, totalPercentageOutput, totalFlavourPercentageOutput);

                    
                    mixMadeSuccesfully = true;

                    
                }
                catch (Exception ex)
                {
                    userErrorInfo.Text = Convert.ToString(ex.Message);
                }
                                   
            }
            

        }

        private List<Ingredient> PopulateMixIngredientsList(Mix mixObj, TextBox[] flavouringPercentagesInput,TextBox[] flavouringNamesInput)
        {
            List<Ingredient> tempIngredients = new List<Ingredient>();
            int i = 0;
            foreach (TextBox flavouringName in flavouringNamesInput)
            {
                if (String.IsNullOrWhiteSpace(flavouringName.Text))
                {
                    i += 1;
                    continue;
                }
                else
                {
                    tempIngredients.Add(new Ingredient(flavouringName.Text, Convert.ToDouble(flavouringPercentagesInput[i].Text)));
                    i += 1;
                }

            }
            return tempIngredients;
        }

        private Mix MakeMixObjectFromInput(TextBox[] flavouringNames, TextBox[] flavouringPercentages )
        {
            Mix tempMix = new Mix();
            tempMix.Ingredients = PopulateMixIngredientsList(tempMix, flavouringPercentages, flavouringNames);
            return tempMix;
        }

        private async void SaveRecipeClickAsync(object sender, RoutedEventArgs e)
        {
            if (mixMadeSuccesfully)
            {
                //Making a list of ingredients since we havent made a mix object
                TextBox[] flavouringNamesInput = { flavouring1NameInput, flavouring2NameInput, 
                    flavouring3NameInput, flavouring4NameInput, flavouring5NameInput, flavouring6NameInput, 
                    flavouring7NameInput };
                TextBox[] flavouringPercentagesInput = {flavouring1PercentageInput,flavouring2PercentageInput,
                    flavouring3PercentageInput,flavouring4PercentageInput, flavouring5PercentageInput,
                    flavouring6PercentageInput,flavouring7PercentageInput};
                
                Mix tempMix = MakeMixObjectFromInput(flavouringNamesInput, flavouringPercentagesInput);
                
                await Mix.SaveMix(userErrorInfo, desiredNicotineConcInput, nicotineBaseConcInput, volumeRequiredInput,
                    tempMix.Ingredients, desiredPGPercentageInput, desiredVGPercentageInput);
            }
            else
            {
                userErrorInfo.Text = "To save a mix you must first calculate this successfully.";
            }
        }

        private async void LoadRecipeClick(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFile file= await Mix.LoadMix(userErrorInfo);
            //Read the file and throw each line into an array.
            IList<String> mixInfoList= await Windows.Storage.FileIO.ReadLinesAsync(file);

            //go through the lines and input the data into the correct textboxes
            nicotineBaseConcInput.Text = mixInfoList[0];
            desiredNicotineConcInput.Text = mixInfoList[1];
            volumeRequiredInput.Text = mixInfoList[2];
            desiredPGPercentageInput.Text = mixInfoList[3];
            desiredVGPercentageInput.Text = mixInfoList[4];

            //find out how many lines are in the list
            int numberOfFlavouringUsageEntries= mixInfoList.Count();

            TextBox[] flavouringNamesInput = { flavouring1NameInput, flavouring2NameInput, flavouring3NameInput, 
                flavouring4NameInput, flavouring5NameInput, flavouring6NameInput, flavouring7NameInput };
            TextBox[] flavouringPercentagesInput = {flavouring1PercentageInput,flavouring2PercentageInput,
                flavouring3PercentageInput,flavouring4PercentageInput,flavouring5PercentageInput
                    ,flavouring6PercentageInput,flavouring7PercentageInput};
            
            //Filling in the name text boxes
            int j = 0;
            for (int i = 5; i <  mixInfoList.Count(); i += 2)
            {
                flavouringNamesInput[j].Text = mixInfoList[i];
                j += 1;
            }

            //Filling in the percentage text boxes
            int k = 0;
            for (int i = 6; i < mixInfoList.Count() ; i+=2)
            {
                flavouringPercentagesInput[k].Text = mixInfoList[i];
                k += 1;
            }

        }
    }
}