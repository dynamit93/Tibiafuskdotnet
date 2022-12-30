using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Tibia.Addresses;
using Tibia.Objects;
using Tibiafuskdotnet.MVVM.ViewModel;


namespace Tibiafuskdotnet
{
    /// <summary>
    /// Interaction logic for CavebotMenu.xaml
    /// </summary>
    public partial class CavebotMenu : Window
    {



        


        public CavebotMenu()
        {
            InitializeComponent();



            //DataSource = new ObservableCollection<Waypoints>();





            /*foreach (Waypoints cl in DataSource)
            {
               // Console.WriteLine(cl.waypointx);

                    int waypointx = cl.waypointx;
                    int waypointy = cl.waypointy;
                    int waypointz = cl.waypointz;
                //or print the property of your class

                
            }*/
            
            System.Console.WriteLine("  MemoryReader.c.PlayerLocation " + MemoryReader.c.PlayerLocation);



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


        Waypoints WaypointsViewmodel = new Waypoints();
        
        private void CavebotWaypointWalk_Click(object sender, RoutedEventArgs e)
        {
            String CavebotEmplacements = CavebotEmplacement.Text;

            //if (CavebotEmplacement.SelectedItem == "West")
            if (CavebotEmplacements == "West")
            {

                //WaypointsViewmodel.DataSource.Add(new Waypoints (MemoryReader.c.PlayerLocation));
                
                WaypointsViewmodel.DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X -1, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});
                System.Console.WriteLine("  MemoryReader.c.PlayerLocation " + MemoryReader.c.PlayerLocation);


            }
            else if (CavebotEmplacements == "East")
            {
                // MemoryReader.c.PlayerLocation.X = +1;
                WaypointsViewmodel.DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X +1 , waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});


            }
            else if (CavebotEmplacements == "North")
            {
                // MemoryReader.c.PlayerLocation.Y -1;
                WaypointsViewmodel.DataSource.Add(new Waypoints {actions = "w", waypointx = MemoryReader.c.PlayerLocation.X, waypointy = MemoryReader.c.PlayerLocation.Y -1, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});


            }
            else if (CavebotEmplacements == "Center")
            {
                // MemoryReader.c.PlayerLocation.Y -1;
                WaypointsViewmodel.DataSource.Add(new Waypoints {actions = "w", waypointx = MemoryReader.c.PlayerLocation.X, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});


            }
            else if (CavebotEmplacements == "South")
            {
                // MemoryReader.c.PlayerLocation.Y -1;
                WaypointsViewmodel.DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X, waypointy = MemoryReader.c.PlayerLocation.Y +1, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});


            }
            else if (CavebotEmplacements == "North-East")
            {

                WaypointsViewmodel.DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X + 1, waypointy = MemoryReader.c.PlayerLocation.Y - 1, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});

                System.Console.WriteLine(CavebotEmplacement.SelectedItem);

            }
            else if (CavebotEmplacements == "North-West")
            {

                WaypointsViewmodel.DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X-1, waypointy = MemoryReader.c.PlayerLocation.Y - 1, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});

                System.Console.WriteLine(CavebotEmplacement.SelectedItem);

            }
            else if (CavebotEmplacements == "South-East")
            {

                WaypointsViewmodel.DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X +1, waypointy = MemoryReader.c.PlayerLocation.Y + 1, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});

                System.Console.WriteLine(CavebotEmplacement.SelectedItem);

            }
            else if (CavebotEmplacements == "South-West")
            {

                WaypointsViewmodel.DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X - 1, waypointy = MemoryReader.c.PlayerLocation.Y + 1, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});

                System.Console.WriteLine(CavebotEmplacement.SelectedItem);

            }
            else if (CavebotEmplacements == null)
            {

                WaypointsViewmodel.DataSource.Add(new Waypoints{waypointx = MemoryReader.c.PlayerLocation.X, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z});
                


            }
            
            //System.Console.WriteLine(MemoryReader.c.PlayerLocation.X + MemoryReader.c.PlayerLocation.Y + MemoryReader.c.PlayerLocation.Y);
            //Console.WriteLine(CavebotEmplacement.SelectedItem);

           // System.Console.WriteLine("Print OUTPUT of CavebotWaypointsList " + CavebotWaypointsList);
           // Console.WriteLine("asdsadasdasd " + MemoryReader.c.PlayerLocation);
        }
                
        

        private void CavebotWaypointShowLable_Checked(object sender, RoutedEventArgs e)
        {

        }


        private void LootDiscriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LootDiscriptionTextBox.Text == "<New Entry>")
            {
                LootDiscriptionTextBox.Text = "";
            }
        }
        Waypoints waypoints = new Waypoints();
        private void CavebotWaypointDel_Click(object sender, RoutedEventArgs e)
        {
            if (CavebotWaypointsList.SelectedIndex >= 0)
            {
                waypoints.DataSource.RemoveAt(CavebotWaypointsList.SelectedIndex);
                
            }
        }






        



        private void CavebotWaypointFollowWaypoints_Checked(object sender, RoutedEventArgs e)
        {
            waypoints._thread = new Thread(new ThreadStart(waypoints.Followwaypoints));

            if (CavebotWaypointFollowWaypoints.IsChecked == true)
            {
                waypoints._thread.Start();
            }
            else if (waypoints._thread != null)
            {
                waypoints._thread.Abort();
            }
        }

        private void CavebotWaypointFollowWaypoints_UnChecked(object sender, RoutedEventArgs e)
        {
            waypoints._thread.Abort();
        }

        private void CavebotWaypointClear_Click(object sender, RoutedEventArgs e)
        {
            waypoints.DataSource.Clear();
        }

        private void CavebotOptionShovel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                        
        }

        private void CavebotWaypointShovel_Click(object sender, RoutedEventArgs e)
        {
            WaypointsViewmodel.DataSource.Add(new Waypoints { actions = "Shovel", waypointx = MemoryReader.c.PlayerLocation.X, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z });

        }



        /* private void CavebotWaypointFollowWaypoints_Checked(object sender, RoutedEventArgs e, Location waypoints)
         {
             // Waypoints aaa = new Waypoints();
             Tibia.Objects.Player p = client.GetPlayer();
             p.GoTo = waypoints;
         }*/
    }
}
