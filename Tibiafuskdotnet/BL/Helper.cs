using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tibiafuskdotnet.ViewModel;
using System.Collections.ObjectModel;

namespace Tibiafuskdotnet.BL
{
    public static class Helper
    {

        
        public static Int32 SpellLoHealth = 0;
        public static Int32 TempSpellLoHealth = 0;
        public static string SpellLotext = "";
        public static string TempSpellLotext = "";
        public static string UhRunetext = "";
        public static string HpPotiontext = "";
        public static string ManaPotiontext = "";
        public static string TempUhRunetext = "";
        public static string TempHpPotiontext = "";
        public static string TempManaPotiontext = "";
        public static Int32 UhRuneHealth = 0;
        public static Int32 HpPotionHealth = 0;
        public static Int32 TempUhRuneHealth = 0;
        public static Int32 TempHpPotionHealth = 0;
        public static Int32 SpellHiHealth = 0;
        public static Int32 TempSpellHiHealth = 0;
        public static Int32 SpellHiMana = 0;
        public static Int32 TargetingHpMin = 0;
        public static Int32 TargetingHpMax = 0;
        
        public static Int32 SpellLoMana = 0;
        public static Int32 ManapotionHealth = 0;
        public static Int32 TempSpellLoMana = 0;
        public static Int32 TempManaPotion = 0;
        public static Int32 TempSpellHiMana = 0;
        public static string SpellHitext = "";
        public static string TempSpellHitext = "";

        /// <summary>
        /// new targettings save things
        /// </summary>

        

       // ListTargeting = Targeting.

        public static void Initialize()
        {



            AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

            //db.Database.EnsureCreated();

            if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.GetData("DataDirectory") + "\\TibiaCheat\\"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.GetData("DataDirectory") + "\\TibiaCheat\\");
            if (!File.Exists(AppDomain.CurrentDomain.GetData("DataDirectory") + "//TibiaCheat//Cheat.txt"))
            {
                var f = File.Create(AppDomain.CurrentDomain.GetData("DataDirectory") + "//TibiaCheat//Cheat.txt");
                f.Close();
                //WriteToFile();
            }

        }
        public static string GetPath()
        {

                var path=AppDomain.CurrentDomain.GetData("DataDirectory") + "\\TibiaCheat\\Cheat.txt";
            return path;


        }
        public static void WriteToFile()
        {
            
            Cheat cheat = new Cheat() { HpPotionHealth = HpPotionHealth, UhRuneHealth = UhRuneHealth, SpellLoHealth = SpellLoHealth, SpellHiHealth = SpellHiHealth, SpellHiMana = SpellHiMana, SpellLoMana = SpellLoMana, SpellHitext = SpellHitext, SpellLotext = SpellLotext, UhRunetext = UhRunetext, HpPotiontext = HpPotiontext, ManaPotiontext = ManaPotiontext };
            using (StreamWriter r = new StreamWriter(GetPath()))
            {
                var path = JsonConvert.SerializeObject(cheat);
                r.WriteLine(path);
                r.Close();
            }
        }
        public static void WriteTargetingToFile()
        {

            StreamWriter sw = new StreamWriter("fil.txt");
            sw.WriteLine(TargetMenuViewModel.publictarget);
            sw.Close();
        }

        public static Cheat ReadFromFile()
        {
            try
            {

            using (StreamReader r = new StreamReader(GetPath()))
            {
                var a = r.ReadLine();
                if (a != null)
                {
                    return JsonConvert.DeserializeObject<Cheat>(a);
                }
                r.Close();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
            return new Cheat();

        }
        public static List<string> GetKeys()
        {
            return new List<string>() {"F1","F2","F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12" };
        }
     

       

       
        
        }
}

