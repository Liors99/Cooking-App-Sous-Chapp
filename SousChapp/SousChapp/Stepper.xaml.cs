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
    /// Interaction logic for UserControl4.xaml
    /// </summary>
    public partial class Stepper : UserControl

    {
        public RecipeView rv;
        public Stepper()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.FinishButton.Visibility = Visibility.Visible;
            this.NextButton.Visibility = Visibility.Hidden;
            this.ComingUpLabel.Visibility = Visibility.Hidden;
            this.StepTools.Text = "Tools and Ingredients";
            this.StepDetail.Text = "\n\nServe immediately";
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            RecipePause rp = new RecipePause();
            rv.Close();
            rp.Show();
        }
    }
}
