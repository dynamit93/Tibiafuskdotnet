using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Squalr.Engine.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using Tibia.Objects;
using Tibia.Util;
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
            
        }
        public RelayCommand<string> Cavebotcommand { get; set; }
        
        public Thread _thread;
        
        public Waypoints(Location location)
         {
             waypointx = location.X;
             waypointy = location.Y;
             waypointz = location.Z;
            NotifyPropertyChanged();

            System.Console.WriteLine(waypointz + "waypointz 1");

            _thread = new Thread(Followwaypoints);
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
        public int selectedwaypoints { get; set; }


        public int waypointx { get; set; }
        public int waypointy { get; set; }

        public int waypointz { get; set; }
        public TextBox txtLootDescrption { get; set; }
        Client client = new Client();
        bool followWaypoints = false;
        private void PerformFollowWaypoints(string obj)
        {


            switch (obj)
            {
               /* case "FollowWaypointsUnChecked":
                    System.Console.WriteLine("FollowWaypointsUnChecked");
                    
                    try
                    {
                        if (followWaypoints == false)
                        {
                            System.Console.WriteLine("FollowWaypointsUnChecked");
                        }
                    }
                    catch (Exception)
                    {

                    }
                    break;
                case "FollowWaypointsAlarmChecked":
                    try
                    {
                        followWaypoints = true;
                        System.Console.WriteLine(selectedwaypoints);
                        /*if(selectedwaypoints == MemoryReader.c.PlayerLocation.X + MemoryReader.c.PlayerLocation.Y + MemoryReader.c.PlayerLocation.Z)
                        {
                           
                            Location location = new Location();
                            location.X = waypointx;
                            location.Y = waypointy;
                            location.Z = waypointz;
                            
                        }*/

                       /* MemoryReader.c.Player.GoToX = waypointx.ToUInt32();
                        MemoryReader.c.Player.GoToY = waypointy.ToUInt32();
                        MemoryReader.c.Player.GoToZ = waypointz.ToUInt32();

                       

                    }


                    catch (Exception)
                    {

                    }
                    break;*/
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




        public void Followwaypoints()
        {
            // Keep track of the current waypoint index
            int currentIndex = 0;

            while (true)
            {
                // Get the current player location
                int playerX = MemoryReader.c.PlayerLocation.X;
                int playerY = MemoryReader.c.PlayerLocation.Y;
                int playerZ = MemoryReader.c.PlayerLocation.Z;

                // Get the current waypoint
                Waypoints waypoint = DataSource[currentIndex];

                // Check if the player is at the desired location
                if (playerX == waypoint.waypointx && playerY == waypoint.waypointy && playerZ == waypoint.waypointz)
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
            }
        }


        private void WalkToWaypoint(Waypoints waypoint)
        {

            // Get the coordinates of the waypoint
            int waypointx = waypoint.waypointx;
            int waypointy = waypoint.waypointy;
            int waypointz = waypoint.waypointz;

            // Get the player's current coordinates
            int currentX = MemoryReader.c.PlayerLocation.X;
            int currentY = MemoryReader.c.PlayerLocation.Y;
            int currentZ = MemoryReader.c.PlayerLocation.Z;

            // Keep looping until the player reaches the waypoint
            while (currentX != waypointx || currentY != waypointy || currentZ != waypointz)
            {
                // Print the player's current location and the desired location
                System.Console.WriteLine("wanna walk to x-cordinate: " + waypointx);
                System.Console.WriteLine("Im currently on x-cordinate: " + MemoryReader.c.PlayerLocation.X);

                // Wait for 500 milliseconds
                Thread.Sleep(500);

                // If the player's x coordinate is greater than the waypoint's x coordinate, walk west
                if (MemoryReader.c.PlayerLocation.X > waypointx)
                {
                    MemoryReader.c.Player.Walk(Tibia.Constants.Direction.Left);
                    
                    System.Console.WriteLine("walk west");

                }
                // If the player's x coordinate is less than the waypoint's x coordinate, walk east
                if (MemoryReader.c.PlayerLocation.X < waypointx)
                {
                    MemoryReader.c.Player.Walk(Tibia.Constants.Direction.Right);
                    System.Console.WriteLine("walk east");
                }
                // If the player's y coordinate is greater than the waypoint's y coordinate, walk north
                if (MemoryReader.c.PlayerLocation.Y > waypointy)
                {
                    MemoryReader.c.Player.Walk(Tibia.Constants.Direction.Up);
                    System.Console.WriteLine("walk north");
                }
                // If the player's y coordinate is less than the waypoint's y coordinate, walk south
                if (MemoryReader.c.PlayerLocation.Y < waypointy)
                {
                    MemoryReader.c.Player.Walk(Tibia.Constants.Direction.Down);
                    System.Console.WriteLine("walk south");
                }

                // Update the player's current coordinates
                currentX = MemoryReader.c.PlayerLocation.X;
                currentY = MemoryReader.c.PlayerLocation.Y;
                currentZ = MemoryReader.c.PlayerLocation.Z;
            }
        }

        

        private IEnumerable<int> GetCollection()
        {
            throw new NotImplementedException();
        }
    }

 }

 

    


