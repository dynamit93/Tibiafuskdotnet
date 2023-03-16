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

            client = MemoryReader.c;
            Tibia.Version.SetVersion860();

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
        public Thread _WalkToWaypoint;
        public RelayCommand<string> Cavebotcommand { get; set; }



        public Waypoints(Location location)
         {



            waypointx = location.X;
             waypointy = location.Y;
             waypointz = location.Z;
            NotifyPropertyChanged();

            System.Console.WriteLine(waypointz + "waypointz 1");

            //_thread = new Thread(Followwaypoints);
            Thread t = new Thread(() =>
            {
                Followwaypoints(DataSource);
            });




            SelectedCavebotTools = AvailableTools[0];

            
        }

        private static ObservableCollection<Waypoints> _DataSource = new ObservableCollection<Waypoints>();

        public ObservableCollection<Waypoints> DataSource
        {
            get { return _DataSource; }
            set
            {
                if (_DataSource != value)
                {
                    // remove old items
                    foreach (var item in _DataSource)
                    {
                        if (!value.Contains(item))
                        {
                            _DataSource.Remove(item);
                        }
                    }

                    // add new items
                    foreach (var item in value)
                    {
                        if (!_DataSource.Contains(item))
                        {
                            _DataSource.Add(item);
                        }
                    }

                    NotifyPropertyChanged();
                }
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

        public int currentIndex = 0;
        public Location location1;
        public Location GetLocation()
        {

            // RÄTT VÄRDEN KOMMER IN
            //int currentIndex = 0;
            Waypoints waypoint = DataSource[currentIndex];
            return new Location(waypoint.waypointx, waypoint.waypointy, waypoint.waypointz);
        }


        public void Followwaypoints(ObservableCollection<Waypoints> DataSource)
        {
            // Keep track of the current waypoint index
           // int currentIndex = 0;

            while (true)
            {
                if (DataSource != null && DataSource.Any())
                {
                    foreach (Waypoints waypoint in DataSource)
                    {
                        // Get the current player location
                        Location playerLocation = MemoryReader.c.PlayerLocation;

                      //  System.Console.WriteLine(waypoint.waypointx + " "+ waypoint.waypointy);
                        // Get the location of the current waypoint

                        // RÄTT VÄRD¤EN KOMMER INTE IN
                        Location waypointLocation = GetLocation();
                        System.Console.WriteLine(waypointLocation);
                        // Check if the player is at the desired location
                        if (playerLocation == waypointLocation)
                        {
                            // If the player is at the desired location, move to the next waypoint
                            currentIndex++;

                            // If the current index is the last element in the DataSource collection, start over from the beginning
                            if (currentIndex >= DataSource.Count)
                            {
                                currentIndex = 0;
                            }
                        }
                        else
                        {
                            // If the player is not at the desired location, walk to the current waypoint
                            WalkToWaypoint(waypointLocation);
                        }
                    }
                }
            }
        }




        // AStarPathFinder pathFinder = new AStarPathFinder(MemoryReader.c);

        AStarPathFinder pathFindera = new AStarPathFinder(MemoryReader.c);
        private Client client;
        private Creature Creature;


        private static Location AdjustLocation(Location loc, int xDiff, int yDiff)
        {
            int xNew = loc.X - xDiff;
            int yNew = loc.Y - yDiff;

            if (xNew > 17)
                xNew -= 18;
            else if (xNew < 0)
                xNew += 18;

            if (yNew > 13)
                yNew -= 14;
            else if (yNew < 0)
                yNew += 14;

            return new Location(xNew, yNew, loc.Z);
        }

        public void WalkToWaypoint(Location waypointLocation)
        {
           
            Player p = client.GetPlayer();
            p.GoTo = waypointLocation;


        }
        /*
        public bool WalkToWaypoint(Location waypointLocation)
            {
            Creature = MemoryReader.C;
            client = MemoryReader.c;



            var tileList = client.Map.GetTilesOnSameFloor();
                var playerTile = tileList.GetTileWithPlayer(client);
            /// if (playerTile == null || Creature == null)
            //     return false;
            //
              var creatureTile = tileList.GetTileWithCreature(MemoryReader.C.Id);

                 //if (playerTile == null || creatureTile == null)
                 //    return false;

            int xDiff, yDiff;
                uint playerZ = client.Player.Z;
         
            var creatures = client.BattleList.GetCreatures().Where(c => c.Z == playerZ);
                uint playerId = client.Player.Id;

                xDiff = (int)playerTile.MemoryLocation.X - 8;
                yDiff = (int)playerTile.MemoryLocation.Y - 6;

                playerTile.MemoryLocation = AdjustLocation(playerTile.MemoryLocation, xDiff, yDiff);
            // creatureTile.MemoryLocation = AdjustLocation(creatureTile.MemoryLocation, xDiff, yDiff);
            waypointLocation_new = AdjustLocation(waypointLocation, xDiff, yDiff);
            foreach (Tile tile in tileList)
                {
                    tile.MemoryLocation = AdjustLocation(tile.MemoryLocation, xDiff, yDiff);
                


                    if (tile.Ground.GetFlag(Tibia.Addresses.DatItem.Flag.Blocking) || tile.Ground.GetFlag(Tibia.Addresses.DatItem.Flag.BlocksPath) ||
                        tile.Items.Any(i => i.GetFlag(Tibia.Addresses.DatItem.Flag.Blocking) || i.GetFlag(Tibia.Addresses.DatItem.Flag.BlocksPath) || client.PathFinder.ModifiedItems.ContainsKey(i.Id)) 
                        //||// creatures.Any(c => tile.Objects.Any(o => o.Data == c.Id && o.Data != playerId && o.Data != Creature.Id))
                        )
                    {
                        client.PathFinder.Grid[tile.MemoryLocation.X, tile.MemoryLocation.Y] = 0;
                    }
                    else
                    {
                        client.PathFinder.Grid[tile.MemoryLocation.X, tile.MemoryLocation.Y] = 1;
                    }
                }
            System.Console.WriteLine("MemoryReader.c.playerLocation:" + MemoryReader.c.PlayerLocation);
            System.Console.WriteLine("waypointLocation:" + waypointLocation);


            return client.PathFinder.FindPath(MemoryReader.c.PlayerLocation, waypointLocation_new);

            }


        

 */


        private IEnumerable<int> GetCollection()
        {
            throw new NotImplementedException();
        }
    }

 }

 

    


