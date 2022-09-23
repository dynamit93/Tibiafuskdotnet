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
<<<<<<< HEAD




            //Waypoints.DataSource.Add(new Waypoints { waypointx = MemoryReader.WaypointsTestX, waypointy = MemoryReader.WaypointsTestY, waypointz = MemoryReader.WaypointsTestZ });
            
            
            
=======
            Waypoints.DataSource.Add(new Waypoints { waypointx = MemoryReader.WaypointsTestX, waypointy = MemoryReader.WaypointsTestY, waypointz = MemoryReader.WaypointsTestZ });
>>>>>>> 0051ea06a971cfa5091227dc481de76e7315c407
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
<<<<<<< HEAD
               // Console.WriteLine(cl.waypointx);
=======
                Console.WriteLine(cl.waypointx);
>>>>>>> 0051ea06a971cfa5091227dc481de76e7315c407

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
        
        private void CavebotWaypointWalk_Click(object sender, RoutedEventArgs e)
        {
            if (CavebotEmplacement.SelectedValue == "West")
            {

                Waypoints.DataSource.Add(new Waypoints { waypointx = -1, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});

            }
            else if (CavebotEmplacement.SelectedValue == "East")
            {
                // MemoryReader.c.PlayerLocation.X = +1;
                Waypoints.DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});


            }
            else if (CavebotEmplacement.SelectedValue == "North")
            {
                // MemoryReader.c.PlayerLocation.Y -1;
                Waypoints.DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});


            }
            else if (CavebotEmplacement.SelectedValue == "Centre")
            {

                Waypoints.DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});


            }
            else if (CavebotEmplacement.SelectedValue == "Centre")
            {

                Waypoints.DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});


            }
            else if (CavebotEmplacement.SelectedValue == "Centre")
            {

                Waypoints.DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});

                Console.WriteLine(CavebotEmplacement.SelectedItem);

            }
            else if (CavebotEmplacement.SelectedItem == null)
            {
                Waypoints.DataSource.Add(new Waypoints{waypointx = MemoryReader.c.PlayerLocation.X, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z});


            }

            //System.Console.WriteLine(MemoryReader.c.PlayerLocation.X + MemoryReader.c.PlayerLocation.Y + MemoryReader.c.PlayerLocation.Y);
            Console.WriteLine(CavebotEmplacement.SelectedItem);

            //System.Console.WriteLine(MemoryReader.c.PlayerLocation);
            System.Console.WriteLine("Print OUTPUT of CavebotWaypointsList " + CavebotWaypointsList);
            Console.Write("PRINT OUT Waypoints.DataSource " + Waypoints.DataSource);
        }
    }
}
