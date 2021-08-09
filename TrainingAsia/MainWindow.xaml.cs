using System;
using System.IO;
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

namespace TrainingAsia
{
    using Base;

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.MenuPage());

            //ImportData();
        }

        /// <summary>
        /// Actions for importing data (imported)
        /// </summary>
        private void ImportData()
        {
            var trucklist = File.ReadAllLines(@"C:\Users\Asus\Desktop\данные для импорта\туры.txt");
            var images = Directory.GetFiles(@"C:\Users\Asus\Desktop\данные для импорта\фото Туры");

            foreach (var truckdata in trucklist)
            {
                var data = truckdata.Split('\t');

                var truck = new Truck()
                {
                    TruckName = data[0].Replace("\"", ""),
                    PositionX = int.Parse(data[2]),
                    PositionY = int.Parse(data[3])
                };

                var types = data[5].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var type in types)
                {
                    var currentType = AppData.GetContext().Type.ToList().FirstOrDefault(p => p.TypeName == type);
                    if (currentType != null)
                    {
                        truck.Type.Add(currentType);
                    }
                }

                try
                {
                    truck.Image = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(truck.TruckName)));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                AppData.GetContext().Truck.Add(truck);

            }

            try
            {
                AppData.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Actions to go back to previous page
        /// </summary>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        /// <summary>
        /// Back button's visibility
        /// </summary>
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }
    }
}
