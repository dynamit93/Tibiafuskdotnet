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
        public Waypoints(Location location)
         {
             waypointx = location.X;
             waypointy = location.Y;
             waypointz = location.Z;
            NotifyPropertyChanged();

            System.Console.WriteLine(waypointz + "waypointz 1");
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
                        System.Console.WriteLine(selectedwaypoints);
                        if(selectedwaypoints == MemoryReader.c.PlayerLocation.X + MemoryReader.c.PlayerLocation.Y + MemoryReader.c.PlayerLocation.Z)
                        {
                           
                            Location location = new Location();
                            location.X = waypointx;
                            location.Y = waypointy;
                            location.Z = waypointz;
                            
                        }

                        if(MemoryReader.c.PlayerLocation.X > waypointx)
                        {
                            MemoryReader.c.Player.Walk(Tibia.Constants.Direction.Left);

                        }
                        else if(MemoryReader.c.PlayerLocation.X < waypointx)
                        
                        {
                            MemoryReader.c.Player.Walk(Tibia.Constants.Direction.Right);
                        }
                        else if (MemoryReader.c.PlayerLocation.Y > waypointy)
                        {
                            MemoryReader.c.Player.Walk(Tibia.Constants.Direction.Up);

                        }
                        else if (MemoryReader.c.PlayerLocation.Y < waypointy)
                        {
                            MemoryReader.c.Player.Walk(Tibia.Constants.Direction.Down);
                        }

                        

                        foreach (var item in DataSource)
                        {
                           
                          int x = item.waypointx;
                          int y = item.waypointy;
                          int z = item.waypointz;
                            
                           

                            if (x == MemoryReader.c.PlayerLocation.X && y == MemoryReader.c.playerLocation.Y && z == MemoryReader.c.playerLocation.Z)                                
                            break;
                            System.Console.WriteLine(x + " "+ y + " "+ z);

                            
                        }
                        
                        //Tibia.Addresses.Player.GoToX
                    }


                    catch (Exception)
                    {

                    }
                    break;
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

        private IEnumerable<int> GetCollection()
        {
            throw new NotImplementedException();
        }
    }

 }

 

    


