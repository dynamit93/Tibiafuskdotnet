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
using static Tibia.Constants.Tiles;
using Tibia.Constants;
using Tibia;




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
        AStarPathFinder pathFinder = new AStarPathFinder(map);
        List<Waypoints> path = pathFinder.FindPath(start, end);
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


        //private void WalkToWaypoint(Waypoints waypoint)
        //{
        //    uint tempposx = Convert.ToUInt32(waypoint.waypointx);
        //    uint tempposy = Convert.ToUInt32(waypoint.waypointy);
        //    uint tempposz = Convert.ToUInt32(waypoint.waypointz);





        //        // Get the coordinates of the waypoint
        //        int waypointx = waypoint.waypointx;
        //    int waypointy = waypoint.waypointy;
        //    int waypointz = waypoint.waypointz;

        //    // Get the player's current coordinates
        //    int currentX = MemoryReader.c.PlayerLocation.X;
        //    int currentY = MemoryReader.c.PlayerLocation.Y;
        //    int currentZ = MemoryReader.c.PlayerLocation.Z;

        //    // Keep looping until the player reaches the waypoint
        //    while (currentX != waypointx || currentY != waypointy || currentZ != waypointz)
        //    {
        //        // Print the player's current location and the desired location
        //        System.Console.WriteLine("wanna walk to x-cordinate: " + waypointx);
        //        System.Console.WriteLine("Im currently on x-cordinate: " + MemoryReader.c.PlayerLocation.X);

        //        // Wait for 200 milliseconds
        //        Thread.Sleep(200);
        //        /* if (waypoint.actions == "Shovel")
        //         {
        //             // testing if useing shovel will work on specific location. not done yet.
        //             System.Console.WriteLine("SHOVEL" + SelectedCavebotTools);
        //             System.Console.WriteLine((ushort)waypoint.waypointy);

        //             Location location = new Location(waypoint.waypointx, waypoint.waypointy, waypoint.waypointz);


        //             Tile tile = new Tile(MemoryReader.c, (ushort)waypointx, (ushort)waypointx, client.Player.Z);

        //             MemoryReader.c.Inventory.UseItemOnTile(SelectedCavebotTools, tile);



        //         }*/

        //        if (waypoint.actions == "Shovel")
        //        {

        //            System.Console.WriteLine("SHOVEL" + SelectedCavebotTools);
        //            System.Console.WriteLine((ushort)waypoint.waypointy);

        //            // Create a Location object using the waypoint coordinates
        //            Location location = new Location(waypoint.waypointx, waypoint.waypointy, waypoint.waypointz);
        //            // Create a Tile object using the Location object
        //            Tile tile = new Tile(MemoryReader.c, (ushort)waypoint.waypointx, (ushort)waypoint.waypointy, location);
        //            System.Console.WriteLine("PRINT OUT THE TILE " + tile);
        //            System.Console.WriteLine("PRINTOUT THE location " + location);
        //            //System.Console.WriteLine("PRINT OUT THE SelectedCavebotTools " + SelectedCavebotTools.Id);
        //            // Use the SelectedCavebotTools item on the Tile object
        //            if (SelectedCavebotTools.Name == "Shovel")
        //            {
        //                //MemoryReader.c.Inventory.UseItemOnTile(SelectedCavebotTools.Id, tile);
        //                MemoryReader.c.Inventory.UseItemOnTile(3457, tile);
        //            }
        //            else if(SelectedCavebotTools.Name == "Squeezing Gear Of Girlpower")
        //            {
        //                MemoryReader.c.Inventory.UseItemOnTile(9596, tile);
        //            }    
        //            else if(SelectedCavebotTools.Name == "Whacking Driller of Fate")
        //            {
        //                MemoryReader.c.Inventory.UseItemOnTile(9598, tile);
        //            }
        //            else if(SelectedCavebotTools.Name == "Sneaky Stabber of Eliteness")
        //            {
        //                MemoryReader.c.Inventory.UseItemOnTile(9594, tile);
        //            }
        //            // if i use the id 3457 insted of SelectedCavebotTools its will work. fix the binding so SelectedCavebotTools will return 3457
        //            //MemoryReader.c.Inventory.UseItemOnTile(3457, tile);

        //        }

        //        if (waypoint.actions == "Rope")
        //        {
        //            // testing if useing shovel will work on specific location. not done yet.
        //            Location location = new Location((ushort)waypoint.waypointx, (ushort)waypoint.waypointy, (ushort)waypoint.waypointz);
        //            Tile tile = new Tile(MemoryReader.c, (ushort)waypoint.waypointx, (ushort)waypoint.waypointy, location);
        //            //MemoryReader.c.Inventory.UseItemOnTile(SelectedCavebotRopes, tile);
        //            System.Console.WriteLine("Rope");

        //            if (SelectedCavebotRopes.Name == "Rope")
        //            {
        //                //MemoryReader.c.Inventory.UseItemOnTile(SelectedCavebotRopes, tile);
        //                MemoryReader.c.Inventory.UseItemOnTile(3003, tile);
        //            }


        //        }
        //        //if(waypoint.actions =="w")
        //        //{

        //            // If the player's z coordinate is Equal to the waypoint's z coordinate, Walk
        //            if (MemoryReader.c.PlayerLocation.Z == waypointz)
        //            {




        //        //    // If the player's x coordinate is greater than the waypoint's x coordinate, walk west
        //        //    if (MemoryReader.c.PlayerLocation.X > waypointx)
        //        //{
        //        //    MemoryReader.c.Player.Walk(Tibia.Constants.Direction.Left);

        //        //    System.Console.WriteLine("walk west");

        //        //}
        //        //// If the player's x coordinate is less than the waypoint's x coordinate, walk east
        //        //if (MemoryReader.c.PlayerLocation.X < waypointx)
        //        //{

        //        //    MemoryReader.c.Player.Walk(Tibia.Constants.Direction.Right);
        //        //    System.Console.WriteLine("walk east");
        //        //}


        //        // If the player's y coordinate is greater than the waypoint's y coordinate, walk north
        //        if (MemoryReader.c.PlayerLocation.Y > waypointy)
        //        {

        //                foreach (Tile tile in MemoryReader.c.Map.GetTiles())
        //                {
        //                    if (TileLists.Down.Contains(tile.Ground.Id) && tile.Location.Z == MemoryReader.c.PlayerLocation.Z)
        //                    { 
        //                        // print Ground id + GROUND ID LOACTION
        //                        if (TileLists.Down.Contains(tile.Ground.Id) && tile.Location.Y +1 == MemoryReader.c.PlayerLocation.Y && tile.Location.X == MemoryReader.c.PlayerLocation.X && tile.Location.Z == MemoryReader.c.PlayerLocation.Z)
        //                        {
        //                            System.Console.WriteLine("SIMON " + tile.Location.Y);
        //                            MemoryReader.c.Player.Walk(Tibia.Constants.Direction.Right);
        //                        }
        //                        else if(TileLists.Down.Contains(tile.Ground.Id) && tile.Location.Y + 1 == MemoryReader.c.PlayerLocation.Y && tile.Location.X == MemoryReader.c.PlayerLocation.X -1 && tile.Location.Z == MemoryReader.c.PlayerLocation.Z)
        //                        {

        //                            System.Console.WriteLine("WALK NORTH" + tile.Location.Y);
        //                            MemoryReader.c.Player.Walk(Tibia.Constants.Direction.Up);
        //                        }
        //                        else if(TileLists.Down.Contains(tile.Ground.Id) && tile.Location.Y == MemoryReader.c.PlayerLocation.Y && tile.Location.X == MemoryReader.c.PlayerLocation.X - 1 && tile.Location.Z == MemoryReader.c.PlayerLocation.Z)
        //                        {
        //                            System.Console.WriteLine("WALK NORTH 2" + tile.Location.Y);
        //                            MemoryReader.c.Player.Walk(Tibia.Constants.Direction.Up);
        //                        }
        //                        if (TileLists.Down.Contains(tile.Ground.Id) && tile.Location.Y -1 == MemoryReader.c.PlayerLocation.Y && tile.Location.X +1 == MemoryReader.c.PlayerLocation.X)
        //                        {
        //                            System.Console.WriteLine("WALK LEFT" + tile.Location.Y);
        //                            MemoryReader.c.Player.Walk(Tibia.Constants.Direction.Left);
        //                        }
        //                    }

        //                    /*else if(TileLists.Down.Contains(tile.Ground.Id) &&  tile.Location.Y +1 == MemoryReader.c.PlayerLocation.Y && tile.Location.X == MemoryReader.c.PlayerLocation.X && tile.Location.Z == MemoryReader.c.PlayerLocation.Z)
        //                    {
        //                       // MemoryReader.c.Player.Walk(Tibia.Constants.Direction.Up);
        //                        System.Console.WriteLine("walk north");

        //                    }*/

        //                }


        //            }






        //            // If the player's y coordinate is less than the waypoint's y coordinate, walk south
        //            if (MemoryReader.c.PlayerLocation.Y < waypointy)
        //        {
        //            MemoryReader.c.Player.Walk(Tibia.Constants.Direction.Down);
        //            System.Console.WriteLine("walk south");
        //        }

        //        }
        //        // Update the player's current coordinates
        //        currentX = MemoryReader.c.PlayerLocation.X;
        //        currentY = MemoryReader.c.PlayerLocation.Y;
        //        currentZ = MemoryReader.c.PlayerLocation.Z;
        //        //} //end if(waypoint.actions =="w")
        //    }
        //}

        private void WalkToWaypoint(Waypoints waypoint)
        {
            // Get the player's current location
            int currentX = MemoryReader.c.PlayerLocation.X;
            int currentY = MemoryReader.c.PlayerLocation.Y;
            int currentZ = MemoryReader.c.PlayerLocation.Z;

            // Get the direction from the player's current location to the waypoint
            var direction = Pathfinding.AStar.GetDirection(
                new Vector3(currentX, currentY, currentZ),
                new Vector3(waypointx, waypointy, waypointz));

            // Walk the player in the direction
            MemoryReader.c.Player.Walk(direction);
        }


        private async Task MoveToWaypoints(List<Waypoints> waypoints)
        {
            foreach (var w in waypoints)
            {
                WalkToWaypoint(w);
                await Task.Delay(w.Delay);
            }
        }


        private IEnumerable<int> GetCollection()
        {
            throw new NotImplementedException();
        }
    }

 }

 

    


