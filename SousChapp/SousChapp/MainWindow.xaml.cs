using System;
using System.Collections.Generic;
using System.Linq;
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

namespace SousChapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Boolean menuVisible = false;
        public MainWindow()
        {
            InitializeComponent();
            mainMenu.Visibility = Visibility.Hidden;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            text1.Text = "Hello World";
        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {
            text1.Text = "Hello World";
        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {
            text1.Text = "Goodbye World";
        }


        private void MenuMouseEnter(object sender, MouseEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            item.Foreground = Brushes.Black;
        }

        private void MenuMouseLeave(object sender, MouseEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            item.Foreground = Brushes.White;
        }

        private void ShowMenu_Click(object sender, RoutedEventArgs e)
        {
            Button me = (Button)sender;
            if (!menuVisible)
            {
                mainMenu.Visibility = Visibility.Visible;
                menuVisible = true;
            }
            else
            {
                mainMenu.Visibility = Visibility.Hidden;
                menuVisible = false;
            }
        }

        private void Option_Click(object sender, RoutedEventArgs e)
        {
            MenuItem choice = (MenuItem)sender;
            text1.Text = choice.Header.ToString();
        }

        private void Split_Screen(object sender, RoutedEventArgs e)
        {
            SplitWindow split = new SplitWindow();
            split.Show();
            this.Close();
        }


        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RecipeView recipe = new RecipeView();
            recipe.Show();
            this.Close();
        }


        private void Border_highlight(object sender, MouseEventArgs e)
        {
            
            Rectangle r = (Rectangle)sender;
            r.StrokeThickness = 6;
            r.Stroke = Brushes.LimeGreen;
        }

        private void Border_dehighlight(object sender, MouseEventArgs e)
        {
            Rectangle r = (Rectangle)sender;
            r.StrokeThickness = 3;

            Color newRed = Color.FromRgb(255, 91, 89);
            Color newPink = Color.FromRgb(253, 159, 132);

            // Create a diagonal linear gradient with four stops.   
            LinearGradientBrush myLinearGradientBrush =
                new LinearGradientBrush();
            myLinearGradientBrush.StartPoint = new Point(0, 0);
            myLinearGradientBrush.EndPoint = new Point(1, 1);
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop(newRed, 1.0));
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop(newPink, 0.0));


            // Use the brush to paint the rectangle.
            r.Stroke = myLinearGradientBrush;
        }
    }
}
