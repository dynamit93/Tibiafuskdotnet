using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Tibia.Objects;
using Tibiafuskdotnet.BL;

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

        private ObservableCollection<string> _counts;

	public ObservableCollection<string> Counts
	{
		get { return _counts;}
		set { _counts = value;RaisePropertyChanged("Counts");}
	}
        private ObservableCollection<string> _monsterAttacks;

	public ObservableCollection<string> MonsterAttacks
	{
		get { return _monsterAttacks;}
		set { _monsterAttacks = value;RaisePropertyChanged("MonsterAttacks");}
	}


        private ObservableCollection<int> _dangerLevels;

	public ObservableCollection<int> DangerLevels
	{
		get { return _dangerLevels;}
		set { _dangerLevels = value;RaisePropertyChanged("DangerLevels");}
	}

        private ObservableCollection<string> _listStanceMode;

        public ObservableCollection<string> ListStanceMode
        {
            get { return _listStanceMode; }
            set { _listStanceMode = value; }
        }
        private string _selectedStanceMode;

        public string SelectedStanceMode
        {
            get { return _selectedStanceMode; }
            set { _selectedStanceMode = value; RaisePropertyChanged("SelectedStanceMode"); }
        }
        private ObservableCollection<string> _setting;

	public ObservableCollection<string> Settings
	{
		get { return _setting;}
		set { _setting = value;RaisePropertyChanged("Settings");}
	}

        private ObservableCollection<string> _actionModes;

	public ObservableCollection<string> ActionModes
	{
		get { return _actionModes;}
		set { _actionModes = value;RaisePropertyChanged("ActionModes");}
	}




        private ObservableCollection<string> _listTargeting;

        public ObservableCollection<string> ListTargeting
        {
            get { return _listTargeting; }
            set { _listTargeting = value; RaisePropertyChanged("ListTargeting"); }
        }


        private Targeting _selectedTarget;

        public Targeting SelectedTarget
        {
            get {
                   return _selectedTarget; }
            set { _selectedTarget = value; RaisePropertyChanged("SelectedTarget"); }
        }
        private Targeting _selectedListBoxTarget;

        public Targeting SelectedListBoxTarget
        {
            get { return _selectedListBoxTarget; }
            set { _selectedListBoxTarget = value; RaisePropertyChanged("SelectedListBoxTarget"); }
        }


        private ObservableCollection<Targeting> _targets;

        public ObservableCollection<Targeting> Targets
        {
            get { return _targets; }
            set { _targets = value; RaisePropertyChanged("Targets"); }
        }

        public RelayCommand<string> command{ get; set; }
        #endregion
        #region Methods
        private Targeting AddNewMonster()
        {
            return new Targeting() { Name = "<New Monster>" };
        }
        #endregion
        public TargetMenuViewModel()
        {
            ListActions= new ObservableCollection<string>() { "No Movement","Melee - Strike","Melee - Parry", "Dist - Away","Melee - Reach", "Melee - ParryReach", "Melee - Approach", "Melee - Circle", "Melee - ReachCircle", "Melee - ReachStrike","Dist - Wait", "Lose Target","Lure Target", "Dist - Straigt","Dist - Lure", "Dist - WaitStraight","Dist - WaitLure" };
            ListStanceMode = new ObservableCollection<string>() { "Do Nothing", "Attack", "Follow" };
            ListTargeting = new ObservableCollection<string>() { "<New Monseter>"};
            Counts=new ObservableCollection<string>() { "Any","1","2+","2","3+","3","4+","4","5+","5"};
            Settings=new ObservableCollection<string>(){"1","2","3","4" };
            MonsterAttacks=new ObservableCollection<string>() {  "Don't avoid","Avoid wave","Avoid beam"};
            DangerLevels=new ObservableCollection<int>() { 1,2,3,4,5,6,7,8,9,10};
            ActionModes=new ObservableCollection<string>() { "No Change", "Stand/Offensive","Stand/Balanced","Stand/Defensive","Chase/Offensive","Chase/Balanced","Chase/Defensive","Wear ring", "No change","no ring","Axe ring" ,"Club ring","Power ring", "Sword ring","Energy ring", "Time ring","Life ring", "Healing ring", "Stealth ring", "Dwarf ring", "Might ring"};
            
            Targets = new ObservableCollection<Targeting>() { AddNewMonster() };

      

        SelectedAction = ListActions[0];
            SelectedStanceMode = ListStanceMode[0];
            command = new RelayCommand<string>(PerformAction);
        }
        public TextBox txtTargetName{ get; set; }
        private void PerformAction(string obj)
        {
            switch (obj)
            {
                case "RunTarget":

                    StartTarget();
                    break;

                case "Delete":
                    if (SelectedTarget!=null)
                    {
                        if(SelectedTarget.Name!="<New Monster>")
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

                         if(Targets[Targets.Count - 2].Name == "")
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
        private void StartTarget()
        {
            foreach (var item in Targets)
            {
                foreach (Creature C in MemoryReader.battleList.GetCreatures())
                {
                    TargetHPBar = C.HPBar;
                    if (item.ToString() == C.Name)
                    {
                        System.Console.WriteLine(TargetHPBar);
                        if (SelectedTarget.StanceMode == "Attack")

                        {
                            if (TargetHPBar <= Helper.TargetingHpMin && TargetHPBar >= Helper.TargetingHpMax)
                            {
                                C.Attack();
                            }
                        }
                        else if (SelectedTarget.StanceMode == "Follow")
                        {
                            if (TargetHPBar <= Helper.TargetingHpMin && TargetHPBar >= Helper.TargetingHpMax)

                            {
                                C.Follow();
                            }
                        }
                        if (SelectedTarget.ActionMode == "Melee - Approach")

                        {
                            if (TargetHPBar <= Helper.TargetingHpMin && TargetHPBar >= Helper.TargetingHpMax)
                            {
                                C.Approach();
                            }
                            else { System.Console.WriteLine(SelectedTarget.ActionMode); }
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
                    }
                }
            }
        }
    }
}