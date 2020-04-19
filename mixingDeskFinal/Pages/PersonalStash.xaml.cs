using mixingDeskFinal.VapeClasses;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace mixingDeskFinal.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PersonalStash : Page
    {
        
        public ObservableCollection<Flavouring> Flavourings { get; set; } //might need to be an observable collection
        public PersonalStash()
        {
            this.InitializeComponent();
            //initialise flavourings list here(ie populate flavourings list)
            Flavourings= DatabaseClasses.DataAccess.GetFlavouringData();

        }
        /// <summary>
        /// Removes an item from the personal stash list. The removal is not persistant due to the database being populated every time the app starts. 
        /// See https://docs.microsoft.com/en-us/windows/uwp/get-started/settings-learning-track to maybe make this persistant. 
        /// Removing an item from the personal stash then navigating to a different page and then back to the personal stash page and attempting to remove another item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeFlavourFromStash(object sender, RoutedEventArgs e)
        {
            Flavouring flavourToRemove = (Flavouring)personalStashList.SelectedItem;
            


            //Remove flavouring from Flavourings list

            Flavourings.Remove(flavourToRemove);


            //Set inPersonalStash variable in flavourings table to 0
            DatabaseClasses.DataAccess.removeFromPersonalStash(flavourToRemove.Name);
            /*Removing an item from the personal stash then navigating to a different page and then back to the personal stash page and attempting to remove another item
             sometimes throws a null pointer exception */
        }

        private void addFlavourButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(nameOfFlavourInput.Text) || String.IsNullOrEmpty(companyInput.Text) || String.IsNullOrEmpty(versionNumberInput.Text))
            {
                userInfo.Text = "You must enter full details of a flavouring to save it.";
            }
            else
            {
                Flavouring userAddedFlavouring = new Flavouring(nameOfFlavourInput.Text, Convert.ToInt32(versionNumberInput.Text), true, companyInput.Text);
                Flavourings.Add(userAddedFlavouring);
                personalStashList.ItemsSource = Flavourings;
            }
            
        }
    }
}
