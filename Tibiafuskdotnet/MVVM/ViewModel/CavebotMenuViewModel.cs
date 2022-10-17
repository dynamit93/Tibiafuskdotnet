using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Tibia.Addresses;
using Tibia.Objects;
using Tibiafuskdotnet;
using Tibiafuskdotnet.BL;
using static System.Net.Mime.MediaTypeNames;


namespace Tibiafuskdotnet.MVVM.ViewModel
{


    public  class Waypoints : ObservableCollection<Waypoints>
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





        //Waypoints aaa = new Waypoints();
        [PreferredConstructorAttribute]
        public Waypoints()
        {
            Cavebotcommand = new RelayCommand<string>(PerformFollowWaypoints);

        }
        public RelayCommand<string> Cavebotcommand { get; set; }
        public Waypoints(Location location)
         {
             waypointx = location.X;
             waypointy = location.Y;
             waypointz = location.Z;
            NotifyPropertyChanged();

            
        }
        
        private static ObservableCollection<Waypoints> _DataSource = new ObservableCollection<Waypoints>();
        
        public ObservableCollection<Waypoints> DataSource
        {
            get { return _DataSource; }
            set
            {
                
               _DataSource = value;
                NotifyPropertyChanged(); 
            }
        }

        private bool _FollowWaypoints;

        public bool FollowWaypoints
        {
            get { return _FollowWaypoints; }
            set { _FollowWaypoints = value; NotifyPropertyChanged("FollowWaypoints"); }
        }




        // public static ObservableCollection<Waypoints> DataSource { get; set; }


        public int waypointx { get; set; }
        public int waypointy { get; set; }

        public int waypointz { get; set; }
        

        private void PerformFollowWaypoints(string obj)
        {

            switch (obj)
            {
                case "FollowWaypointsUnChecked":
                    System.Console.WriteLine("FollowWaypointsUnChecked");
                   

                    break;
                case "FollowWaypointsAlarmChecked":
                    try
                    {
                        
                        foreach (var item in DataSource)
                        {

                          int x = item.waypointx;
                          int y = item.waypointy;
                          int z = item.waypointz;

                            
                            
                            System.Console.WriteLine(x + " "+ y + " "+ z);
                        }
                        
                        //Tibia.Addresses.Player.GoToX
                    }
                    catch (Exception)
                    {

                    }
                    break;

            }
        }



            }

        }

 

    


