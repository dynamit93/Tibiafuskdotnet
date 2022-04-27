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



        static string Loadtaragetscript()
        {
            string path = "D:/test/data.txt";
            string text = System.IO.File.ReadAllText(path);

            string[] rad = text.Split(
            new string[] { Environment.NewLine },
            StringSplitOptions.None);

            string _firstargument = text;

            int antal_monster = CountSubstring(text, "Name");

            string[] Name = new string[antal_monster];
            string[] Count = new string[antal_monster];
            bool[] LootMonster = new bool[antal_monster];
            bool[] PlayAlarm = new bool[antal_monster];

            int[] Setting = new int[antal_monster];
            int[] Hpmin = new int[antal_monster];
            int[] Hpmax = new int[antal_monster];
            string[] MonsterAttacks = new string[antal_monster];
            int[] Danger = new int[antal_monster];
            string[] Stance = new string[antal_monster];
            string[] ActionAttack = new string[antal_monster];
            string[] ActionSpell = new string[antal_monster];
            string[] AttackMode = new string[antal_monster];
            string[] Ring = new string[antal_monster];

            for (int i = 0; i < antal_monster; i++)
            {
                Name[i] = getString(rad[1 + 16 * i]);
                Count[i] = getString(rad[2 + 16 * i]);
                LootMonster[i] = getBool(rad[3 + 16 * i]);
                PlayAlarm[i] = getBool(rad[4 + 16 * i]);

                Setting[i] = Int32.Parse(getString(rad[6 + 16 * i]));
                Hpmin[i] = Int32.Parse(getString(rad[7 + 16 * i]));
                Hpmax[i] = Int32.Parse(getString(rad[8 + 16 * i]));
                MonsterAttacks[i] = getString(rad[9 + 16 * i]);
                Danger[i] = Int32.Parse(getString(rad[10 + 16 * i]));
                Stance[i] = getString(rad[11 + 16 * i]);
                ActionAttack[i] = getString(rad[12 + 16 * i]);
                ActionSpell[i] = getString(rad[13 + 16 * i]);
                AttackMode[i] = getString(rad[14 + 16 * i]);
                Ring[i] = getString(rad[15 + 16 * i]);
            }


            int ListOrder = Int32.Parse(getString(rad[2 + antal_monster * 16]));
            int Health = Int32.Parse(getString(rad[3 + antal_monster * 16]));
            int Proximity = Int32.Parse(getString(rad[4 + antal_monster * 16]));
            int TargetDanger = Int32.Parse(getString(rad[5 + antal_monster * 16]));
            int Random = Int32.Parse(getString(rad[6 + antal_monster * 16]));
            int Stick = Int32.Parse(getString(rad[7 + antal_monster * 16]));
            bool TargetReachable = getBool(rad[8 + antal_monster * 16]);
            bool TargetShootable = getBool(rad[9 + antal_monster * 16]);

            int RangeDistance = Int32.Parse(getString(rad[12 + antal_monster * 16]));
            int AttackFrequency = Int32.Parse(getString(rad[13 + antal_monster * 16]));
            int IgnoreMonsters = Int32.Parse(getString(rad[14 + antal_monster * 16]));
            bool SyncSpell = getBool(rad[15 + antal_monster * 16]);
            bool AllowDiagonal = getBool(rad[16 + antal_monster * 16]);

            return text;
        }

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

        public static int CountSubstring(string text, string value)
        {
            int count = 0;
            int minIndex = text.IndexOf(value, 0);
            while (minIndex != -1)
            {
                minIndex = text.IndexOf(value, minIndex + value.Length);
                count++;
            }
            return count;
        }



        private string _firstargument;
        public string Firstargument
        {

            get { return _firstargument; }
            set
            {
                this._firstargument = Loadtaragetscript();
                this.RaisePropertyChanged("Firstargument");

            }
        }
        
        public TargetEditSettingsViewModel()
        {
            
            _firstargument = Loadtaragetscript();
            
        }


    }

}
