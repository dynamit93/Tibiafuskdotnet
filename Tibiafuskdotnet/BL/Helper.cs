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
        public static string ConvertStringToHex(String input, System.Text.Encoding encoding)
        {
            Byte[] stringBytes = encoding.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }

       

         public static string ConvertHexToString(String hexInput, System.Text.Encoding encoding)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
        }
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
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess,
               bool bInheritHandle, int dwProcessId);

       

       
        
        }
}

