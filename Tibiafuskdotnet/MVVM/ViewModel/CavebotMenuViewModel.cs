using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Squalr.Engine.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Tibia.Constants;
using Tibia.Objects;
using Tibia.Util;
using Tibiafuskdotnet;
using Tibiafuskdotnet.BL;
using static Tibia.Constants.Items;
using System.Collections.Specialized;




namespace Tibiafuskdotnet.MVVM.ViewModel
{




    public class Waypoints : ObservableCollection<Waypoints>
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        

        //SelectedTarget
        private CaveBotLootList _selectedLoot;

        public CaveBotLootList SelectedLoot
        {
            get
            {
                return _selectedLoot;
            }
            set { _selectedLoot = value; NotifyPropertyChanged("SelectedLoot"); }
        }


        private Item _selectedCavebotTools = Tool.Shovel;
        public Item SelectedCavebotTools
        {
            get
            {
                return _selectedCavebotTools;
            }
            set
            {
                _selectedCavebotTools = value;
                NotifyPropertyChanged("SelectedCavebotTools");
            }
        }


        private Item _selectedCavebotRopes = Tool.Rope;
        public Item SelectedCavebotRopes
        {
            get
            {
                return _selectedCavebotRopes;
            }
            set
            {
                _selectedCavebotRopes = value;
                NotifyPropertyChanged("SelectedCavebotRopes");
            }
        }
        //SelectedTools
        // public uint SelectedCavebotTools { get; set;}

        // public uint SelectedCavebotRopes { get; set;}

        private ObservableCollection<Item> _availableTools;
        public ObservableCollection<Item> AvailableTools
        {
            get
            {
                return _availableTools;
            }
            set
            {
                _availableTools = value;
                NotifyPropertyChanged("AvailableTools");
            }
        }

        private ObservableCollection<Item> _availableRioes;
        public ObservableCollection<Item> AvailableRopes
        {
            get
            {
                return _availableRioes;
            }
            set
            {
                _availableRioes = value;
                NotifyPropertyChanged("AvailableRopes");
            }
        }
 

        //listTargeting
        private ObservableCollection<string> _listLoot;

        public ObservableCollection<string> ListLoot
        {
            get { return _listLoot; }
            set { _listLoot = value; NotifyPropertyChanged("ListLoot"); }
        }

        //Targets
        private static ObservableCollection<CaveBotLootList> _Loots;

        public ObservableCollection<CaveBotLootList> Loots
        {
            get { return _Loots; }
            set { _Loots = value; NotifyPropertyChanged("Loots"); }
        }

        //Targeting Method
        // Targeting Class = CaveBotLootList Class
        public static CaveBotLootList AddNewLoot()
        {
            return new CaveBotLootList() { Ids = 0,Lootbackpacks = "",Desciption ="<New Entry>" };
        }

        


        [PreferredConstructorAttribute]
        public Waypoints()
        {
                ListLoot = new ObservableCollection<string>() { "<New Entry>" };
                Loots = new ObservableCollection<CaveBotLootList>() { AddNewLoot() };
                Cavebotcommand = new RelayCommand<string>(PerformFollowWaypoints);


                // Initialize AvailableTools with the list of tools
                AvailableTools = new ObservableCollection<Item>
            {
                 Tool.LightShovel,
                 Tool.Pick,
                 Tool.Shovel,
                 Tool.SneakyStabberofEliteness,
                 Tool.SqueezingGearOfGirlpower,
                 Tool.WhackingDrillerofFate
             
            };


                // Initialize AvailableTools with the list of tools
                AvailableRopes = new ObservableCollection<Item>
            {
                 Tool.ElvenhairRope,
                 Tool.Rope,
                 Tool.SneakyStabberofEliteness,
                 Tool.SqueezingGearOfGirlpower,
                 Tool.WhackingDrillerofFate

            };

            this.CollectionChanged += Waypoints_CollectionChanged;
            // Initialize the map
            Map map = new Map(MemoryReader.c);
            



        }

        private void Waypoints_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public Thread _thread;
        public Thread _Soundplayer;
        public RelayCommand<string> Cavebotcommand { get; set; }



