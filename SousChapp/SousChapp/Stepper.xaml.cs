using System;
using System.Collections;
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
        public DynamicRecipeView rv;

        private ArrayList steps;
        private int current;

        public Stepper()
        {
            InitializeComponent();
        }

        public void initializeStepper(ArrayList steps) {
            this.steps = steps;
            reset();

            
            
        }

        public void reset() {
            this.current = 0;
            changeText();

        }

        private void changeText() {
            if (current == this.steps.Count-1)
            {
                this.FinishButton.Visibility = Visibility.Visible;
                this.NextButton.Visibility = Visibility.Hidden;
                this.ComingUpLabel.Visibility = Visibility.Hidden;

                this.StepDetail.Text = (String)this.steps[current];
                if (current != 0) {
                    this.prevButton.Visibility = Visibility.Visible;
                }

            }
            else if (current == 0) {

                this.FinishButton.Visibility = Visibility.Hidden;

                this.FinishButton.Visibility = Visibility.Hidden;
                this.prevButton.Visibility = Visibility.Hidden;
                this.NextButton.Visibility = Visibility.Visible;

                this.StepDetail.Text = (String)this.steps[current];
                
                
                this.ComingUpLabel.Visibility = Visibility.Visible;
                this.ComingUpLabel.Content = (String)this.steps[current+1];
            }
            else
            {
                this.FinishButton.Visibility = Visibility.Hidden;

                this.NextButton.Visibility = Visibility.Visible;
                this.prevButton.Visibility = Visibility.Visible;

                this.StepDetail.Text = (String)this.steps[current];

                this.ComingUpLabel.Visibility = Visibility.Visible;
                this.ComingUpLabel.Content = (String)this.steps[current+1];
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e) {
            current++;
            changeText();
        }

        private void prevButton_Click(object sender, RoutedEventArgs e) {

            current--;
            changeText();
        }

        private void finishButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            rv.recipeGrid.Style = rv.mainGrid.Resources["Default"] as Style;

            rv.contButton.Visibility = Visibility.Hidden;
            rv.cancelButton.Visibility = Visibility.Hidden;
            rv.startButton.Visibility = Visibility.Visible;
            rv.startButton.IsEnabled = true;
        }



        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            
            this.Visibility = Visibility.Hidden;
            rv.recipeGrid.Style = rv.mainGrid.Resources["Default"] as Style;
            rv.contButton.Visibility = Visibility.Visible;
            rv.cancelButton.Visibility = Visibility.Visible;
            rv.startButton.Visibility = Visibility.Hidden;
            rv.startButton.IsEnabled = true;

        }
    }
}
