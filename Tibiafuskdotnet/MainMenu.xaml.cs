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

namespace Tibiafuskdotnet
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();





        }

        private void Healing_btn_Click(object sender, RoutedEventArgs e)
        {
            HealingMenu Healingkey = new HealingMenu();
            Healingkey.Show();
        }

        private void Extras_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Extras_btn_Click_1(object sender, RoutedEventArgs e)
        {
            ExtrasMenu Extraskey = new ExtrasMenu();
            Extraskey.Show();
        }
    }
}