        public Waypoints(Location location)
         {



            waypointx = location.X;
             waypointy = location.Y;
             waypointz = location.Z;
            NotifyPropertyChanged();

            System.Console.WriteLine(waypointz + "waypointz 1");

            _thread = new Thread(Followwaypoints);

            SelectedCavebotTools = AvailableTools[0];


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




        
        private int _Selectedwaypoints;
        public int Selectedwaypoints 
        { 
            get { return _Selectedwaypoints;}
            set { _Selectedwaypoints = value; NotifyPropertyChanged("Selectedwaypoints"); }  
        }


        

        public string actions { get; set; }
        public int waypointx { get; set; }
        public int waypointy { get; set; }

        public int waypointz { get; set; }
        public TextBox txtLootDescrption { get; set; }
        
        bool followWaypoints = false;
        private void PerformFollowWaypoints(string obj)
        {


            switch (obj)
            {
               
                case "SelectedTargetscript":

                    break;

                case "Delete":
                    if (SelectedLoot != null)
                    {
                        if (SelectedLoot.Desciption != "<New Entry>")
                            Loots.Remove(SelectedLoot);
                    }
                    break;

                case "ListBoxSelectionChanged":
                    break;
                case "ListDescriptionTextBoxGotFocus":
                    if (SelectedLoot == null)
                        return;

                    if (SelectedLoot.Desciption.Equals("<New Entry>"))
                    {
                        if (Loots.Count > 1)
                        {

                            if (Loots[Loots.Count - 2].Desciption == "")
                            {
                                SelectedLoot = Loots[Loots.Count - 2];
                                txtLootDescrption.Focus();
                                return;
                            }
                        }
                        SelectedLoot.Desciption = "";
                        NotifyPropertyChanged("SelectedLoot");
                        Loots.Add(AddNewLoot());
                    }
                    break;
                default:
                    break;
            }
        }
        private SoundPlayer soundPlayer = new SoundPlayer();

       

        public void Playsound()
        {
            if (MemoryReader.C.Name != null)
            { MemoryReader.C.Look(); }
            
            //soundPlayer.SoundLocation = @"./sounds/playeronscreen.wav";
            //soundPlayer.PlayLooping();

        }
        public Location GetLocation()
        {
            return new Location(this.waypointx, this.waypointy, this.waypointz);
        }


        public void Followwaypoints()
{
    // Keep track of the current waypoint index
    int currentIndex = 0;

            Waypoints waypoint = DataSource[currentIndex];
            Location waypointLocation = waypoint.GetLocation();


            while (true)
    {
        // Get the current player location
        Location playerLocation = MemoryReader.c.PlayerLocation;

        // Get the current waypoint
       // Waypoints waypoint = DataSource[currentIndex];

        // Check if the player is at the desired location
        if (playerLocation == waypointLocation)
        {
            // If the player is at the desired location, move to the next waypoint
            currentIndex++;

            // If the current index is the last element in the DataSource collection, start over from the beginning
            if (currentIndex == DataSource.Count)
            {
                currentIndex = 0;
            }
        }
        else
        {
            // If the player is not at the desired location, walk to the current waypoint
            WalkToWaypoint(waypoint);
        }
        System.Console.WriteLine(waypointLocation);
    }
}



        // AStarPathFinder pathFinder = new AStarPathFinder(MemoryReader.c);

        AStarPathFinder pathFindera = new AStarPathFinder(MemoryReader.c);


        private void WalkToWaypoint(Waypoints waypoint)
        {
            Location waypointLocation = waypoint.GetLocation();

            Vector3 end = new Vector3(waypointx, waypointy, waypointz);
            // Get the player's current location
            int currentX = MemoryReader.c.PlayerLocation.X;
            int currentY = MemoryReader.c.PlayerLocation.Y;
            int currentZ = MemoryReader.c.PlayerLocation.Z;

            AStarPathFinder pathFinder = new AStarPathFinder(MemoryReader.c);

            // Find the path to the waypoint
            //List<Waypoints> path = pathFinder.FindPath(MemoryReader.c.playerLocation, waypointLocation);


            List<Waypoints> path = AStarPathFinder.FindPath(MemoryReader.c.playerLocation, waypointLocation);
            // Get the direction from the player's current location to the waypoint
            var direction = pathFinder.FindPath(MemoryReader.c.PlayerLocation, waypointLocation);

            System.Console.WriteLine(direction);
            // Walk the player in the direction
            MemoryReader.c.Player.Walk(Direction.Left);
        }

     


        private async Task MoveToWaypoints(List<Waypoints> waypoints)
        {
            foreach (var w in waypoints)
            {
                WalkToWaypoint(w);
                //await Task.Delay(w.Delay);
            }
        }


        private IEnumerable<int> GetCollection()
        {
            throw new NotImplementedException();
        }
    }

 }

 

    


