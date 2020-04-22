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

            /*
            //Testing code
            RecipeDetails rd = new RecipeDetails();

            rd.setImage("star.png");
            rd.setRecipeName("BEST RECIPE NAME EVER");
            rd.setServing(1);
            rd.setCookingTime(20);
            rd.addCategory("Easy");

            rd.addIngridient("Pasta");
            rd.addIngridient("Water");
            rd.addStep("Some step number #1");
            rd.addStep("Some step number #2");

            rd.addTool("some tool #1");
            rd.addTool("some tool #2");

            DynamicRecipeView drv = new DynamicRecipeView(rd);


            drv.Show();
            this.Close();
            */
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

        private void Split_Screen(object sender, RoutedEventArgs e)
        {
            SplitWindow split = new SplitWindow();
            split.Show();
            this.Close();
        }


        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.ViewRecipeButton.Visibility = Visibility.Visible;
            Border_highlight(this.ChosenRecipe);
        }


        private void Border_highlight(object sender)
        {
            
            Rectangle r = (Rectangle)sender;
            r.StrokeThickness = 6;
            r.Stroke = Brushes.LimeGreen;
        }

        private void Border_dehighlight(object sender)
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

        private void ViewRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            
            RecipeDetails rd = new RecipeDetails();

            rd.setImage("frenchomelet.png");
            rd.setRecipeName("French Omelette ");
            rd.setCookingTime(15);
            rd.setServing(1);

            rd.addCategory("Easy");
            rd.addCategory("Breakfast");
            rd.addCategory("Eggs");
            rd.addCategory("Vegeterian");
            
            //Steps
            rd.addIngridient("4 large eggs");
            rd.addIngridient("1 tbsp olive oil");
            rd.addIngridient("100 grams cheddar cheese");
            rd.addIngridient("pinch salt");
            rd.addIngridient("pinch pepper");

            //Tools
            rd.addTool("1 cup");
            rd.addTool("1 fork");
            rd.addTool("1 medium pan");
            rd.addTool("1 spatula");

            //Steps
            rd.addStep("Heat 1 table spoon of olive oil in a pan over medium heat");
            rd.addStep("In a cup, beat 4 large eggs");
            rd.addStep("Add salt and pepper to taste");
            rd.addStep("Pour eggs into pan");
            rd.addStep("Cook until eggs set");
            rd.addStep("Using the spatula, flip the omelette");
            rd.addStep("Spread cheese over the omelette");
            rd.addStep("Cook for 3 minutes and fold");
            rd.addStep("Serve immediately1");
            rd.addStep("Serve immediately2");

            DynamicRecipeView drv = new DynamicRecipeView(rd, this);

            //drv.Visibility = Visibility.Visible;
            //this.Visibility = Visibility.Hidden;
            drv.Show();
            this.Close();
        }

        private void SearchSmall_Click(object sender, RoutedEventArgs e)
        {
            this.SearchBox.Visibility = Visibility.Visible;
            this.SearchLarge.Visibility = Visibility.Visible;
            this.OSKeyboard.Visibility = Visibility.Visible;
            this.SearchSmall.Visibility = Visibility.Hidden;
        }

        private void OptIng_Click(object sender, RoutedEventArgs e)
        {
            this.IngFilterPopup.Visibility = Visibility.Visible;
            this.mainMenu.Visibility = Visibility.Hidden;
        }

        private void OptCui_Click(object sender, RoutedEventArgs e)
        {
            this.CuiFilterPopup.Visibility = Visibility.Visible;
            this.mainMenu.Visibility = Visibility.Hidden;

        }

        private void OptDiff_Click(object sender, RoutedEventArgs e)
        {
            this.DiffFilterPopup.Visibility = Visibility.Visible;
            this.mainMenu.Visibility = Visibility.Hidden;

        }
    }
}
