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
            item.Foreground = Brushes.Red;
        }

        private void MenuMouseLeave(object sender, MouseEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            item.Foreground = Brushes.Black;
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
