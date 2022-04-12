using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Tibiafuskdotnet.BL;
using Tibiafuskdotnet.ViewModel;

namespace Tibiafuskdotnet.MVVM.ViewModel
{

    public class TargetEditSettingsViewModel : ViewModelBase
    {

        private string _Targetsetting;

        public string Targetsetting
        {
            get { return _Targetsetting; }
            set { _Targetsetting = value; RaisePropertyChanged("Targetsetting"); }
        }

        private string _firstargument;
        public string Firstargument
        {

            get { return _firstargument; }
            set
            {
                this._firstargument = value;
                this.RaisePropertyChanged("Firstargument");

            }
        }
        
        private string _secondargument;
        public string secondargument
        {
            get { return _secondargument; }
            set
            {
                this._secondargument = value;
                this.RaisePropertyChanged("secondargument");

            }
        }

        
        public TargetEditSettingsViewModel()
        {
            
            _firstargument = "_firstargumentbbbbbbbbbbbbbbb";
            _secondargument = "secondargument";
        }


    }

}
