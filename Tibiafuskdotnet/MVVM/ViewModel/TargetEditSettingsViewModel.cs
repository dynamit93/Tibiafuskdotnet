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

        

        public static string path = "D:/test/data1.txt";
        public static string text = System.IO.File.ReadAllText(path);

        public static string[] rad = text.Split(new string[] { Environment.NewLine },StringSplitOptions.None);



        string Name = getString(rad[1]);
        string Count = getString(rad[2]);
        bool LootMonster = getBool(rad[3]);
        bool PlayAlarm = getBool(rad[4]);

        int Setting = Int32.Parse(getString(rad[6]));
        int Hpmin = Int32.Parse(getString(rad[7]));
        int Hpmax = Int32.Parse(getString(rad[8]));
        string MonsterAttacks = getString(rad[9]);
        int Danger = Int32.Parse(getString(rad[10]));
        string Stance = getString(rad[11]);
        string ActionAttack = getString(rad[12]);
        string ActionSpell = getString(rad[13]);
        string AttackMode = getString(rad[14]);
        string Ring = getString(rad[15]);

        int ListOrder = Int32.Parse(getString(rad[18]));
        int Health = Int32.Parse(getString(rad[19]));
        int Proximity = Int32.Parse(getString(rad[20]));
        int TargetDanger = Int32.Parse(getString(rad[21]));
        int Random = Int32.Parse(getString(rad[22]));
        int Stick = Int32.Parse(getString(rad[23]));
        bool TargetReachable = getBool(rad[24]);
        bool TargetShootable = getBool(rad[25]);

        int RangeDistance = Int32.Parse(getString(rad[28]));
        int AttackFrequency = Int32.Parse(getString(rad[29]));
        int IgnoreMonsters = Int32.Parse(getString(rad[30]));
        bool SyncSpell = getBool(rad[31]);
        bool AllowDiagonal = getBool(rad[32]);



        static string getString(string str)
        {
            return str.Substring(str.IndexOf(": ") + 2);
        }

        static bool getBool(string str)
        {
            string bool_string = getString(str);
            if (bool_string == "yes")
            {
                return true;
            }

            return false;
        }

        private string _firstargument;
        public string Firstargument
        {

            get { return _firstargument; }
            set
            {
                this._firstargument = text;
                this.RaisePropertyChanged("Firstargument");

            }
        }
        
        public TargetEditSettingsViewModel()
        {
            
            _firstargument = text;
            
        }


    }

}
