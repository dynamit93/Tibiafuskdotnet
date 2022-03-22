using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;

namespace Tibiafuskdotnet.BL
{



    public partial class Targeting:ViewModelBase
    
    {
        private string _categories;

        public string Categories
        {
            get { return _categories; }
            set { _categories = value;RaisePropertyChanged("Categories"); }
        }
        private string _count;
                
        public string Count
        {
            get { return _count; }
            set { _count = value;RaisePropertyChanged("Count"); }
        }
        private bool _countMore;

        public bool CountMore
        {
            get { return _countMore; }
            set { _countMore = value; RaisePropertyChanged("CountMore"); }
        }
        private int _minHp;

        public int MinHp
        {
            get { return _minHp; }
            set { _minHp = value; RaisePropertyChanged("MinHp"); }
        }
        private int _maxHp;

        public int MaxHp
        {
            get { return _maxHp; }
            set { _maxHp = value;RaisePropertyChanged("MaxHp"); }
        }
        private string _monsterAttackMode;

        public string MonsterAttackMode
        {
            get { return _monsterAttackMode; }
            set { _monsterAttackMode = value;RaisePropertyChanged("MonsterAttackMode"); }
        }
        private int _dangerLevel;

        public int DangerLevel
        {
            get { return _dangerLevel; }
            set { _dangerLevel = value;RaisePropertyChanged("DangerLevel"); }
        }
        private string _stanceMode;

        public string StanceMode
        {
            get { return _stanceMode; }
            set { _stanceMode = value; RaisePropertyChanged("StanceMode"); }
        }
        private string _actionMode;

        public string ActionMode
        {
            get { return _actionMode; }
            set { _actionMode = value; RaisePropertyChanged("ActionMode"); }
        }
        private string _actionModeSpell;

        public string ActionModeSpell
        {
            get { return _actionModeSpell; }
            set { _actionModeSpell = value;RaisePropertyChanged("ActionModeSpell"); }
        }
        private string _attackMode;

        public string AttackMode
        {
            get { return _attackMode; }
            set { _attackMode = value;RaisePropertyChanged("AttackMode"); }
        }
        private string _ring;

        public string Ring
        {
            get { return _ring; }
            set { _ring = value;RaisePropertyChanged("Ring"); }
        }
        private bool _alarm;

        public bool Alarm
        {
            get { return _alarm; }
            set { _alarm = value; RaisePropertyChanged("Alarm"); }
        }

        private bool _Reachable;
        public bool Reachable
        {
            get { return _Reachable; }
            set { _Reachable = value; RaisePropertyChanged("Reachable"); }
        }

        private bool _loot;

        public bool Loot
        {
            get { return _loot; }
            set { _loot = value; RaisePropertyChanged("Loot"); }
        }
        private string _setting;

        public string Setting
        {
            get { return _setting; }
            set { _setting = value; RaisePropertyChanged("Setting"); }
        }


        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged("Name"); }
        }


    }





}
