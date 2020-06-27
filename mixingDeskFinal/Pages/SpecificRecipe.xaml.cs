using mixingDeskFinal.VapeClasses;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace mixingDeskFinal.Pages
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SpecificRecipe : Page
    {
        public List<Ingredient> Ingredients { get; set; }
        public SpecificRecipe()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Recieving the recipe object and populating the Ingredients list
            base.OnNavigatedTo(e);
            Recipe specificRecipe=(Recipe)e.Parameter;
            Ingredients = specificRecipe.Ingredients;

            //Setting the name , creator name and date of recipe textblocks
            creatorNameText.Text = specificRecipe.CreatorName;
            dateOfCreationText.Text = Convert.ToString(specificRecipe.DateOfCreation);
            recipeNameText.Text = specificRecipe.Name;
            if (specificRecipe.Notes!=null)
            {
                notesContentText.Text = specificRecipe.Notes;
            }
            
            
        }

        private void mixRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            //Send the Ingredients list to the mixing Calculator page
            Frame.Navigate(typeof(Pages.MixingCalculator), Ingredients);
        }
    }
}
