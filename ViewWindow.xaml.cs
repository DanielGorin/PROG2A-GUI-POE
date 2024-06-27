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
        public void bargraph(int hh1,int hh2, int hh3, int hh4, int hh5, int hh6)
        {
            //variables to store the heights of the individual portions of the graph
            int h1 = 2 * hh1;
            int h2 = 2 * hh2;
            int h3 = 2 * hh3;
            int h4 = 2 * hh4;
            int h5 = 2 * hh5;
            int h6 = 2 * hh6;
            //creates the rectangels used for the graph 
            Rectangle rect1 = new Rectangle();
            Rectangle rect2 = new Rectangle();
            Rectangle rect3 = new Rectangle();
            Rectangle rect4 = new Rectangle();
            Rectangle rect5 = new Rectangle();
            Rectangle rect6 = new Rectangle();
            //sets the width of the rectangles
            rect1.Width = 100;
            rect2.Width = 100;
            rect3.Width = 100;
            rect4.Width = 100;
            rect5.Width = 100;
            rect6.Width = 100;
            //sets the height of the rectangels
            rect1.Height = h1;
            rect2.Height = h2;
            rect3.Height = h3;
            rect4.Height = h4;
            rect5.Height = h5;
            rect6.Height = h6;
            //fills the sections with individual colours
            rect1.Fill = Brushes.Blue;
            rect2.Fill = Brushes.Green;
            rect3.Fill = Brushes.Red;
            rect4.Fill = Brushes.Brown;
            rect5.Fill = Brushes.Orange;
            rect6.Fill = Brushes.Purple;
            //centers all the rectangels:
            Canvas.SetLeft(rect1, 113);
            Canvas.SetLeft(rect2, 113);
            Canvas.SetLeft(rect3, 113);
            Canvas.SetLeft(rect4, 113);
            Canvas.SetLeft(rect5, 113);
            Canvas.SetLeft(rect6, 113);
            //swets the y co-ords to create the graph
            Canvas.SetTop(rect1, 292 - h1);
            Canvas.SetTop(rect2, 292 - h1 - h2);
            Canvas.SetTop(rect3, 292 - h1 - h2 - h3);
            Canvas.SetTop(rect4, 292 - h1 - h2 - h3 - h4);
            Canvas.SetTop(rect5, 292 - h1 - h2 - h3 - h4 - h5);
            Canvas.SetTop(rect6, 292 - h1 - h2 - h3 - h4 - h5 - h6);

            // Add the Rectangles to the Canvas
            GraphingCanvas.Children.Add(rect1);
            GraphingCanvas.Children.Add(rect2);
            GraphingCanvas.Children.Add(rect3);
            GraphingCanvas.Children.Add(rect4);
            GraphingCanvas.Children.Add(rect5);
            GraphingCanvas.Children.Add(rect6);
        }

        public void setup() // this code sets all the data in the display page to match the selected/updated recipe
        {
            Recipe DispRecipe = DataStore.Book[DataStore.selection];
            OtptBox.Text = DispRecipe.DisplayRecipe();
            bargraph(20,20,10,10,30,10);   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            this.Close();
            objMainWindow.Show();
        }

        private void AddRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow objAddEditWindow = new AddEditWindow();
            this.Close();
            objAddEditWindow.Show();
        }
    }
}
