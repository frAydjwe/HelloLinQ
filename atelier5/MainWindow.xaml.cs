using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using atelier5.ViewModel;

namespace atelier5
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Model.EntrepriseEntities context = new Model.EntrepriseEntities();

            this.MaVue1.DataContext = new MaVueModel1(context);
 

            /*var products = from product in context.Products
                           where product.Unit_Price.HasValue
                           select product.Unit_Price.Value < 10.0m;
             * 
             * this.matchListView.DataContext = new ViewModel.MatchListViewModel(ranking);
             */
        }

        private void MaVue1_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
