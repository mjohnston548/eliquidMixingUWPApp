using mixingDeskFinal.VapeClasses;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace mixingDeskFinal.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RecipesThisYear : Page
    {
        List<Recipe> Recipes = new List<Recipe>();
        public RecipesThisYear()
        {
            this.InitializeComponent();
            Recipes = DatabaseClasses.DataAccess.GetRecipeData("year");
        }

        private void thisWeekButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.RecipesThisWeek));
        }

        private void recipesThisYearList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)recipesThisYearList.SelectedItem;
            Frame.Navigate(typeof(Pages.SpecificRecipe), selectedRecipe);
        }

        private void ratingText_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //sorting by rating here
            Recipes = Recipes.OrderByDescending(r => r.Rating).ToList();
            recipesThisYearList.ItemsSource = Recipes;



        }

        private void dateText_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //sorting the content of the listview by date
            Recipes = Recipes.OrderByDescending(r => r.DateOfCreation).ToList();
            recipesThisYearList.ItemsSource = Recipes;

            //sort by descending on second click?
        }

        private void ratingText_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            
            ratingText.Foreground = Application.Current.Resources["SystemControlHighlightAccentBrush"] as SolidColorBrush;
        }

        private void ratingText_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ratingText.ClearValue(TextBlock.ForegroundProperty);
            
        }

        private void dateText_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            dateText.Foreground = Application.Current.Resources["SystemControlHighlightAccentBrush"] as SolidColorBrush;
        }

        private void dateText_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            dateText.ClearValue(TextBlock.ForegroundProperty);
        }
    }
}
