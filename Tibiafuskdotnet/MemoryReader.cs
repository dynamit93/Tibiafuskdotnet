
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Windows;

using System.Windows.Threading;
using Tibiafuskdotnet;
using Tibiafuskdotnet.BL;

using WindowsInput;
using WindowsInput.Native;


namespace Tibiafuskdotnet
{
    public class MemoryReader
    {
        private Timer timer;
        //private MainWindow lb;
    
        private const int PROCESS_WM_READ = 0x0010;

        private Int32 baseAddress;

        public int currentHp;
        public int maxHp;
        public int currentMana;
        public int maxMana;
        private int xor;
        private string chatt;

        private int maxHpValue;
        private int maxManaValue;
        private int manaValue;
        private int hpValue;

       
        private Int32 xorAddr = 0x934658 - 0x400000;
        private Int32 chattAddr = 0x27361B0;


        //character


        //Skills
        private Int32 currentHpAddr = 0x63FE94 - 0x400000;
        private Int32 maxHpAddr = 0x63FE90 - 0x400000;
        private Int32 currentManaAddr = 0x63FE78 - 0x400000;
        private Int32 maxManaAddr = 0x63FE74 - 0x400000;
        public Int32 StaminaAddr = 0x63FE6C;
        public Int32 MagicLevelAddr = 0x63FE84;
        public Int32 LevelAddr = 0x63fe88;
        public Int32 ExpAddr = 0x63FE8C;
        public Int32 CapAddr = 0x63FE68;
        public Int32 SoulAddr = 0x63FE70;


        /// hottkeys
        /// pub
        public Int32 hottkeyf1 = 0x799F08;
        public Int32 hottkeyf2 = 0x79A008;
        public Int32 hottkeyf3 = 0x79A108;
        public Int32 hottkeyf4 = 0x79A208;
        public Int32 hottkeyf5 = 0x79A308;
        public Int32 hottkeyf6 = 0x79A408;
        public Int32 hottkeyf7 = 0x79A508;
        public Int32 hottkeyf8 = 0x79A608;
        public Int32 hottkeyf9 = 0x79A708;
        public Int32 hottkeyf10 = 0x79A808;
        public Int32 hottkeyf11 = 0x79A908;
        public Int32 hottkeyf12 = 0x79AA08;
        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);
        const int VK_F1 = 0x70;
        const int VK_F2 = 0x71;
        const int VK_F3 = 0x72;
        const int VK_F4 = 0x73;
        const int VK_F5 = 0x74;
        const int VK_F6 = 0x75;
        const int VK_F7 = 0x76;
        const int VK_F8 = 0x77;
        const int VK_F9 = 0x78;
        const int VK_F10 = 0x79;
        const int VK_F11 = 0x80;
        const int VK_F12 = 0x81;
        const UInt32 WM_KEYDOWN = 0x0100;



        private double manaPercentInput;
        private double hpPercentLightHealInput;
        private double hpPercentIntenseHealInput;

        

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess,
          int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        public MemoryReader(double manaPercentInput, double hpPercentLightHealInput, double hpPercentIntenseHealInput)
        {
            //this.lb = lb;
            this.manaPercentInput = manaPercentInput;
            this.hpPercentLightHealInput = hpPercentLightHealInput;
            this.hpPercentIntenseHealInput = hpPercentIntenseHealInput;

            timer = new Timer();
            timer.Interval = 300;
            timer.Elapsed += new ElapsedEventHandler(TimerTick);
            timer.Start();
            

            readValuesFromMemory();
        }


        public static bool appRunning(string appName = "Tibia")
        {
            System.Diagnostics.Process[] localByName = System.Diagnostics.Process.GetProcessesByName("Tibia");
            //Process[] ProcessList = Process.GetProcesses();

            foreach (System.Diagnostics.Process p in localByName)
            {
                Console.WriteLine(p.ProcessName);
                if (p.ProcessName.Contains(appName))
                {
                    return true;

                }
                else
                {
                    MessageBox.Show("start tibia");
                    return false;
                }

            }

            return false;
        }



