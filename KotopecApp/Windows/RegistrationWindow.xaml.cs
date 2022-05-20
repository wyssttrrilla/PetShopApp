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
using System.Windows.Shapes;

namespace KotopecApp.Windows
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            CBRole.ItemsSource = MainWindow.db.Role.ToList();
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TBFullName.Text))
            {
                MessageBox.Show("Enter Full Name");
                return;
            }
            if (string.IsNullOrWhiteSpace(TBLogin.Text))
            {
                MessageBox.Show("Enter Login");
                return;
            }
            if (string.IsNullOrWhiteSpace(TBPassword.Text))
            {
                MessageBox.Show("Enter Password");
                return;
            }
            if (string.IsNullOrWhiteSpace(TBConfirmPassword.Text))
            {
                MessageBox.Show("Enter Confirm Password");
                return;
            }
            if (TBPassword.Text != TBConfirmPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            Model.User user = new Model.User();
            user.Login = TBLogin.Text;
            user.Password = TBPassword.Text;
            user.FullName = TBFullName.Text;
            if (MainWindow.db.User.FirstOrDefault(c=>c.Login == user.Login && c.Password == user.Password) != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                return;
            }
            user.Role = (Model.Role)CBRole.SelectedItem;
            MainWindow.db.User.Add(user);
            MainWindow.db.SaveChanges();
            MessageBox.Show("Added");
            this.Close();
        }
    }
}
