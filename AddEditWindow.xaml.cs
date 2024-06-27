using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PROG2A_GUI_POE
{
    /// <summary>
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        //Dictionary uised to store all the ingredients
        Dictionary<string, IngredientDetails> Ingredients = new Dictionary<string, IngredientDetails>();
        //List used to store all the instructions
        List<string> steps = new List<string>();
        //creates an instance of the ingredientdetails class
        IngredientDetails holder = new IngredientDetails();
        //Creates an instance of the recipe class
        Recipe HoldRecipe = new Recipe();

        public AddEditWindow()
        {
            //Clears all inputs
            InitializeComponent();
            NameBox.Text = string.Empty;
            IngredientNameBox.Text = string.Empty;
            IngMeasureBox.Text = string.Empty;
            IngQuantBox.Text = string.Empty;
            IngCalBox.Text = string.Empty;
            IngredientList.Items.Clear();
            Instructions_Box.Text = string.Empty;
            StarchRad.IsChecked = false;
            FandVRad.IsChecked = false;
            BeansRad.IsChecked = false;
            MeatRad.IsChecked = false;
            FatsRad.IsChecked = false;
            DairyRad.IsChecked = false;
            WaterRad.IsChecked = false;
            AllInsBox.Text = string.Empty;
            //if the window is needed for an edit this sets it up
            if (DataStore.edtmode)
            {
                HoldRecipe = DataStore.Book[DataStore.selection];
                Ingredients = HoldRecipe.recipeIngredients;
                steps = HoldRecipe.recipeSteps;
                int count = 0;
                string otpt = "";
                foreach (var stp in steps)
                {
                    count++;
                    otpt = (otpt + count.ToString() + ". " + stp + "\n");
                }
                AllInsBox.Text = otpt;
                NameBox.Text = HoldRecipe.recipeName;
                foreach (var ing in Ingredients)
                {
                    IngredientList.Items.Add(ing.Key);
                }
            }

        }


        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            NameBox.Text = string.Empty;
            IngredientNameBox.Text = string.Empty;
            IngMeasureBox.Text = string.Empty;
            IngQuantBox.Text = string.Empty;
            IngCalBox.Text = string.Empty;
            IngredientList.Items.Clear();
            Instructions_Box.Text = string.Empty;
            StarchRad.IsChecked = false;
            FandVRad.IsChecked = false;
            BeansRad.IsChecked = false;
            MeatRad.IsChecked = false;
            FatsRad.IsChecked = false;
            DairyRad.IsChecked = false;
            WaterRad.IsChecked = false;
            AllInsBox.Text = string.Empty;
            Ingredients.Clear();
            steps.Clear();

        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            this.Close();
            objMainWindow.Show();
        }

        private void AddIngBtn_Click(object sender, RoutedEventArgs e)
        {
            //Variable used to detect errors
            bool legit = true;
            //variables used to store components of the ingrdeient and recipe classes
            string ingname = "";
            float ingquant = 0;
            string meas = "";
            float cal = 0;
            string fgroup = "";

            if (IngredientNameBox.Text != string.Empty)
            {
                if (IngredientList.Items.Contains(IngredientNameBox.Text))
                {
                    MessageBox.Show("An ingredeint of that name has already been included.");
                    legit = false;
                }
                else
                {
                    ingname = IngredientNameBox.Text;
                }
            }
            else
            {
                legit = false;
                MessageBox.Show("Please include an Ingredient name to create an ingredient.");
            }
            if (IngMeasureBox.Text != string.Empty)
            {
                meas = IngMeasureBox.Text;
            }
            else
            {
                legit = false;
                MessageBox.Show("Please include an Ingredient measurement to create an ingredient.");
            }
            if (StarchRad.IsChecked == true || FandVRad.IsChecked == true || BeansRad.IsChecked == true || MeatRad.IsChecked == true || FatsRad.IsChecked == true || DairyRad.IsChecked == true || WaterRad.IsChecked == true)
            {
                if (StarchRad.IsChecked == true)
                {
                    fgroup = "starch";
                }
                if (FandVRad.IsChecked == true)
                {
                    fgroup = "fruit and veg";
                }
                if (BeansRad.IsChecked == true)
                {
                    fgroup = "beans";
                }
                if (MeatRad.IsChecked == true)
                {
                    fgroup = "meat";
                }
                if (FatsRad.IsChecked == true)
                {
                    fgroup = "fat";
                }
                if (DairyRad.IsChecked == true)
                {
                    fgroup = "dairy";
                }
                if (WaterRad.IsChecked == true)
                {
                    fgroup = "water";
                }
            }
            else
            {
                legit = false;
                MessageBox.Show("Please select a food group to create an ingredient.");
            }
            try
            {
                ingquant = float.Parse(IngQuantBox.Text.Replace(".", ","));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingredient quality must be a valid number to create an ingredient");
                legit = false;
            }
            try
            {
                cal = float.Parse(IngCalBox.Text.Replace(".", ","));
            }
            catch (Exception ex)
            {
                legit = false;
                MessageBox.Show("Ingredient calories must be a valid number to create an ingredient");
            }
            if (legit)
            {
                //populates the new ingredient
                holder.CreateIngredient(ingname, ingquant, meas, cal, fgroup);
                //Adds to the ingredients collection
                Ingredients.Add(ingname, holder);
                //Adds the Ingredeint to the GUI list
                IngredientList.Items.Add(ingname);
                //clears the create ingredient inputs
                IngredientNameBox.Text = string.Empty;
                IngMeasureBox.Text = string.Empty;
                IngQuantBox.Text = string.Empty;
                IngCalBox.Text = string.Empty;
                StarchRad.IsChecked = false;
                FandVRad.IsChecked = false;
                BeansRad.IsChecked = false;
                MeatRad.IsChecked = false;
                FatsRad.IsChecked = false;
                DairyRad.IsChecked = false;
                WaterRad.IsChecked = false;
            }
            



        }

        private void DelIngBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IngredientList.SelectedItem != null)
            {
                Ingredients.Remove(IngredientList.SelectedItem.ToString());
                IngredientList.Items.Remove(IngredientList.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("No ingredient selected.\nPlease click on an ingredient name from the list ot select it.");
            }
        }

        private void AddInsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Instructions_Box.Text != string.Empty)
            {
                steps.Add(Instructions_Box.Text);


                AllInsBox.Text += steps.Count.ToString() + ". " + Instructions_Box.Text + "\n";
                Instructions_Box.Text = string.Empty;

            }
            else
            {
                MessageBox.Show("Please type an instuction in the new instructions box.");
            }
        }

        private void ClrInsBtn_Click(object sender, RoutedEventArgs e)
        {
            steps.Clear();
            AllInsBox.Text = string.Empty;
        }

        //stores all Gui inputs in variables and checks that all inputs are acceptable
        private void AddRecBtn_Click(object sender, RoutedEventArgs e)
        {
            string nam = "";
            bool axpt = true;
            if (NameBox.Text != string.Empty) 
            {
                if (DataStore.Book.ContainsKey(NameBox.Text))
                {
                    if ((DataStore.edtmode) && (NameBox.Text == DataStore.selection))
                    {
                        nam = NameBox.Text;
                    }
                    else
                    {
                        axpt = false;
                        MessageBox.Show("A Recipe of that name is already in the system");
                    }
                }
                else
                {
                    nam = NameBox.Text;
                }
            }
            else
            {
                axpt = false;
                MessageBox.Show("Please add a recipe name to create your recipe.");
            }
            if (steps.Count == 0)
            {
                axpt= false;
                MessageBox.Show("Please add some steps to create your recipe.");
            }
            if (Ingredients.Count == 0)
            {
                axpt= false;
                MessageBox.Show("Please add some ingredients to create your recipe.");
            }
            if ( axpt)
            {
                MessageBoxResult res = MessageBox.Show("Are you sure you are done creating your recipe?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (res)
                {
                    case MessageBoxResult.Yes:
                        //populates the new recipe
                        HoldRecipe.CreateRecipe(nam, Ingredients, steps);
                        if (DataStore.edtmode)
                        {
                            DataStore.Book.Remove(DataStore.selection);
                        }
                        DataStore.Book.Add(HoldRecipe.recipeName, HoldRecipe);
                        MainWindow objMainWindow = new MainWindow();
                        this.Close();
                        objMainWindow.Show();

                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            
        }
    }
}
