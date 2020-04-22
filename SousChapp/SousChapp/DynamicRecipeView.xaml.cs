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
using System.Windows.Shapes;

namespace SousChapp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class DynamicRecipeView : Window
    {

        private ArrayList steps_arraylist;
        private MainWindow mw;
        
        public DynamicRecipeView(RecipeDetails rd, MainWindow mw)
        {
            InitializeComponent();

            this.mw = mw;

            this.steps_arraylist = rd.getSteps();
            this.step.initializeStepper(this.steps_arraylist);

            setImage(rd.getImage());
            setName(rd.getRecipeName());
            setCookingTime(rd.getCookingTime());
            setServing(rd.getServing());
            setCategories(rd.getCategories());

            setTools(rd.getTools());
            setIngridients(rd.getIngridients());
            setSteps(rd.getSteps());

            


        }

        private void setName(String name) {
            this.recipeName.Text = name;
        }

        private void setCookingTime(int time) {
            this.recipeCookingTime.Text = "Cooking time: "+time.ToString();
        }

        private void setServing(int serv)
        {
            this.recipeServing.Text = "Servings: " + serv.ToString();
        }

        private void setCategories(ArrayList categories) {
            this.recipeCatgories.Inlines.Add("Categories: ");
            int length = categories.Count;
            int i = 1;
            foreach (String category in categories) {
                if (i != length)
                {
                    this.recipeCatgories.Inlines.Add(category + ", ");
                }
                else {
                    this.recipeCatgories.Inlines.Add(category);
                }
                i++;
                
            }
        }

        private void setImage(String image) {
            Uri uri = new Uri(image, UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uri);
            this.recipeImage.Source = imgSource;
            
        }

        private void setTools(ArrayList tools_array) {
            foreach (String tool in tools_array) {
                this.tools.Inlines.Add(tool);
                this.tools.Inlines.Add("\n");
            }
        }

        private void setIngridients(ArrayList ingridients_array) {
            foreach (String ing in ingridients_array)
            {
                this.ingredients.Inlines.Add(ing);
                this.ingredients.Inlines.Add("\n");
            }
        }

        private void setSteps(ArrayList steps_array)
        {
            int i = 1;
            foreach (String step in steps_array){
                if (i >= 9)
                {
                    this.steps.Height += 20;
                    this.recipeCanvas.Height += 20;
                }

                this.steps.Inlines.Add(i+ ") "+step);
                this.steps.Inlines.Add("\n");
                i++;
                
                
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.recipeGrid.Style = this.mainGrid.Resources["Blurred"] as Style;
            
            this.step.Visibility = Visibility.Visible;
            this.step.rv = this;
        }

  

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            this.step.reset();
            this.startButton.IsEnabled = false;
            this.recipeGrid.Style = this.mainGrid.Resources["Blurred"] as Style;
            this.step.Visibility = Visibility.Visible;
            this.step.rv = this;
            
        }

        private void contButton_Click(object sender, RoutedEventArgs e) {
            this.startButton.IsEnabled = false;
            this.contButton.IsEnabled = false;
            this.cancelButton.IsEnabled = false;
            this.step.Visibility = Visibility.Visible;
            this.recipeGrid.Style = this.mainGrid.Resources["Blurred"] as Style;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.startButton.IsEnabled = true;
            this.step.Visibility = Visibility.Hidden;

            this.startButton.Visibility = Visibility.Visible;
            this.startButton.IsEnabled = true;


            this.contButton.Visibility = Visibility.Hidden;
            this.cancelButton.Visibility = Visibility.Hidden;

            this.step.reset();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e) {

            //this.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
            //mw.Show();


        }
    }
}