        public void readValuesFromMemory()
        {
            //var tibia = Process.GetProcesses().ToList().Where(x=>x.ProcessName.ToLower().Contains("ti")).ToList();
            var tibia = System.Diagnostics.Process.GetProcessesByName("Tibia").FirstOrDefault();
            baseAddress = tibia.MainModule.BaseAddress.ToInt32();
            IntPtr handle = OpenProcess(PROCESS_WM_READ, false, tibia.Id);

            int bytesRead = 0;
            byte[] buffer = new byte[4];

            ReadProcessMemory((int)handle, xorAddr + baseAddress, buffer, buffer.Length, ref bytesRead);
            xor = BitConverter.ToInt32(buffer, 0);

            ReadProcessMemory((int)handle, currentHpAddr + baseAddress, buffer, buffer.Length, ref bytesRead);
            currentHp = BitConverter.ToInt32(buffer, 0);

            ReadProcessMemory((int)handle, currentManaAddr + baseAddress, buffer, buffer.Length, ref bytesRead);
            currentMana = BitConverter.ToInt32(buffer, 0);

            ReadProcessMemory((int)handle, maxHpAddr + baseAddress, buffer, buffer.Length, ref bytesRead);
            maxHp = BitConverter.ToInt32(buffer, 0);

            ReadProcessMemory((int)handle, maxManaAddr + baseAddress, buffer, buffer.Length, ref bytesRead);
            maxMana = BitConverter.ToInt32(buffer, 0);


            ReadProcessMemory((int)handle, chattAddr, buffer, buffer.Length, ref bytesRead);
            chatt = BitConverter.ToString(buffer, 0);
            ReadProcessMemory((int)handle, chattAddr, buffer, buffer.Length, ref bytesRead);
          //  int * data =(int32*)BitConverter.ToInt32(buffer, 0);



            hpValue = currentHp ^ xor;
            manaValue = currentMana ^ xor;
            maxHpValue = maxHp ^ xor;
            maxManaValue = maxMana ^ xor;
        
            
      
            bool isExhausted = false;
            
            if (((double)(int)manaValue / (int)maxManaValue) < manaPercentInput)
            {

                //keyboardSimulator.useManaPotion();
                isExhausted = true;
            }
            if (((double)(int)hpValue / (int)maxHpValue) < hpPercentIntenseHealInput)
            {
                
                chatt =  "Healing";
                MessageBox.Show("error");
                //keyboardSimulator.useIntenseHeal();
                isExhausted = true;
            }
            if (((double)(int)hpValue / (int)maxHpValue) < hpPercentLightHealInput)
            {
                //keyboardSimulator.useLightHeal();
                isExhausted = true;
            }
            if (isExhausted)
            {
                System.Threading.Thread.Sleep(800);
            }












            if (currentHp <= Helper.SpellHiHealth && currentMana >= Helper.SpellHiMana)
            {
                var text = Helper.SpellHitext;
               
                var spelhitext = Helper.SpellHitext;

                int key = 0;


                if (spelhitext == "F1")
                    key = VK_F1;


                else if (spelhitext == "F2")
                    key = VK_F2;


                else if (spelhitext == "F3")
                    key = VK_F3;


                else if (spelhitext == "F4")
                    key = VK_F4;


                else if (spelhitext == "F5")
                    key = VK_F5;


                else if (spelhitext == "F6")
                    key = VK_F6;


                else if (spelhitext == "F7")
                    key = VK_F7;


                else if (spelhitext == "F8")
                    key = VK_F8;

                else if (spelhitext == "F9")
                    key = VK_F9;


                else if (spelhitext == "F10")
                    key = VK_F10;


                else if (spelhitext == "F11")
                    key = VK_F11;


                else if (spelhitext == "F12")
                    key = VK_F12;

         System.Diagnostics.Process process = System.Diagnostics.Process.GetProcessesByName("Tibia").FirstOrDefault();
                var r = PostMessage(process.MainWindowHandle, WM_KEYDOWN, key, 0);



            }

        }
   
        private void TimerTick(object sender, EventArgs e)
        {
            readValuesFromMemory();
            
        }
       

    }

    }

