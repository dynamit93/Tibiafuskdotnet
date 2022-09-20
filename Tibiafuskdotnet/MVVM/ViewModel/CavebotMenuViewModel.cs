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
using Tibiafuskdotnet;
using Tibiafuskdotnet.BL;

namespace Tibiafuskdotnet.MVVM.ViewModel
{


    public  class Waypoints : ViewModelBase
    {


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
 

    


