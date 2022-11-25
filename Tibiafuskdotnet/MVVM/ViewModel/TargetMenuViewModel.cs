using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Windows.Controls;
using Tibia.Constants;
using Tibia.Objects;
using Tibia.Util;
using Tibiafuskdotnet.BL;
using System.IO;
using System.Collections.Generic;
using Squalr.Engine.Utils.Extensions;
using System.Threading;
using Tibia;

namespace Tibiafuskdotnet.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class TargetMenuViewModel : ViewModelBase
    {
        #region Properties
        private ObservableCollection<string> _listActions;

        public ObservableCollection<string> ListActions
        {
            get { return _listActions; }
            set { _listActions = value; RaisePropertyChanged("ListActions"); }
        }
        private string _selectedAction;

        public string SelectedAction
        {
            get { return _selectedAction; }
            set { _selectedAction = value; RaisePropertyChanged("SelectedAction"); }
        }

        private ObservableCollection<int> _Counts;

        public ObservableCollection<int> Counts
        {
            get { return _Counts; }
            set { _Counts = value; RaisePropertyChanged("Counts"); }
        }
        private ObservableCollection<string> _monsterAttacks;

        public ObservableCollection<string> MonsterAttacks
        {
            get { return _monsterAttacks; }
            set { _monsterAttacks = value; RaisePropertyChanged("MonsterAttacks"); }
        }


        private ObservableCollection<int> _dangerLevels;

        public ObservableCollection<int> DangerLevels
        {
            get { return _dangerLevels; }
            set { _dangerLevels = value; RaisePropertyChanged("DangerLevels"); }
        }

        private ObservableCollection<string> _listStanceMode;

        public ObservableCollection<string> ListStanceMode
        {
            get { return _listStanceMode; }
            set { _listStanceMode = value; }
        }

        private ObservableCollection<string> _attackMode;

        public ObservableCollection<string> AttackModes
        {
            get { return _attackMode; }
            set { _attackMode = value; }
        }




        private string _selectedStanceMode;

        public string SelectedStanceMode
        {
            get { return _selectedStanceMode; }
            set { _selectedStanceMode = value; RaisePropertyChanged("SelectedStanceMode"); }
        }

        private int _selectedCounts;

        public int SelectedCounts
        {
            get { return _selectedCounts; }
            set { _selectedCounts = value; RaisePropertyChanged("SelectedCounts"); }
        }




        private string _selectedattackmode;

        public string SelectedAttackMode
        {
            get { return _selectedattackmode; }
            set { _selectedattackmode = value; RaisePropertyChanged("SelectedAttackMode"); }
        }


        private int _SelecteddangerLevels;

        public int SelectedDangerLevels
        {
            get { return _SelecteddangerLevels; }
            set { _SelecteddangerLevels = value; RaisePropertyChanged("SelectedDangerLevels"); }
        }



        private int _DangerTarget;

        public int DangerTarget
        {
            get { return _DangerTarget; }
            set { _DangerTarget = value; RaisePropertyChanged("DangerTarget"); }
        }



        private int _ListOrder;

        public int ListOrder
        {
            get { return _ListOrder; }
            set { _ListOrder = value; RaisePropertyChanged("ListOrder"); }
        }


        private int _HealthTarget;

        public int HealthTarget
        {
            get { return _HealthTarget; }
            set { _HealthTarget = value; RaisePropertyChanged("HealthTarget"); }
        }



        private int _ProximityTarget;

        public int ProximityTarget
        {
            get { return _ProximityTarget; }
            set { _ProximityTarget = value; RaisePropertyChanged("ProximityTarget"); }
        }

        private int _RandomTarget;

        public int RandomTarget
        {
            get { return _RandomTarget; }
            set { _RandomTarget = value; RaisePropertyChanged("RandomTarget"); }
        }

        private int _StickTarget;
        public int StickTarget
        {
            get { return _StickTarget; }
            set { _StickTarget = value; RaisePropertyChanged("StickTarget"); }
        }

        


        private string _selectedactionmode;

        public string SelectedActionMode
        {
            get { return _selectedactionmode; }
            set { _selectedactionmode = value; RaisePropertyChanged("SelectedActionMode"); }
        }




        private ObservableCollection<string> _setting;

        public ObservableCollection<string> Settings
        {
            get { return _setting; }
            set { _setting = value; RaisePropertyChanged("Settings"); }
        }

        private ObservableCollection<string> _actionModes;

        public ObservableCollection<string> ActionModes
        {
            get { return _actionModes; }
            set { _actionModes = value; RaisePropertyChanged("ActionModes"); }
        }

        private ObservableCollection<string> _actionModesspells;

        public ObservableCollection<string> ActionModesSpells
        {
            get { return _actionModesspells; }
            set { _actionModesspells = value; RaisePropertyChanged("ActionModesSpells"); }
        }




        private ObservableCollection<string> _ring;

        public ObservableCollection<string> Ring
        {
            get { return _ring; }
            set { _ring = value; RaisePropertyChanged("Ring"); }
        }



        private ObservableCollection<string> _listTargeting;

        public ObservableCollection<string> ListTargeting
        {
            get { return _listTargeting; }
            set { _listTargeting = value; RaisePropertyChanged("ListTargeting"); }
        }




        public string Selectedtargetscript { get; set; }
                   

        private Targeting _selectedTarget;

        public Targeting SelectedTarget
        {
            get
            {
                return _selectedTarget;
            }
            set { _selectedTarget = value; RaisePropertyChanged("SelectedTarget"); }
        }
        private Targeting _selectedListBoxTarget;

        public Targeting SelectedListBoxTarget
        {
            get { return _selectedListBoxTarget; }
            set { _selectedListBoxTarget = value; RaisePropertyChanged("SelectedListBoxTarget"); }
        }


        private static ObservableCollection<Targeting> _targets;

        public ObservableCollection<Targeting> Targets
        {
            get { return _targets; }
            set { _targets = value; RaisePropertyChanged("Targets"); }
        }




        public static uint targetnow = MemoryReader.playerHelper.RedSquare;

        public RelayCommand<string> command { get; set; }
        #endregion
        #region Methods
        public static Targeting AddNewMonster()
        {
            return new Targeting() { Name = "<New Monster>" };
        }

        public static void AddToList(Targeting targeting)
        {
            _targets.Add(targeting);
        }
        public bool istargeting;
        #endregion
         public static Object publictarget = "";
        public TargetMenuViewModel()
        {
            ListActions = new ObservableCollection<string>() { "No Movement", "Melee - Strike", "Melee - Parry", "Dist - Away", "Melee - Reach", "Melee - ParryReach", "Melee - Approach", "Melee - Circle", "Melee - ReachCircle", "Melee - ReachStrike", "Dist - Wait", "Lose Target", "Lure Target", "Dist - Straigt", "Dist - Lure", "Dist - WaitStraight", "Dist - WaitLure" };
            ListStanceMode = new ObservableCollection<string>() { "Do Nothing", "Attack", "Follow" };
            ListTargeting = new ObservableCollection<string>() { "<New Monseter>" };
            Counts = new ObservableCollection<int>() { 1 ,2,3,4,5,6 };
            Settings = new ObservableCollection<string>() { "1", "2", "3", "4" };
            MonsterAttacks = new ObservableCollection<string>() { "Don't avoid", "Avoid wave", "Avoid beam" };
            DangerLevels = new ObservableCollection<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            AttackModes = new ObservableCollection<string>() { "No Change", "Stand/Offensive", "Stand/Balanced", "Stand/Defensive", "Chase/Offensive", "Chase/Balanced", "Chase/Defensive" };
            ActionModesSpells = new ObservableCollection<string>() {""};
            Ring = new ObservableCollection<string>() { "No change", "Axe ring", "Club ring", "Power ring", "Sword ring", "Energy ring", "Time ring", "Life ring", "Healing ring", "Stealth ring", "Dwarf ring", "Might ring" };

            if (targetnow == 0)
            {
                istargeting = false;
            }
            else
            {
                istargeting = true;
            }


            Targets = new ObservableCollection<Targeting>() { AddNewMonster() };
            Player = new SoundPlayer();
            
            foreach (var target in Targets)
            {
                publictarget = target;
            }

            SelectedActionMode = ListStanceMode[0];

            SelectedDangerLevels = DangerLevels[0];
            SelectedCounts = Counts[0];
            SelectedStanceMode = ListActions[0];
            SelectedActionMode = ActionModesSpells[0];
            SelectedAttackMode = AttackModes[0];
            SelectedStanceMode = Ring[0];
            command = new RelayCommand<string>(PerformAction);

        }
        public TextBox txtTargetName { get; set; }
        private SoundPlayer Player = new SoundPlayer();


        private void PerformAction(string obj)
        {
           
            switch (obj)
            {
                case "AlarmUnChecked":
                    if (Targets.Where(x => x.Alarm == true).FirstOrDefault() == null)
                        Player.Stop();
                    break;
                case "AlarmChecked":
                    try
                    {
                        Player.SoundLocation = @"./sounds/monster.wav";
                        Player.PlayLooping();
                    }
                    catch (Exception)
                    {

                    }
                    break;
                case "RunTarget":
                     // by tråad nedan
                    StartTargetThred();
                    //  StartTarget();
                    break;

                /* case "ReachableChecked":
                     if (SelectedTarget.Name == Targets) 
                     { 

                     }
                     break;
                */
                case "SelectedTargetscript":
                    
                break;

                case "Delete":
                    if (SelectedTarget != null)
                    {
                        if (SelectedTarget.Name != "<New Monster>")
                            Targets.Remove(SelectedTarget);
                    }
                    break;

                case "ListBoxSelectionChanged":
                    break;
                case "TargetNameTextBoxGotFocus":
                    if (SelectedTarget == null)
                        return;

                    if (SelectedTarget.Name.Equals("<New Monster>"))
                    {
                        if (Targets.Count > 1)
                        {

                            if (Targets[Targets.Count - 2].Name == "")
                            {
                                SelectedTarget = Targets[Targets.Count - 2];
                                txtTargetName.Focus();
                                return;
                            }
                        }
                        SelectedTarget.Name = "";
                        RaisePropertyChanged("SelectedTarget");
                        Targets.Add(AddNewMonster());
                    }
                    break;
                default:
                    break;
            }
        }
        int TargetHPBar;




        //  Thread thr = new Thread(TargetMenuViewModel);
        //Thread a = new Thread(TargetMenuViewModel.StartTarget);
        //  thr.StartTarget();


        private void StartTargetThred()
        {
            Thread thr = new Thread(StartTarget);
            thr.Start();
            System.Console.WriteLine("thread toString " + thr.ToString());
        }


        private void StartTarget()
        {   
            foreach (var item in Targets)
            {
                //targetting Monster Count
                var count = MemoryReader.battleList.GetCreatures().Aggregate(0, (total, c) => {
                    return c.Name == item.Name ? total + 1 : total;
                });

                // if (SelectedTarget.DangerLevel <= ) { }

                //chceking if monster on screen is == then count monster in tragetting
                //System.Console.WriteLine(count);

                

                // if (SelectedCounts <= count) { }
                /* while (MemoryReader.battleList.GetCreatures().Count() > 0 && istargeting == false)
                  {*/


                int lowest = 101;
                    uint currentIdToAttack = 0;
                    Creature C = null;
                    
                    IEnumerable<Creature> lowestTest = MemoryReader.battleList.GetCreatures();
                    lowestTest.ForEach(fest2 =>
                    {
                        if (fest2.HPBar < lowest)
                        {
                            lowest = fest2.HPBar;
                            currentIdToAttack = fest2.Id;
                            C = fest2;
                        }
                    });

                int counter = 0;
                C.Attack();


                while (C.HPBar > 0 && C.IsReachable())
                {
                    System.Console.WriteLine("\nWe are still waiting");
                    System.Console.WriteLine(counter);
                    counter++;
                } 
                 return;
                
              
                /*foreach (Creature C in MemoryReader.battleList.GetCreatures())
                    {*/

                        TargetHPBar = C.HPBar;
                        System.Console.WriteLine(C.Id);

                        if (item.Name == C.Name)
                        {
                            

                            if (SelectedTarget.ActionMode == "Attack")
                            {
                                System.Console.WriteLine("IF ATTACK");
                                int a = C.HPBar;
                                Math.Sin(C.HPBar);
                                int b = C.HPBar;
                                if (a != b)
                                {
                                    System.Console.WriteLine("HPAR DIFFAR");
                                }

                                System.Console.WriteLine(TargetHPBar + "\n2: " + Helper.TargetingHpMin + "\n3: " + Helper.TargetingHpMax);
                                if (TargetHPBar >= Helper.TargetingHpMin && TargetHPBar <= Helper.TargetingHpMax){
                                    // var ksdfujfs = Math.Min(C.HPBar,C.HPBar);
                                    //  System.Console.WriteLine(ksdfujfs);
                                    System.Console.WriteLine("ATTACK");
                                    C.Attack();
                                    istargeting = true;
                                }

                            }

                            /*else if (SelectedTarget.ActionMode == "Follow")
                            {
                                if (TargetHPBar >= Helper.TargetingHpMin && TargetHPBar <= Helper.TargetingHpMax)

                                {
                                    C.Follow();
                                    // System.Console.WriteLine("Name " + C.Name + " Loaction " + C.Location);
                                }
                            }
                            if (SelectedTarget.StanceMode == "Melee - Approach")
                            {
                                if (TargetHPBar >= Helper.TargetingHpMin && TargetHPBar <= Helper.TargetingHpMax)
                                {
                                    C.Approach();
                                }
                                else { System.Console.WriteLine(SelectedTarget.ActionMode); }
                            }

                            if (SelectedTarget.AttackMode == "Stand/Offensive")
                            {
                                //System.Console.WriteLine("before add value " + MemoryReader.Followmode);
                                MemoryReader.WriteValuesToMemory(MemoryReader.Followmode, BitConverter.GetBytes(0));
                                MemoryReader.WriteValuesToMemory(MemoryReader.Attackmode, BitConverter.GetBytes(1));
                                // System.Console.WriteLine("after add value " + MemoryReader.Followmode);
                            }
                            else if (SelectedTarget.AttackMode == "Stand/Balanced")
                            {
                                MemoryReader.WriteValuesToMemory(MemoryReader.Followmode, BitConverter.GetBytes(0));
                                MemoryReader.WriteValuesToMemory(MemoryReader.Attackmode, BitConverter.GetBytes(2));
                                //MemoryReader.client.AttackMode = Attack.Balance;
                            }
                            else if (SelectedTarget.AttackMode == "Stand/Defensive")
                            {
                                MemoryReader.WriteValuesToMemory(MemoryReader.Followmode, BitConverter.GetBytes(0));
                                MemoryReader.WriteValuesToMemory(MemoryReader.Attackmode, BitConverter.GetBytes(3));
                            }
                            else if (SelectedTarget.AttackMode == "Chase/Offensive")
                            {
                                MemoryReader.WriteValuesToMemory(MemoryReader.Followmode, BitConverter.GetBytes(1));
                                MemoryReader.WriteValuesToMemory(MemoryReader.Attackmode, BitConverter.GetBytes(1));
                            }
                            else if (SelectedTarget.AttackMode == "Chase/Balanced")
                            {
                                MemoryReader.WriteValuesToMemory(MemoryReader.Followmode, BitConverter.GetBytes(1));
                                MemoryReader.WriteValuesToMemory(MemoryReader.Attackmode, BitConverter.GetBytes(2));
                            }
                            else if (SelectedTarget.AttackMode == "Chase/Defensive")
                            {
                                MemoryReader.WriteValuesToMemory(MemoryReader.Followmode, BitConverter.GetBytes(1));
                                MemoryReader.WriteValuesToMemory(MemoryReader.Attackmode, BitConverter.GetBytes(3));
                            }*/
                       }

                        //Dennis gjort
                        /*
                        if (checked(SelectedTarget.Reachable))
                            {


                            if (result)
                            {
                                C.IsReachable();
                                System.Console.WriteLine(C.Name);


                            }
                        }*/

                        //Equip Ring if monster is on screen.
                        foreach (Item MyItems in MemoryReader.inventory.GetItems())
                        {
                            // Item ringRingRingRingBananaPhone;
                            ItemLists.Ring.TryGetValue(MyItems.Id, out Item ringRingRingRingBananaPhone);
                            if (ringRingRingRingBananaPhone == null)
                            {
                                continue;
                            }

                           
                            if (ringRingRingRingBananaPhone.Name.Equals(SelectedTarget.Ring, StringComparison.InvariantCultureIgnoreCase))
                            {
                               
                                
                                
                                MyItems.Move(ItemLocation.FromSlot(SlotNumber.Ring));
                                break;
                            }
                        }


                        /* switch (ActionMode.SelectedItem)
                         {
                             case "Attack": 
                             case int TargetHPBar when (TargetHPBar <= Helper.TargetingHpMin && TargetHPBar >= Helper.TargetingHpMax):
                                 C.Attack();
                                 break;
                             case "Follow":
                                 C.Follow();
                                 break;
                         }*/
                    //}  foreach (Creature C in MemoryReader.battleList.GetCreatures())
               // }
            }
        }
    }
}