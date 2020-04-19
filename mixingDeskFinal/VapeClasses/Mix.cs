using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace mixingDeskFinal.VapeClasses
{
    /// <summary>
    /// Represents a Mix. That is, a custom user created Recipe. Most calculates and 
    /// verifies that the user's recipe makes sense.
    /// </summary>
    public class Mix: Recipe
    {
        public double NicotineConcentration { get; set; }

        public double TotalVolumeOfMix { get; set; }

        public double VolumeOfPGInMix { get; set; }

        public double VolumeOfVGInMix { get; set; }

        public double VolumeOfNicotineBaseInMix { get; set; }

        public List<Double> FlavouringsVolumeInMix { get; set; }

        private double vgGramsPerMl = 1.26;

        private double pgGramsPerMl = 1.038;

        private double flavouringGramsPerMl = 1;

        public double NicotineGramsPerMl { get; set; }

        public Mix()
        {

        }


        public void NicotineWeightCalculator(TextBox nicotineConcInput)
        {
            
            double weightOfPureNicotine = 1.009; // g/ml

            double weightOfPurePG = 1.036; // g/ml

            //Percentage of base that is pure nicotine
            double pureNicotinePercentage = Convert.ToDouble(nicotineConcInput.Text) / 10;

            //Percentage of base that is pure PG
            double purePGPercentage = 100 - pureNicotinePercentage;

            //Weight of the nicotine in base
            double weightOfNicInBase=pureNicotinePercentage* weightOfPureNicotine;

            double weightOfPGInBase = purePGPercentage * weightOfPurePG;

            NicotineGramsPerMl = (weightOfNicInBase + weightOfPGInBase) / 100;
        }
        
        /// <summary>
        /// Checks if the numbers in the desiredPGPercentageInput and desiredVGPercentageInput textboxes equal 100 after adding them.
        /// </summary>
        /// <param name="pgTextBox"></param>
        /// <param name="vgTextBox"></param>
        /// <returns></returns>
        public static Boolean PGVGValidator(TextBox pgTextBox, TextBox vgTextBox)
        {
            //Tolerance value
            double difference = Convert.ToDouble(pgTextBox.Text) * 0.00001;
            //Should equal 100
            double totalPGVG = Convert.ToDouble(pgTextBox.Text) + Convert.ToDouble(vgTextBox.Text);
            if (Math.Abs(totalPGVG - 100) <= difference )
            {
                //PG VG ratio makes sense
                return true;
            }
            else
            {
                throw new Exception("The PG VG ratio must add up to 100.");
            }

        }
        /// <summary>
        /// Calculates the Mix in volume given the user inputs in TextBoxes and sets the volume properties.
        /// </summary>
        /// <param name="desiredNicotineConcInput"></param>
        /// <param name="volumeRequiredInput"></param>
        /// <param name="nicotineBaseConcInput"></param>
        /// <param name="desiredVGPercentageInput"></param>
        /// <param name="desiredPGPercentageInput"></param>
        /// <param name="flavouringPercentages"></param>
        public void CalculateMixInVolume(TextBox desiredNicotineConcInput, TextBox volumeRequiredInput, TextBox nicotineBaseConcInput, 
            TextBox desiredVGPercentageInput, TextBox desiredPGPercentageInput, TextBox[] flavouringPercentages)
        {
            TotalVolumeOfMix = Convert.ToDouble(volumeRequiredInput.Text);
            VolumeOfNicotineBaseInMix = (Convert.ToDouble(desiredNicotineConcInput.Text) * TotalVolumeOfMix) / Convert.ToDouble(nicotineBaseConcInput.Text);

            VolumeOfVGInMix = (Convert.ToDouble(desiredVGPercentageInput.Text) / 100) * TotalVolumeOfMix;

            //Calculating volumes for each flavouring in the mix and counting the total flavouring volume
            List<Double> flavouringVolumes = new List<double>();
            double flavouringVolumeCount = 0;
            foreach (TextBox flavouringPercentageInput in flavouringPercentages)
            {
                if (String.IsNullOrWhiteSpace(flavouringPercentageInput.Text))
                {
                    continue;
                }
                else
                {
                    double volumeOfFlavouringInMix = (Convert.ToDouble(flavouringPercentageInput.Text) / 100) * TotalVolumeOfMix;
                    flavouringVolumeCount += volumeOfFlavouringInMix;
                    flavouringVolumes.Add(volumeOfFlavouringInMix);
                }
                

                //could add the flavouring name and usage percentage to the Ingredients list here if we can get the addFlavouring method in Recipe
            }
            FlavouringsVolumeInMix = flavouringVolumes;

            VolumeOfPGInMix = ((Convert.ToDouble(desiredPGPercentageInput.Text) / 100) * TotalVolumeOfMix) - VolumeOfNicotineBaseInMix- flavouringVolumeCount;




        }

        public void DisplayMixResultsVolume(TextBlock nicotineOutput, TextBlock pgOutput, TextBlock vgOutput, TextBlock[] flavouringVolumeOutput)
        {
            //Volume output
            nicotineOutput.Text = Convert.ToString(VolumeOfNicotineBaseInMix);
            pgOutput.Text = Convert.ToString(VolumeOfPGInMix);
            vgOutput.Text = Convert.ToString(VolumeOfVGInMix);

            for (int i = 0; i < FlavouringsVolumeInMix.Count; i++)
            {
                flavouringVolumeOutput[i].Text = Convert.ToString(FlavouringsVolumeInMix[i]);
            }
            
        }

        public void DisplayMixResultsWeight(TextBlock nicotineOutput, TextBlock pgOutput, TextBlock vgOutput, TextBlock[] flavouringWeightOutput)
        {
            nicotineOutput.Text = Convert.ToString(VolumeOfNicotineBaseInMix * NicotineGramsPerMl);
            pgOutput.Text = Convert.ToString(VolumeOfPGInMix*pgGramsPerMl);
            vgOutput.Text = Convert.ToString(VolumeOfVGInMix*vgGramsPerMl);

            int i = 0;
            foreach (double flavouringVolume in FlavouringsVolumeInMix)
            {
                flavouringWeightOutput[i].Text = Convert.ToString(FlavouringsVolumeInMix[i] * flavouringGramsPerMl);
                i += 1;
            }
        }

        public void DisplayMixResultsPercentage(TextBlock nicotinePercentageOutput, TextBlock vgPercentageOutput,TextBlock pgPercentageOutput, TextBox[] flavouringPercentagesInput, 
            TextBlock[] flavouringPercentagesOutput)
        {
            nicotinePercentageOutput.Text= Convert.ToString((VolumeOfNicotineBaseInMix /  TotalVolumeOfMix)*100);
            vgPercentageOutput.Text = Convert.ToString((VolumeOfVGInMix / TotalVolumeOfMix)*100);
            pgPercentageOutput.Text = Convert.ToString((VolumeOfPGInMix / TotalVolumeOfMix)*100);

            int i = 0;
            foreach (TextBox percentage in flavouringPercentagesInput)
            {
                flavouringPercentagesOutput[i].Text = Convert.ToString(flavouringPercentagesInput[i].Text);
                i += 1;
            }
        }

        public  void DisplayTotals(List<TextBlock> VolumeOutput, List<TextBlock> WeightOutput, List<TextBlock> PercentageOutput, TextBox[] flavouringPercentages,TextBlock totalVolumeOutput
            ,TextBlock totalGramsOutput,TextBlock totalPercentageOutput,TextBlock totalFlavourPercentageOutput)
        {
            int i = 0;
            double volumeCount = 0;
            foreach (TextBlock volumeEntry in VolumeOutput)
            {
                volumeCount += Convert.ToDouble(volumeEntry.Text);
                i += 1;
            }
            totalVolumeOutput.Text = Convert.ToString(volumeCount);


            i = 0;
            double weightCount = 0;
            foreach (TextBlock weightEntry in WeightOutput)
            {
                weightCount += Convert.ToDouble(weightEntry.Text);
                i += 1;
            }
            totalGramsOutput.Text = Convert.ToString(weightCount);

            i = 0;
            double percentageCount = 0;
            foreach (TextBlock percentageEntry in PercentageOutput)
            {
                if (String.IsNullOrEmpty(percentageEntry.Text))
                {
                    continue;
                }
                else
                {
                    percentageCount += Convert.ToDouble(percentageEntry.Text);
                    i += 1;
                }
                
            }
            totalPercentageOutput.Text = Convert.ToString(percentageCount);

            i = 0;
            double flavouringPercentageCount = 0;
            foreach (TextBox flavourPercentage in flavouringPercentages)
            {
                if (String.IsNullOrEmpty(flavourPercentage.Text))
                {
                    continue;
                }
                else
                {
                    flavouringPercentageCount += Convert.ToDouble(flavourPercentage.Text);
                    i += 1;
                }
                
            }
            totalFlavourPercentageOutput.Text = Convert.ToString(flavouringPercentageCount);
        }

        public static async Task SaveMix(TextBlock userInfoText,TextBox desiredNicotineConc,TextBox nicotineBaseConc,TextBox desiredVolume,List<Ingredient> flavouringsAndUsagePerc, 
            TextBox desiredPGRatio,TextBox desiredVGRatio)
        {
            //get Mix data together
            List<String> mixData = new List<string>();
            mixData.Add(nicotineBaseConc.Text);
            mixData.Add(desiredNicotineConc.Text);
            mixData.Add(desiredVolume.Text);
            mixData.Add(desiredPGRatio.Text);
            mixData.Add(desiredVGRatio.Text);
            foreach (Ingredient flavouringPercentageDuo in flavouringsAndUsagePerc)
            {
                mixData.Add(flavouringPercentageDuo.FlavouringName);
                mixData.Add(Convert.ToString(flavouringPercentageDuo.UsagePercentage));
            }


            

            //create file save picker and customize it
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Dropdown of file types the user can save the file as
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = "NewMix";

            //show the fileSavePicker and save the picked file
            Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(file);
                // write to file
                await Windows.Storage.FileIO.WriteTextAsync(file, file.Name);

                await Windows.Storage.FileIO.WriteLinesAsync(file, mixData);
                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                    await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    userInfoText.Text = "File " + file.Name + " was saved.";
                }
                else
                {
                    userInfoText.Text = "File " + file.Name + " couldn't be saved.";
                }
            }
            else
            {
                userInfoText.Text = "Operation cancelled.";
            }
        }

        public static async Task<Windows.Storage.StorageFile> LoadMix(TextBlock userInfoText)
        {
            //Make filePicker object and customize it
            var loadPicker = new Windows.Storage.Pickers.FileOpenPicker();
            loadPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            loadPicker.FileTypeFilter.Add(".txt");

            //get a StorageFile object to manipulate
            Windows.Storage.StorageFile file = await loadPicker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                userInfoText.Text = "Picked file: " + file.Name;
            }
            else
            {
                userInfoText.Text = "Operation cancelled.";
            }
            return file;
        }
    }
}
