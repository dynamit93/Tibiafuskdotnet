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
        string hotkeyf2 = "exura gran";
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
            Process[] localByName = Process.GetProcessesByName("Tibia");
            //Process[] ProcessList = Process.GetProcesses();

            foreach (Process p in localByName)
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
            var tibia = Process.GetProcessesByName("Tibia").FirstOrDefault();
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
            Memory.Mem m = new Memory.Mem();
           var res= m.OpenProcess("Tibia");
            var result=m.WriteMemory("base+39A008", "string",Helper.SpellHitext);
            
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
                //if (text == null)
                    //    {
                    //        text = "";
                    //    }
                    //    var spelhitext = Helper.ConvertStringToHex(text, Encoding.UTF8).ToString().Substring(0,8);

                    //    VirtualKeyCode k = new VirtualKeyCode();


                    //    if (spelhitext == strHotkey1)
                    //        k = VirtualKeyCode.F1;

                    //    else if (spelhitext == strHotkey2)
                    //        k = VirtualKeyCode.F2;
                    //    else if (spelhitext == strHotkey3)
                    //        k = VirtualKeyCode.F3;
                    //    else if (spelhitext == strHotkey4)
                    //        k = VirtualKeyCode.F4;
                    //    else if (spelhitext == strHotkey5)
                    //        k = VirtualKeyCode.F5;
                    //    else if (spelhitext == strHotkey6)
                    //        k = VirtualKeyCode.F6;
                    //    else if (spelhitext == strHotkey7)
                    //        k = VirtualKeyCode.F7;
                    //    else if (spelhitext == strHotkey8)
                    //        k = VirtualKeyCode.F8;
                    //    else if (spelhitext == strHotkey9)
                    //        k = VirtualKeyCode.F9;
                    //    else if (spelhitext == strHotkey10)
                    //        k = VirtualKeyCode.F10;
                    //    else if (spelhitext == strHotkey11)
                    //        k = VirtualKeyCode.F11;
                    //    else if (spelhitext == strHotkey12)
                    //        k = VirtualKeyCode.F12;

                    var sim = new InputSimulator();
                sim.Keyboard.KeyDown(VirtualKeyCode.F2);



            }
             
        }
        [DllImport("kernel32.dll")]
        public static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
           [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);
        public byte[] ReadBytes(IntPtr Handle, Int64 Address, uint BytesToRead)
        {
            IntPtr ptrBytesRead;
            byte[] buffer = new byte[BytesToRead];
            ReadProcessMemory(Handle, new IntPtr(Address), buffer, BytesToRead, out ptrBytesRead);
            return buffer;
        }
        //just one sec need to fix movie for my girlfriend done
        private void TimerTick(object sender, EventArgs e)
        {
            readValuesFromMemory();
            
        }


        }

    }

