using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tibiafuskdotnet.MVVM.ViewModel;



namespace Tibiafuskdotnet.MVVM.Views
{
    /// <summary>
    /// Interaction logic for NavigationMenu.xaml
    /// </summary>
    public partial class NavigationMenu : Window
    {

        



        public NavigationMenu()
        {
            InitializeComponent();

            string text = Cleintportfail.Text;
            int naviPort = Convert.ToInt32(text);
            string naviip = Clientip.Text; 
        }
        

        NavigationMenuViewModel host = new NavigationMenuViewModel { Clientip = "127.0.0.1", Clientport = 1302 };
        Waypoints waypoints = new Waypoints();
        
        
        NavigationMenuViewModel NavigationMenuViewModel = new NavigationMenuViewModel();


        //NavigationMenuViewModel host = new NavigationMenuViewModel();
        // NavigationMenuViewModel NavigationMenuViewModel = new NavigationMenuViewModel();
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            NavigationMenuViewModel.navilogin();
        
        }
    }
}
