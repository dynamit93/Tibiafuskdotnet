using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Tibia.Addresses;
<<<<<<< HEAD
using Tibia.Objects;
=======
>>>>>>> 0051ea06a971cfa5091227dc481de76e7315c407
using Tibiafuskdotnet;
using Tibiafuskdotnet.BL;

namespace Tibiafuskdotnet.MVVM.ViewModel
{


<<<<<<< HEAD
    public  class Waypoints : ObservableCollection<Waypoints>
    {

        public Waypoints()
        {

        }/*
        public Waypoints(Location location)
        {
            waypointx = location.X;
            waypointy = location.Y;
            waypointz = location.Z;
        }*/
=======
    public  class Waypoints : ViewModelBase
    {

>>>>>>> 0051ea06a971cfa5091227dc481de76e7315c407

        private static ObservableCollection<Waypoints> _DataSource;
        
        public static ObservableCollection<Waypoints> DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value;}
        }
       // public static ObservableCollection<Waypoints> DataSource { get; set; }


        public int waypointx { get; set; }
        public int waypointy { get; set; }

        public int waypointz { get; set; }
        

    }
        
    }
 

    


