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
    public sealed partial class RecipesThisMonth : Page
    {
        public List<Recipe> Recipes { get; set; }
        public RecipesThisMonth()
        {
            this.InitializeComponent();
            Recipes = DatabaseClasses.DataAccess.GetRecipeData("month");
        }

        private void thisYearButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.RecipesThisYear));
        }

        private void recipesThisMonthList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)recipesThisMonthList.SelectedItem;
            Frame.Navigate(typeof(Pages.SpecificRecipe), selectedRecipe);
        }

        private void dateText_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //sorting the content of the listview by date
            Recipes = Recipes.OrderByDescending(r => r.DateOfCreation).ToList();
            recipesThisMonthList.ItemsSource = Recipes;

            //sort by descending on second click?
        }

        private void ratingText_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //sorting by rating here
            Recipes = Recipes.OrderByDescending(r => r.Rating).ToList();
            recipesThisMonthList.ItemsSource = Recipes;
        }

        private void dateText_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            dateText.Foreground = Application.Current.Resources["SystemControlHighlightAccentBrush"] as SolidColorBrush;
        }

        private void dateText_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            dateText.ClearValue(TextBlock.ForegroundProperty);
        }

        private void ratingText_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ratingText.Foreground = Application.Current.Resources["SystemControlHighlightAccentBrush"] as SolidColorBrush;
        }

        private void ratingText_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ratingText.ClearValue(TextBlock.ForegroundProperty);
        }
    }
}
