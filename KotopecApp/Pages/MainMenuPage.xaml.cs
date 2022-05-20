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

namespace KotopecApp.Pages
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
            Refresh();
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BDetails_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation()) return;
            Windows.DetailsWindow detailsWindow = new Windows.DetailsWindow((Model.Pet)LVAnimal.SelectedItem);
            detailsWindow.ShowDialog();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddEditAnimalPage addEditAnimalPage = new Windows.AddEditAnimalPage(new Model.Pet());
            addEditAnimalPage.ShowDialog();
            Refresh();
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation()) return;
            Windows.AddEditAnimalPage addEditAnimalPage = new Windows.AddEditAnimalPage((Model.Pet)LVAnimal.SelectedItem);
            addEditAnimalPage.ShowDialog();
            Refresh();
        }

        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation()) return;
            if (MessageBox.Show("Delete Animal?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                MainWindow.db.Pet.Remove((Model.Pet)LVAnimal.SelectedItem);
                Refresh();
                MessageBox.Show("Success");
            }
        }
        private bool Validation()
        {
            if (LVAnimal.SelectedItem is null)
            {
                MessageBox.Show("Select Item");
                return false;
            }
            return true;
        }
        private void Refresh()
        {
            LVAnimal.ItemsSource = null;
            LVAnimal.ItemsSource = MainWindow.db.Pet.ToList();
        }
    }
}
