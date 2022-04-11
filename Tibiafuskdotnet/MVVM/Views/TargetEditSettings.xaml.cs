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
using Tibiafuskdotnet.BL;
using Tibiafuskdotnet.ViewModel;

namespace Tibiafuskdotnet.MVVM.Views
{
    /// <summary>
    /// Interaction logic for TargetEditSettings.xaml
    /// </summary>
    public partial class TargetEditSettings : Window
    {
        public TargetEditSettings()
        {
            InitializeComponent();
            this .DataContext = this;
        }

        private void MultiBinding_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MultiBinding_DpiChanged(object sender, DpiChangedEventArgs e)
        {

        }
    }
}
