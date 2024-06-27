using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
    public partial class ViewWindow : Window
    {
        public ViewWindow()
        {
            InitializeComponent();
            setup();
        }
        public void bargraph(List<int> hh)
        {

            StarchBlueTXT.Text = (hh[0] +"% Starch");
            BlcokBlue.Fill = Brushes.Blue;
            VegGreenTxt.Text = (hh[1] + "% Fruit and Veg");
            BlcokGreen.Fill = Brushes.Green;
            BeansRedTxt.Text = (hh[2] + "% Beans");
            BlockRed.Fill = Brushes.Red;
            MeatBrownTxt.Text = (hh[3] + "% Meat");
            BlockBrown.Fill = Brushes.LightBlue;
            FatOrangeTxt.Text = (hh[4] + "% Fats");
            BlcokOrange.Fill = Brushes.Orange;
            DairyPurpleTxt.Text = (hh[5] + "% Dairy");
            BlockPurple.Fill = Brushes.Purple;
            WaterPinkTxt.Text = (hh[6] + "% Water");
            BlockPink.Fill = Brushes.Pink;


            //variables to store the heights of the individual portions of the graph
            int h1 = 2 * hh[0];
            int h2 = 2 * hh[1];
            int h3 = 2 * hh[2];
            int h4 = 2 * hh[3];
            int h5 = 2 * hh[4];
            int h6 = 2 * hh[5];
            int h7 = 2 * hh[6];
            //creates the rectangels used for the graph 
            Rectangle rect1 = new Rectangle();
            Rectangle rect2 = new Rectangle();
            Rectangle rect3 = new Rectangle();
            Rectangle rect4 = new Rectangle();
            Rectangle rect5 = new Rectangle();
            Rectangle rect6 = new Rectangle();
            Rectangle rect7 = new Rectangle();
            //sets the width of the rectangles
            rect1.Width = 100;
            rect2.Width = 100;
            rect3.Width = 100;
            rect4.Width = 100;
            rect5.Width = 100;
            rect6.Width = 100;
            rect7.Width = 100;
            //sets the height of the rectangels
            rect1.Height = h1;
            rect2.Height = h2;
            rect3.Height = h3;
            rect4.Height = h4;
            rect5.Height = h5;
            rect6.Height = h6;
            rect7.Height = h7;
            //fills the sections with individual colours
            rect1.Fill = Brushes.Blue;
            rect2.Fill = Brushes.Green;
            rect3.Fill = Brushes.Red;
            rect4.Fill = Brushes.LightBlue;
            rect5.Fill = Brushes.Orange;
            rect6.Fill = Brushes.Purple;
            rect7.Fill = Brushes.Pink;
            //centers all the rectangels:
            Canvas.SetLeft(rect1, 20);
            Canvas.SetLeft(rect2, 20);
            Canvas.SetLeft(rect3, 20);
            Canvas.SetLeft(rect4, 20);
            Canvas.SetLeft(rect5, 20);
            Canvas.SetLeft(rect6, 20);
            Canvas.SetLeft(rect7, 20);
            //swets the y co-ords to create the graph
            Canvas.SetTop(rect1, 292 - h1);
            Canvas.SetTop(rect2, 292 - h1 - h2);
            Canvas.SetTop(rect3, 292 - h1 - h2 - h3);
            Canvas.SetTop(rect4, 292 - h1 - h2 - h3 - h4);
            Canvas.SetTop(rect5, 292 - h1 - h2 - h3 - h4 - h5);
            Canvas.SetTop(rect6, 292 - h1 - h2 - h3 - h4 - h5 - h6);
            Canvas.SetTop(rect7, 292 - h1 - h2 - h3 - h4 - h5 - h6 - h7);

            // Add the Rectangles to the Canvas
            GraphingCanvas.Children.Add(rect1);
            GraphingCanvas.Children.Add(rect2);
            GraphingCanvas.Children.Add(rect3);
            GraphingCanvas.Children.Add(rect4);
            GraphingCanvas.Children.Add(rect5);
            GraphingCanvas.Children.Add(rect6);
            GraphingCanvas.Children.Add(rect7);
        }

        public void setup() // this code sets all the data in the display page to match the selected/updated recipe
        {
            Recipe DispRecipe = DataStore.Book[DataStore.selection];
            OtptBox.Text = DispRecipe.DisplayRecipe();

            bargraph(DispRecipe.FoodGroupPerc());   
        }

        private void AddRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            
            DataStore.edtmode = false;
            AddEditWindow objAddEditWindow = new AddEditWindow();
            this.Hide();
            objAddEditWindow.Show();

        }

        private void ResetScalebtn_Click(object sender, RoutedEventArgs e)
        {
            DataStore.Book[DataStore.selection].ResetQuant();
            setup();
        }

        private void _3xScaleBtn_Click(object sender, RoutedEventArgs e)
        {
            DataStore.Book[DataStore.selection].ScaleQuant(3);
            setup();
        }

        private void _2xScalebtn_Click(object sender, RoutedEventArgs e)
        {
            DataStore.Book[DataStore.selection].ScaleQuant(2);
            setup();
        }

        private void Scale0_5btn_Click(object sender, RoutedEventArgs e)
        {
            DataStore.Book[DataStore.selection].ScaleQuant(0.5f);
            setup();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            this.Close();
            objMainWindow.Show();
        }
    }
}
