using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG2A_GUI_POE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //runs on strart up and show (both at the start of the program and when the window is show from another window)
        //-------------------------------------------------------------------------------------------------------------------------------------
        public MainWindow()
        {
            //Creates some stock recipes to fill the system
            //------------------------------------------------------------------------------------------------------------
            /*IngredientDetails stockIngredientdetailsone = new IngredientDetails();
            IngredientDetails stockIngredientdetailstwo = new IngredientDetails();
            IngredientDetails stockIngredientdetailsthree = new IngredientDetails();
            IngredientDetails astockIngredientdetailsone = new IngredientDetails();
            IngredientDetails astockIngredientdetailstwo = new IngredientDetails();
            Dictionary<string, IngredientDetails> stockIngredients = new Dictionary<string, IngredientDetails>();
            Dictionary<string, IngredientDetails> astockIngredients = new Dictionary<string, IngredientDetails>();
            List<string> stockSteps = new List<string>();
            List<string> astockSteps = new List<string>();
            Recipe stockRecipe = new Recipe();
            Recipe astockRecipe = new Recipe();
            //Stock Recipe One
            stockIngredientdetailsone.CreateIngredient("apple", 100, "g", 52, "fruit and veg");
            stockIngredients.Add(stockIngredientdetailsone.Name, stockIngredientdetailsone);
            stockIngredientdetailstwo.CreateIngredient("banana", 150, "g", 134, "fruit and veg");
            stockIngredients.Add(stockIngredientdetailstwo.Name, stockIngredientdetailstwo);
            stockIngredientdetailsthree.CreateIngredient("pineapple", 100, "g", 48, "fruit and veg");
            stockIngredients.Add(stockIngredientdetailsthree.Name, stockIngredientdetailsthree);
            stockSteps.Add("Add the apple to a bowl");
            stockSteps.Add("Add the banana to the bowl");
            stockSteps.Add("Add the pineapple to the bowl");
            stockSteps.Add("Mix all the ingredients and serve");
            stockRecipe.CreateRecipe("fruit salad", stockIngredients, stockSteps);
            if (DataStore.Book.ContainsKey("fruit salad"))
            {

            }
            else
            {
                DataStore.Book.Add("fruit salad", stockRecipe);
            }
            //Stock Recipe two
            astockIngredientdetailsone.CreateIngredient("grated Cheese", 2, "cups", 911, "dairy");
            astockIngredients.Add(astockIngredientdetailsone.Name, astockIngredientdetailsone);
            astockIngredientdetailstwo.CreateIngredient("cake", 500, "g", 1485, "starch");
            astockIngredients.Add(astockIngredientdetailstwo.Name, astockIngredientdetailstwo);
            astockSteps.Add("Melt the Cheese");
            astockSteps.Add("Pour the melted cheese over the cake");
            astockSteps.Add("Let it cool and serve");
            astockRecipe.CreateRecipe("cheese cake", astockIngredients, astockSteps);
            if (DataStore.Book.ContainsKey("cheese cake"))
            {
            }
            else
            {
                DataStore.Book.Add("cheese cake", astockRecipe);
            }*/
            //----------------------------------------------------------------------------------------------------------------
            printtoList(DataStore.Book);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        //method used to alphabeticaly print the recipes to the GUI list
        public void printtoList(Dictionary<string, Recipe> bk)
        {
            RecipeLst.Items.Clear();
            var sortesDict = bk.OrderBy(KeyValuePair => KeyValuePair.Key);
            Console.WriteLine("Recipe List:");
            foreach (var alph in sortesDict)
            {
                RecipeLst.Items.Add($"{alph.Key}");
            }
        }
        //Closes the window and shuts down the program
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //Hides the main window and opesn the Add/Edit window in Add mode
        private void AddRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            DataStore.edtmode = false;
            AddEditWindow objAddEditWindow = new AddEditWindow();
             this.Hide();
             objAddEditWindow.Show();
            
        }
        //Hides the main window and opens the display window and selects whcih recipe will be displayed
        private void DisplayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeLst.SelectedItem != null)
            {
                DataStore.selection = RecipeLst.SelectedItem.ToString();
                ViewWindow objViewWindow = new ViewWindow();
                this.Hide();
                objViewWindow.Show();
            }
            else
            {
                MessageBox.Show("No Recipe Selected.\nPlease click on a recipe name from the list to select it.");
            }
            
        }
        //Hides the main window and opens the Add/Edit window in Edit mode, selects which recipe will be edited
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if(RecipeLst.SelectedItem != null)
            {
                DataStore.edtmode = true;
                DataStore.selection = RecipeLst.SelectedItem.ToString();
                AddEditWindow objAddEditWindow = new AddEditWindow();
                this.Hide();
                objAddEditWindow.Show();
            }
            else
            {
                MessageBox.Show("No Recipe Selected.\nPlease click on a recipe name from the list to select it.");
            }
        }
        //Prompts the user to make sure, and then deletes the selected recipe
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeLst.SelectedItem != null)
            {
                MessageBoxResult res = MessageBox.Show("Are you sure you want to delete the "+ RecipeLst.SelectedItem + " recipe?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                switch (res)
                {
                    case MessageBoxResult.Yes:
                        DataStore.Book.Remove(RecipeLst.SelectedItem.ToString());
                        printtoList(DataStore.Book);

                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("No Recipe Selected.\nPlease click on a recipe name from the list to delete it.");
            }
        }
        //checks the search bar and search criteria inorder to filter the recipe list
        private void DisplayBtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            
            if (SearchBar.Text != string.Empty)
            {
                string srch = SearchBar.Text;
                Dictionary<string,Recipe> bk = new Dictionary<string, Recipe>();
                Recipe sortrec = new Recipe();
                bk.Clear();
                if (SearchOptions.SelectedIndex == 0)//ingredient search
                {
                    foreach (var item in DataStore.Book)
                    {
                        if (item.Value.recipeIngredients.ContainsKey(srch))
                        {
                            bk.Add(item.Key,item.Value);
                        }
                    }
                    RecipeLst.Items.Clear();
                    var sortesDict = bk.OrderBy(KeyValuePair => KeyValuePair.Key);
                    Console.WriteLine("Recipe List:");
                    foreach (var alph in sortesDict)
                    {
                        RecipeLst.Items.Add($"{alph.Key}");
                    }
                }
                if (SearchOptions.SelectedIndex == 1)//food group search
                {
                    foreach (var item in DataStore.Book)
                    {

                        if (item.Value.containsFG(srch))
                        {
                            bk.Add(item.Key, item.Value);
                        }
                    }
                    RecipeLst.Items.Clear();
                    var sortesDict = bk.OrderBy(KeyValuePair => KeyValuePair.Key);
                    Console.WriteLine("Recipe List:");
                    foreach (var alph in sortesDict)
                    {
                        RecipeLst.Items.Add($"{alph.Key}");
                    }

                }
                if (SearchOptions.SelectedIndex == 2)//max calory search
                {
                    foreach (var item in DataStore.Book)
                    {
                        if (item.Value.Totalcal() < int.Parse(srch))
                        {
                            bk.Add(item.Key, item.Value);
                        }
                    }
                    RecipeLst.Items.Clear();
                    var sortesDict = bk.OrderBy(KeyValuePair => KeyValuePair.Key);
                    Console.WriteLine("Recipe List:");
                    foreach (var alph in sortesDict)
                    {
                        RecipeLst.Items.Add($"{alph.Key}");
                    }
                }
                if (RecipeLst.Items.Count == 0)
                {
                    MessageBox.Show("There are no reicpes that match that search");
                    printtoList(DataStore.Book);
                    SearchBar.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Please type something in the search box to filter the recipe list");
            }
        }
        //resets the search by alphabeticaly listing all recipes
        private void Clear_Search_Click(object sender, RoutedEventArgs e)
        {
            printtoList(DataStore.Book);
        }
    }
}
