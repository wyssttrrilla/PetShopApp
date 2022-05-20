using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace KotopecApp.Windows
{
    /// <summary>
    /// Interaction logic for AddEditAnimalPage.xaml
    /// </summary>
    public partial class AddEditAnimalPage : Window
    {
        Model.Pet postAnimal;
        public AddEditAnimalPage(Model.Pet animal)
        {
            InitializeComponent();
            postAnimal = animal;
            this.DataContext = postAnimal;
        }

        private void BChangePicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                postAnimal.ImagePet = File.ReadAllBytes(openFileDialog.FileName);
                MemoryStream byteStream = new MemoryStream(postAnimal.ImagePet);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                IPicture.Source = image;
            }
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBName.Text))
            {
                MessageBox.Show("Enter Name");
                return;
            }
            if (string.IsNullOrWhiteSpace(TBHeight.Text))
            {
                MessageBox.Show("Enter Height");
                return;
            }
            if (string.IsNullOrWhiteSpace(TBWeight.Text))
            {
                MessageBox.Show("Enter Weight");
                return;
            }
            if (string.IsNullOrWhiteSpace(TBDescription.Text))
            {
                MessageBox.Show("Enter Description");
                return;
            }
            if (postAnimal.ImagePet is null)
            {
                MessageBox.Show("Set Photo");
                return;
            }
            postAnimal.Name = TBName.Text;
            postAnimal.Height = Convert.ToInt32(TBHeight.Text);
            postAnimal.Weight = Convert.ToInt32(TBWeight.Text);
            postAnimal.Despription = TBDescription.Text;
            postAnimal.Breed = TBBreed.Text;
            postAnimal.Type = TBType.Text;
            if (postAnimal.IdPet == 0)
            {
                MainWindow.db.Pet.Add(postAnimal);
                MainWindow.db.SaveChanges();
                this.Close();
            }
            else
            {
                MainWindow.db.SaveChanges();
                this.Close();
            }
        }
    }
}
