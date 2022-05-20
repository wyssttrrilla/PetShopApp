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
    /// Interaction logic for AuthroizationPage.xaml
    /// </summary>
    public partial class AuthroizationPage : Page
    {
        public AuthroizationPage()
        {
            InitializeComponent();
        }

        private void BAuthorization_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBLogin.Text))
            {
                MessageBox.Show("Enter login");
                return;
            }
            if (string.IsNullOrWhiteSpace(PBPassword.Password))
            {
                MessageBox.Show("Enter Password");
                return;
            }
            Model.User user = MainWindow.db.User.FirstOrDefault(c=>c.Login == TBLogin.Text && c.Password == PBPassword.Password);
            if (user is null)
            {
                MessageBox.Show("Unkown user");
                return;
            }
            MainWindow.loggedUser = user;
            MessageBox.Show("Успешный вход");
            NavigationService.Navigate(new Pages.MainMenuPage());
        }

        private void BRegistration_Click(object sender, RoutedEventArgs e)
        {
            Windows.RegistrationWindow registrationWindow = new Windows.RegistrationWindow();
            registrationWindow.ShowDialog();
        }
    }
}
