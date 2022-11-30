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
using Tibiafuskdotnet.MVVM.ViewModel;

namespace Tibiafuskdotnet.MVVM.Views
{
    /// <summary>
    /// Interaction logic for PvpMenu.xaml
    /// </summary>
    public partial class PvpMenu : Window
    {
        public PvpMenu()
        {
            InitializeComponent();
        }
        PvpMenuViewModel PvpMenuViewModel = new PvpMenuViewModel();

        private void HealParalyze_Checked(object sender, RoutedEventArgs e)
        {

            PvpMenuViewModel.HealParalyze();
            
        }
    }
}
