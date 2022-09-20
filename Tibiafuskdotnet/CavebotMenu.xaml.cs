using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Tibia.Addresses;
using Tibiafuskdotnet.MVVM.ViewModel;
using Tibiafuskdotnet;



namespace Tibiafuskdotnet
{
    /// <summary>
    /// Interaction logic for CavebotMenu.xaml
    /// </summary>
    public partial class CavebotMenu : Window
    {

        //public ObservableCollection<Waypoints> DataSource { get; set; }

        public CavebotMenu()
        {
            InitializeComponent();



            Waypoints.DataSource = new ObservableCollection<Waypoints>();



            //WaypointsHelpers
           // DataSource.Add(new Waypoints { waypointx = MemoryReader.WaypointsTestX, waypointy = MemoryReader.WaypointsTestY, waypointz = MemoryReader.WaypointsTestZ });
            Waypoints.DataSource.Add(new Waypoints { waypointx = MemoryReader.WaypointsTestX, waypointy = MemoryReader.WaypointsTestY, waypointz = MemoryReader.WaypointsTestZ });
            /* List<Waypoints> Waypoints = new List<Waypoints>();
             var Waypointsa = new List<Waypoints>();

              for (int i = 0; i < 10; ++i)
              {
                  /// add this part bellow to "stand/walk in cavebot waypoint
                  Waypointsa.Add(new Waypoints { waypointx = MemoryReader.WaypointsTestX , waypointy = MemoryReader.WaypointsTestY, waypointz = MemoryReader.WaypointsTestZ });

                  //System.Console.WriteLine(" X " + MemoryReader.WaypointsTestX + " y " + MemoryReader.WaypointsTestY + " Z " + MemoryReader.WaypointsTestZ);

              }*/
            // CavebotWaypointsList.ItemsSource = MVVM.ViewModel.Waypoints.DataSource;

            foreach (Waypoints cl in Waypoints.DataSource)
            {
                Console.WriteLine(cl.waypointx);

                    int waypointx = cl.waypointx;
                    int waypointy = cl.waypointy;
                    int waypointz = cl.waypointz;
                //or print the property of your class

                
            }
            

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
