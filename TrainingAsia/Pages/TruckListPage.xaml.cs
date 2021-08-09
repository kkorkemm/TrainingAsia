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

namespace TrainingAsia.Pages
{
    using Base;

    /// <summary>
    /// Логика взаимодействия для TruckListPage.xaml
    /// </summary>
    public partial class TruckListPage : Page
    {
        public TruckListPage()
        {
            InitializeComponent();
            TruckList.ItemsSource = AppData.GetContext().Truck.ToList();
        }
    }
}
