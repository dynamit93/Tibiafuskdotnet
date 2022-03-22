using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Interaction logic for TargetMenu.xaml
    /// </summary>
    public partial class TargetMenu : Window
    {
        public TargetMenu()
        {
            InitializeComponent();
        }

        private void ReachableCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void Reachable_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void TargetNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TargetNameTextBox.Text=="<New Monster>")
            {
                TargetNameTextBox.Text = "";
            }
        }


        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
           
          
        }

        private void playAlram_Unchecked(object sender, RoutedEventArgs e)
        {
           // Player.Stop();
        }

        private void TargetingHpMin_TextChanged(object sender, TextChangedEventArgs e)
        {
            int.TryParse(TargetingHpMin.Text, out Helper.TargetingHpMax);

        }

        private void TargetingHpMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            int.TryParse(TargetingHpMax.Text, out Helper.TargetingHpMax);
        }

        private void StanceMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ActionMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CommonServiceLocator.ServiceLocator.Current.GetInstance<TargetMenuViewModel>().txtTargetName=this.TargetNameTextBox;
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
