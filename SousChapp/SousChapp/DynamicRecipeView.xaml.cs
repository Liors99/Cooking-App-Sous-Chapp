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
        public DynamicRecipeView(RecipeDetails rd)
        {
            InitializeComponent();

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
                this.steps.Inlines.Add(i+ ") "+step);
                this.steps.Inlines.Add("\n");
            }
        }


    }
}
