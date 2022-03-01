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
using Tibia.Util;

namespace Tibiafuskdotnet
{
    /// <summary>
    /// Interaction logic for HudMenu.xaml
    /// </summary>
    public partial class HudMenu : Window
    {
        public HudMenu()
        {
            InitializeComponent();
        }


        private void Magic_Wall_Timer(object sender, RoutedEventArgs e)
        {

            //SpriteReader.GetSpriteImage();



           // SpriteReader.GetSpriteImage(Tibia.Version.CurrentVersionString, 2128);
            
        }
    }
}
