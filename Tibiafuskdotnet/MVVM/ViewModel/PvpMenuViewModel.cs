using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Objects;

namespace Tibiafuskdotnet.MVVM.ViewModel
{
    public class PvpMenuViewModel: ViewModelBase
    {


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
            set { _maxHp = value; RaisePropertyChanged("MaxHp"); }
        }

        public PvpMenuViewModel()
        {


        }
        
        
        public void HealParalyze()
        {
            
            if (Tibiafuskdotnet.MemoryReader.c.Player.HasFlag(Tibia.Constants.Flag.Paralyzed))
            {
                MemoryReader.c.Console.Say("utani gran hur");
            }


        }




    }
}
