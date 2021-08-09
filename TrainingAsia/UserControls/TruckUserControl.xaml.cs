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

namespace TrainingAsia.UserControls
{
    /// <summary>
    /// Логика взаимодействия для TruckUserControl.xaml
    /// </summary>
    public partial class TruckUserControl : UserControl
    {
        public ImageSource Image { get; set; }
        public string Title { get; set; }

        public TruckUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
