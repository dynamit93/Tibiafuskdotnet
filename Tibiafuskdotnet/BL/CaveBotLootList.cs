using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tibiafuskdotnet.BL
{
    public partial class CaveBotLootList : ViewModelBase
    {


        private string _lootbackpacks;

        public string Lootbackpacks
        {
            get { return _lootbackpacks; }
            set { _lootbackpacks = value; RaisePropertyChanged("Lootbackpacks"); }
        }
        private int _ids;

        public int Ids
        {
            get { return _ids; }
            set { _ids = value; RaisePropertyChanged("Ids"); }
        }


        private string _description;

        public string Desciption
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("Desciption"); }
        }
    }
}
