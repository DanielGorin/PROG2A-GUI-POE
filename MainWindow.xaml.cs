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
        private Dictionary<string, Recipe> MBook;
        public MainWindow()
        {

            InitializeComponent();
            //stores all the recipes
            MBook = new Dictionary<string, Recipe>();
            //Creates some stock recipes to fill the system
            IngredientDetails stockIngredientdetailsone = new IngredientDetails();
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
            stockIngredientdetailsone.CreateIngredient("apple", 100, "g", 52, "fruit");
            stockIngredients.Add(stockIngredientdetailsone.Name, stockIngredientdetailsone);
            stockIngredientdetailstwo.CreateIngredient("banana", 150, "g", 134, "fruit");
            stockIngredients.Add(stockIngredientdetailstwo.Name, stockIngredientdetailstwo);
            stockIngredientdetailsthree.CreateIngredient("pineapple", 100, "g", 48, "fruit");
            stockIngredients.Add(stockIngredientdetailsthree.Name, stockIngredientdetailsthree);
            stockSteps.Add("Add the apple to a bowl");
            stockSteps.Add("Add the banana to the bowl");
            stockSteps.Add("Add the pineapple to the bowl");
            stockSteps.Add("Mix all the ingredients and serve");
            stockRecipe.CreateRecipe("fruit salad", stockIngredients, stockSteps);
            MBook.Add("fruit salad", stockRecipe);
            //Stock Recipe two
            astockIngredientdetailsone.CreateIngredient("grated Cheese", 2, "cups", 911, "dairy");
            astockIngredients.Add(astockIngredientdetailsone.Name, astockIngredientdetailsone);
            astockIngredientdetailstwo.CreateIngredient("cake", 500, "g", 1485, "starch");
            astockIngredients.Add(astockIngredientdetailstwo.Name, astockIngredientdetailstwo);
            astockSteps.Add("Melt the Cheese");
            astockSteps.Add("Pour the melted cheese over the cake");
            astockSteps.Add("Let it cool and serve");
            astockRecipe.CreateRecipe("cheese cake", astockIngredients, astockSteps);
            MBook.Add("cheese cake", astockRecipe);
            printtoList(MBook);

            
        }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            /* AddEditWindow objAddEditWindow = new AddEditWindow();
             this.Hide();
             objAddEditWindow.Show();*/
            ViewWindow objViewWindow = new ViewWindow();
            this.Hide();
            objViewWindow.Show();
        }

        private void DisplayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeLst.SelectedItem != null)
            {
                DataStore.Book = MBook;
                DataStore.selection = RecipeLst.SelectedItem.ToString();
                ViewWindow objViewWindow = new ViewWindow();
                this.Hide();
                objViewWindow.Show();
            }
            else
            {
                MessageBox.Show("No Recipe Selected.\nPlease click on a recipe name from the list ot select it.");
            }
            
        }
    }
}
