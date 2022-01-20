using QueryRunner.BLL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using UX.API;
using XQA.DAL;

namespace UX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string searchModel = "";
        ObservableCollection<string> results = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void ClearTextBoxButton(object sender, RoutedEventArgs e)
        {
            this.QueryTextBox.Text = "";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            searchModel = (string)cmb.SelectedValue;
        }

        private void intOnlySlider(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.TresholdSlider.Value = Math.Round(this.TresholdSlider.Value, 0);
        }

        private void LoadSearchModel(object sender, RoutedEventArgs e)
        {
            IList<string> SearchModel = new List<string>() { "Boolean Search", "Vector Space Search" };
            ComboBox cb = (ComboBox)sender;
            cb.ItemsSource = SearchModel;
            cb.SelectedIndex = 0;
        }        

        private void SubmitTextBoxButton(object sender, RoutedEventArgs e)
        {
            Query q = new Query(this.QueryTextBox.Text);
            switch (searchModel)
            {
                case "Boolean Search":
                    foreach (var s in new BBSE_Proxy().runQuery(q))
                        results.Add(s);
                    break;

                case "Vector Space Search":
                    foreach (var s in new VSSE_Proxy().runQuery(q))
                        results.Add(s);
                    break;
            }
        }
        
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if()
        }

        private void loadIndex(object sender, MouseButtonEventArgs e)
        {
            IndexDAO iDAO = new IndexDAO();
            foreach (var s in iDAO.fetchAllPostings())
                results.Add(s.ToString());
        }
    }
}
