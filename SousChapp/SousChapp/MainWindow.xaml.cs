using System;
using System.IO;
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
using System.Diagnostics;

namespace SousChapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Boolean menuVisible = false;

        //Currently highlighted object
        object highlighted;
        //Filter options
        private HashSet<String> cui_opt;
        private HashSet<String> dif_opt;
        private HashSet<String> ing_opt;

        private String search_word;
        public MainWindow()
        {
            InitializeComponent();
            mainMenu.Visibility = Visibility.Hidden;

            cui_opt = new HashSet<string>();
            dif_opt = new HashSet<string>();
            ing_opt = new HashSet<string>();

            this.CuiFilterPopup.setMainWindow(this);
            this.DiffFilterPopup.setMainWindow(this);
            this.IngFilterPopup.setMainWindow(this);

            this.search_word = "";
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
            Image current = (Image)sender;
            this.ChosenRecipe.Margin = current.Margin;
            this.ViewRecipeButton.Margin = new Thickness(current.Margin.Left+130, current.Margin.Top+70,0,0);
            this.ViewRecipeButton.Visibility = Visibility.Visible;
            Border_highlight(this.ChosenRecipe);
        }


        private void Border_highlight(object sender)
        {
            highlighted = sender;
            Rectangle r = (Rectangle)sender;
            r.StrokeThickness = 6;
            r.Stroke = Brushes.LimeGreen;
        }

        private void Border_dehighlight(object sender)
        {
            Rectangle r = (Rectangle)sender;
            r.StrokeThickness = 0;
            this.ViewRecipeButton.Visibility = Visibility.Hidden;
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

            rd.setImage("beansalad.png");
            rd.setRecipeName("Broccoli Rabe and White Bean Salad");
            rd.setCookingTime(25);
            rd.setServing(4);

            rd.addCategory("Easy");
            rd.addCategory("Side");
            rd.addCategory("Vegeterian");
            
            //Steps
            rd.addIngridient("30 oz  of canned white kidney beans");
            rd.addIngridient("3 tbsp olive oil");
            rd.addIngridient("half bunch broccoli rabe");
            rd.addIngridient("4 garlic cloves");
            rd.addIngridient("1 small lemon");
            rd.addIngridient("pinch salt");
            rd.addIngridient("pinch pepper");

            //Tools
            rd.addTool("1 knife");
            rd.addTool("1 pot");
            rd.addTool("1 medium pan");

            //Steps
            rd.addStep("Slice garlic cloves and lemon thinly");
            rd.addStep("Chop broccoli rabe into large chunks");
            rd.addStep("Heat oil in a pan and add garlic and lemons, cook until golden brown");
            rd.addStep("Add broccoli into the pan and cook until wilted");
            rd.addStep("Drain beans and boil in pot with 1/2 cup water for 3 mins");
            rd.addStep("Drain beans and add to pan");
            rd.addStep("Salt and pepper to taste");
            rd.addStep("Serve immediately");

            rd.setImage("quesadilla.png");
            rd.setRecipeName("Quick Cheesy Quesadillas");
            rd.setCookingTime(25);
            rd.setServing(6);

            rd.addCategory("Easy");
            rd.addCategory("Lunch");
            rd.addCategory("Vegeterian");
            
            //Steps
            rd.addIngridient("6 flour torillas");
            rd.addIngridient("1 1/2 cups shredded cheddar cheese");
            rd.addIngridient("2 green onions");
            rd.addIngridient("jar of salsa");
            rd.addIngridient("canola oil");

            //Tools
            rd.addTool("1 knife");
            rd.addTool("1 large pan");

            //Steps
            rd.addStep("Slice green onions thinly");
            rd.addStep("Lay out tortilla and add 1/4 cheese, 1 tbsp salsa, and a sprinkle of green onions to half of the tortilla");
            rd.addStep("Brush edge of tortilla with water and fold it over, press to seal");
            rd.addStep("Heat oil in pan over medium heat, add in quesadilla and cook until golden on both sides");
            rd.addStep("Cut into triangles");
            rd.addStep("Serve immediately with salsa");

            DynamicRecipeView drv = new DynamicRecipeView(rd, this);

            drv.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
            //drv.Show();
            //this.Close();
            Border_dehighlight(highlighted);


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

        

        public void setCuiFilter(HashSet<String> cui_opt) {

            this.cui_opt = cui_opt;

            if (cui_opt.Count > 0){
                filter_cui.Text = "Matching results for cusine(s): ";
                for (int i = 0; i < cui_opt.Count; i++)
                {
                    if (i != cui_opt.Count - 1)
                    {
                       filter_cui.Inlines.Add("\"" + cui_opt.ElementAt(i) + "\", ");
                    }
                    else
                    {
                        filter_cui.Inlines.Add("\"" + cui_opt.ElementAt(i) + "\"");
                    }


                }
            }
            else{
                filter_cui.Text = "";
            }

        }

        public void setDifFilter(HashSet<String> dif_opt)
        {

            this.dif_opt = dif_opt;

            if (dif_opt.Count > 0)
            {
                filter_dif.Text = "Matching results for difficulty: ";
                for (int i = 0; i < dif_opt.Count; i++)
                {
                    if (i != dif_opt.Count - 1)
                    {
                        filter_dif.Inlines.Add("\"" + dif_opt.ElementAt(i) + "\", ");
                    }
                    else
                    {
                        filter_dif.Inlines.Add("\"" + dif_opt.ElementAt(i) + "\"");
                    }


                }
            }
            else
            {
                filter_dif.Text = "";
            }

        }

        public void setIngFilter(HashSet<String> ing_opt)
        {

            this.ing_opt = ing_opt;

            if (ing_opt.Count > 0)
            {
                filter_ing.Text = "Matching results for ingredient(s): ";
                for (int i = 0; i < ing_opt.Count; i++)
                {
                    if (i != ing_opt.Count - 1)
                    {
                        filter_ing.Inlines.Add("\"" + ing_opt.ElementAt(i) + "\", ");
                    }
                    else
                    {
                        filter_ing.Inlines.Add("\"" + ing_opt.ElementAt(i) + "\"");
                    }


                }
            }
            else
            {
                filter_ing.Text = "";
            }

        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.mainMenu.Visibility = Visibility.Hidden;
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.SearchBox.Text = "";
        }

        private void SearchSmall_Click(object sender, RoutedEventArgs e)
        {
            this.viewSearch.Visibility = Visibility.Hidden;
            this.SearchBox.Visibility = Visibility.Visible;
            this.SearchLarge.Visibility = Visibility.Visible;
            this.OSKeyboard.Visibility = Visibility.Visible;
            this.SearchSmall.Visibility = Visibility.Hidden;
        }

        private void SearchLarge_Click(object sender, RoutedEventArgs e)
        {
            
            this.search_word = this.SearchBox.Text;
            if (this.search_word.Length > 0) {
                this.viewSearch.Text = "Matching results for: \"" + this.SearchBox.Text + "\"";
                this.viewSearch.Visibility = Visibility.Visible;
            }
            
            this.SearchBox.Visibility = Visibility.Hidden;
            this.SearchLarge.Visibility = Visibility.Hidden;
            this.OSKeyboard.Visibility = Visibility.Hidden;
            this.SearchSmall.Visibility = Visibility.Visible;
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
           //this.SearchBox.Text = "";
            
            
        }
    }
}
