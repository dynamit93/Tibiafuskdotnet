using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tibiafuskdotnet.BL
{
    public partial class Targeting : INotifyPropertyChanged
    
    {
        public int Count { get; set; }

        public bool CountMore { get; set; }

        public int MinHp { get; set; }

        public int MaxHp { get; set; }

        public int MonsterAttackMode { get; set; }

        public int DangerLevel { get; set; }

        public int StanceMode { get; set; }

        public int ActionMode { get; set; }

        public int ActionModeSpell { get; set; }

        public int AttackMode { get; set; }
        public int Ring { get; set; }

        public bool Alarm { get; set; }

        public bool Loot { get; set; }

        public string Name { get; set; }
        public override string ToString()
        {
            return this.Name;

        }

        public int MyProperty { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }





}
