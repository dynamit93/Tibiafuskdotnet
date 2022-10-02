using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibiafuskdotnet.MVVM.ViewModel
{
    internal class PvpMenuViewModel: ViewModelBase
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

    }
}
