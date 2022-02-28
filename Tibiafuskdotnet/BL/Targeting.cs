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



        public int Count { get; set; }

        public bool CountMore { get; set; }

        public int MinHp { get; set; }

        public int MaxHp { get; set; }

        public int MonsterAttackMode { get; set; }

        public int DangerLevel { get; set; }

        public string StanceMode { get; set; }

        public string ActionMode { get; set; }

        public int ActionModeSpell { get; set; }

        public string AttackMode { get; set; }
        public int Ring { get; set; }

        public bool Alarm { get; set; }

        public bool Loot { get; set; }


        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged("Name"); }
        }


    }





}
