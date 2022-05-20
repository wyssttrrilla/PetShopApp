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

namespace KotopecApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Model.KotoPesDBEntities1 db = new Model.KotoPesDBEntities1();
        public static Model.User loggedUser;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.AuthroizationPage());
        }
    }
}
