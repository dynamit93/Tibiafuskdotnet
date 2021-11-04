using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tibiafuskdotnet.BL
{
    public static class Helper
    {
        public static Int32 SpellHiHealth = 0;
        public static Int32 SpellHiMana = 0;
        public static string SpellHitext = "";
     

       

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
            Cheat cheat = new Cheat() { SpellHiHealth = SpellHiHealth, SpellHiMana = SpellHiMana, SpellHitext = SpellHitext };
            using (StreamWriter r = new StreamWriter(GetPath()))
            {
                var path = JsonConvert.SerializeObject(cheat);
                r.WriteLine(path);
                r.Close();
            }
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

            }
            return new Cheat();

        }
        public static List<string> GetKeys()
        {
            return new List<string>() {"F1","F2","F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12" };
        }
     

       

       
        
        }
}

