using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class CuiFilter : UserControl
    {
        private HashSet<String> all_options;
        private MainWindow mw;
        public CuiFilter()
        {
            InitializeComponent();
            all_options = new HashSet<String>();
            findChecked();


        }


        private void findChecked() {
            all_options.Clear();
            foreach (var checkBox in Checkbox_grid.Children.OfType<CheckBox>().Where(cb => (bool)cb.IsChecked)){
                var name = checkBox.Name;
                all_options.Add(name);
                
            }
        }

        public void setMainWindow(MainWindow mw) {
            this.mw = mw;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            //Check those who we have picked before
            foreach (var checkBox in Checkbox_grid.Children.OfType<CheckBox>().Where(cb => (bool)cb.IsChecked)){
                
                var name = checkBox.Name;
                if (!all_options.Contains(name)) { //Check those we have picked right now, and if they are new, because we cancel, mark them as false
                    checkBox.IsChecked = false;
                }
                    

            }
            this.Visibility = Visibility.Hidden;
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e){
            findChecked();
           
            this.mw.setCuiFilter(all_options);
            this.Visibility = Visibility.Hidden;
            
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e) {
            foreach (var checkBox in Checkbox_grid.Children.OfType<CheckBox>()){
                checkBox.IsChecked = false;
            }
            all_options.Clear();
        }

       
    }
}
