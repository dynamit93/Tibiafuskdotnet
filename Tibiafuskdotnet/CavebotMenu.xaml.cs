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
using System.ComponentModel;

namespace Tibiafuskdotnet
{
    /// <summary>
    /// Interaction logic for CavebotMenu.xaml
    /// </summary>
    public partial class CavebotMenu : Window
    {

        //public ObservableCollection<Waypoints> DataSource { get; set; }
        // private ObservableCollection<Waypoints> DataSource;


       /* public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/




        private static ObservableCollection<Waypoints> _DataSource;

        public ObservableCollection<Waypoints> DataSource
        {
            get { return _DataSource; }
            set
            {
                _DataSource = value;
                //NotifyPropertyChanged();
            }
        }



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

                DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X - 1, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});

            }
            else if (CavebotEmplacement.SelectedValue == "East")
            {
                // MemoryReader.c.PlayerLocation.X = +1;
                DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X +1 , waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});


            }
            else if (CavebotEmplacement.SelectedValue == "North")
            {
                // MemoryReader.c.PlayerLocation.Y -1;
                DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});


            }
            else if (CavebotEmplacement.SelectedValue == "Centre")
            {
                // MemoryReader.c.PlayerLocation.Y -1;
                DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});


            }
            else if (CavebotEmplacement.SelectedValue == "Centre")
            {
                // MemoryReader.c.PlayerLocation.Y -1;
                DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});


            }
            else if (CavebotEmplacement.SelectedValue == "Centre")
            {

                DataSource.Add(new Waypoints { waypointx = MemoryReader.c.PlayerLocation.X, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z /*c.PlayerLocation */});

                Console.WriteLine(CavebotEmplacement.SelectedItem);

            }
            else if (CavebotEmplacement.SelectedItem == null)
            {
                
                DataSource.Add(new Waypoints{waypointx = MemoryReader.c.PlayerLocation.X, waypointy = MemoryReader.c.PlayerLocation.Y, waypointz = MemoryReader.c.PlayerLocation.Z});
                


            }
            
            //System.Console.WriteLine(MemoryReader.c.PlayerLocation.X + MemoryReader.c.PlayerLocation.Y + MemoryReader.c.PlayerLocation.Y);
            Console.WriteLine(CavebotEmplacement.SelectedItem);

            System.Console.WriteLine("Print OUTPUT of CavebotWaypointsList " + CavebotWaypointsList);
            Console.Write("PRINT OUT Waypoints.DataSource " + DataSource/*[0]*/);
            Console.WriteLine(MemoryReader.c.PlayerLocation);
        }


    }
}
