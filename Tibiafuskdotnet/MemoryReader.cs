﻿
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
using Tibia;
using Tibia.Objects;
using Tibia.Constants;
using System.Collections.Generic;

namespace Tibiafuskdotnet
{

    public static class MemoryReader
    {
        public static Timer timer;
        //private MainWindow lb;
       
        private const int PROCESS_WM_READ = 0x0010;

        public static Int32 baseAddress;
        public static string Bc1;
        public static int currentHp;
        public static int maxHp;
        public static int currentMana;
        public static int maxMana;
        public static int xor;
        public static string chatt;
        public static int light;

        public static int maxHpValue;
        public static int maxManaValue;
        public static int maxlight;
        public static int BattleListconvert;
        public static int manaValue;
        public static int hpValue;
        public static string bc;
        //character 
        public static string Charactername;

        public static Int32 xorAddr = 0x934658 - 0x400000;
        public static Int32 chattAddr = 0x27361B0;
/*
        public static void SetVersion860()
        {
        //battlelist
            BattleList.Start = 0x63FEF8;
            BattleList.StepCreatures = 0xA8;
            BattleList.MaxCreatures = 250;
            BattleList.End = BattleList.Start + (BattleList.StepCreatures* BattleList.MaxCreatures);

            }*/

        //character
        public static Int32 CharacterNameAddr = 0x63FEFC;

        //Skills
        public static Int32 currentHpAddr = 0x63FE94 - 0x400000;
        public static Int32 maxHpAddr = 0x63FE90 - 0x400000;
        public static Int32 currentManaAddr = 0x63FE78 - 0x400000;
        public static Int32 maxManaAddr = 0x63FE74 - 0x400000;
        public static Int32 StaminaAddr = 0x63FE6C;
        public static Int32 MagicLevelAddr = 0x63FE84;
        public static Int32 LevelAddr = 0x63fe88;
        public static Int32 ExpAddr = 0x63FE8C;
        public static Int32 CapAddr = 0x63FE68;
        public static Int32 SoulAddr = 0x63FE70;


        /// hottkeys
        /// pub
        public static Int32 hottkeyf1 = 0x799F08;
        public static Int32 hottkeyf2 = 0x79A008;
        public static Int32 hottkeyf3 = 0x79A108;
        public static Int32 hottkeyf4 = 0x79A208;
        public static Int32 hottkeyf5 = 0x79A308;
        public static Int32 hottkeyf6 = 0x79A408;
        public static Int32 hottkeyf7 = 0x79A508;
        public static Int32 hottkeyf8 = 0x79A608;
        public static Int32 hottkeyf9 = 0x79A708;
        public static Int32 hottkeyf10 = 0x79A808;
        public static Int32 hottkeyf11 = 0x79A908;
        public static Int32 hottkeyf12 = 0x79AA08;
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
        const int VK_F11 = 0x7A;
        const int VK_F12 = 0x7B;
        const UInt32 WM_KEYDOWN = 0x0100;


        //Utilities
        public static Int32 LightAddr = 0x4EAFAC;



           public static Int32 BattleListStart = 0x63FEF8;
           public static Int32 BattleListStepCreatures = 0xA8;
           public static Int32 BattleListMaxCreatures = 250;
           public static Int32 BatteListEnd = BattleListStart + (BattleListStepCreatures * BattleListMaxCreatures);



        public static double manaPercentInput;
        public static double hpPercentLightHealInput;
        public static double hpPercentIntenseHealInput;
        

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess,
          int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress,
        byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);
       
        

        public static void Start(double _manaPercentInput, double _hpPercentLightHealInput, double _hpPercentIntenseHealInput)
        {
            //this.lb = lb;
            manaPercentInput = _manaPercentInput;
            hpPercentLightHealInput = _hpPercentLightHealInput;
            hpPercentIntenseHealInput = _hpPercentIntenseHealInput;
            

            timer = new Timer();
            timer.Interval = 300;
            timer.Elapsed += new ElapsedEventHandler(TimerTick);
            timer.Start();
           

            ReadValuesFromMemory();
        }

        public static BattleList battleList = null;

        public static Creature creature = null;
        /// <summary>
        /// Dennis gjort
        /// </summary>
        public static Inventory inventory = null;

        public static bool AppRunning(string appName = "Tibia")
        {
            System.Diagnostics.Process[] localByName = System.Diagnostics.Process.GetProcessesByName("Tibia");
            //Process[] ProcessList = Process.GetProcesses();
           
            foreach (System.Diagnostics.Process p in localByName)
            {
                //System.Console.WriteLine(p.ProcessName);
                if (p.ProcessName.Contains(appName))
                {
                    Client c = new Client(p);
                    battleList = new BattleList(c);
                    // dennis gjort
                    inventory = new Inventory(c);


                    Tibia.Version.SetVersion860();
                    foreach (Creature C in battleList.GetCreatures())
                    {
                        System.Console.WriteLine("Creature " + C.Name);
                        
                    }
                    // Dennis gjort Skriver ut alla backpacks finns med id + namn + Vilket nummer backpackn finns
                    foreach (Container MyC in inventory.GetContainers())
                    {
                        
                       // System.Console.WriteLine( MyC.Id +" "+ MyC.Name + " " + MyC.Number );
                    }
                    Item RingItem; 

                    var Ring = ItemLists.Ring.TryGetValue(Items.Ring.TimeRing.Id, out RingItem );
                    // Dennis gjort kollar vilka items som finns på Hela Gubben

                   /* //System.Console.WriteLine(RingItem.Name + " " + RingItem.Id);
                    foreach (Item MyItems in inventory.GetItems())
                    {
                        Item ringRingRingRingBananaPhone;
                        ItemLists.Ring.TryGetValue(MyItems.Id, out ringRingRingRingBananaPhone);
                        if(ringRingRingRingBananaPhone == null)
                        {
                            continue;
                        }

                        // Dennis gjort om id är lika skriver den ut namnet på id.
                        System.Console.WriteLine($"{MyItems.Id} -> {ringRingRingRingBananaPhone.Name}" /*+ MyItems.Move(9)*/ /*);*/
                       /* if (ringRingRingRingBananaPhone.Name == "Time Ring")
                       /* {
                           

                            /* // Funkar inte men behöver använda Items.Move för att flytta items
                            MyItems.Move(SlotNumber.Ring ,1 );
                            */
                     /*   }
                    }*/




                    //System.Console.WriteLine(bc.GetCreatures());
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

        private static Creature[] NewMethod()
        {
            return new Creature[30];
        }

        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;

        public static void WriteValuesToMemory(int address, byte[] buffer)

        {
            var tibia = System.Diagnostics.Process.GetProcessesByName("Tibia").FirstOrDefault();
            baseAddress = tibia.MainModule.BaseAddress.ToInt32();
            IntPtr processHandle = OpenProcess(PROCESS_VM_WRITE | PROCESS_VM_OPERATION, false, tibia.Id);

            int bytesWritten = 0;
            WriteProcessMemory((int)processHandle, address, buffer, buffer.Length, ref bytesWritten);
            System.Console.WriteLine(bytesWritten);
        }


        public static void ReadValuesFromMemory()
        {

            try
            {

            
            //var tibia = Process.GetProcesses().ToList().Where(x=>x.ProcessName.ToLower().Contains("ti")).ToList();
            var tibia = System.Diagnostics.Process.GetProcessesByName("Tibia").FirstOrDefault();
            baseAddress = tibia.MainModule.BaseAddress.ToInt32();
            IntPtr handle = OpenProcess(PROCESS_WM_READ, false, tibia.Id);

            int bytesRead = 0;
            byte[] buffer = new byte[30];
            

            ReadProcessMemory((int)handle, xorAddr + baseAddress, buffer, buffer.Length, ref bytesRead);
            xor = BitConverter.ToInt32(buffer, 0);

            ReadProcessMemory((int)handle, currentHpAddr + baseAddress, buffer, buffer.Length, ref bytesRead);
            currentHp = BitConverter.ToInt32(buffer, 0);

          //  ReadProcessMemory((int)handle, CharacterNameAddr + baseAddress, buffer, buffer.Length, ref bytesRead);
          //  Charactername = BitConverter.ToString(buffer, 0);

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


            ReadProcessMemory((int)handle, LightAddr, buffer, buffer.Length, ref bytesRead);
            light = BitConverter.ToInt32(buffer, 0);

            // ReadProcessMemory((int)handle, BattleListStart, buffer, buffer.Length, ref bytesRead);
           // BattleListconvert = BitConverter.ToInt32(buffer, 0);


            

            hpValue = currentHp ^ xor;
            manaValue = currentMana ^ xor;
            maxHpValue = maxHp ^ xor;
            maxManaValue = maxMana ^ xor;
            maxlight = light;



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
//healbot working


            }


            //SpellLo Heal

            if (currentHp <= Helper.SpellLoHealth && currentMana >= Helper.SpellLoMana)
            {
                var text = Helper.SpellLotext;

                var spellotext = Helper.SpellLotext;

                int key = 0;


                if (spellotext == "F1")
                    key = VK_F1;


                else if (spellotext == "F2")
                    key = VK_F2;


                else if (spellotext == "F3")
                    key = VK_F3;


                else if (spellotext == "F4")
                    key = VK_F4;


                else if (spellotext == "F5")
                    key = VK_F5;


                else if (spellotext == "F6")
                    key = VK_F6;


                else if (spellotext == "F7")
                    key = VK_F7;


                else if (spellotext == "F8")
                    key = VK_F8;

                else if (spellotext == "F9")
                    key = VK_F9;


                else if (spellotext == "F10")
                    key = VK_F10;


                else if (spellotext == "F11")
                    key = VK_F11;


                else if (spellotext == "F12")
                    key = VK_F12;

                System.Diagnostics.Process process = System.Diagnostics.Process.GetProcessesByName("Tibia").FirstOrDefault();
                var r = PostMessage(process.MainWindowHandle, WM_KEYDOWN, key, 0);
                //healbot working


            }
            //UH Rune Heal
            if (currentHp <= Helper.UhRuneHealth)
            {
                var text = Helper.UhRunetext;

                var UhRunetext = Helper.UhRunetext;

                int key = 0;


                if (UhRunetext == "F1")
                    key = VK_F1;


                else if (UhRunetext == "F2")
                    key = VK_F2;


                else if (UhRunetext == "F3")
                    key = VK_F3;


                else if (UhRunetext == "F4")
                    key = VK_F4;


                else if (UhRunetext == "F5")
                    key = VK_F5;


                else if (UhRunetext == "F6")
                    key = VK_F6;


                else if (UhRunetext == "F7")
                    key = VK_F7;


                else if (UhRunetext == "F8")
                    key = VK_F8;

                else if (UhRunetext == "F9")
                    key = VK_F9;


                else if (UhRunetext == "F10")
                    key = VK_F10;


                else if (UhRunetext == "F11")
                    key = VK_F11;

                //here is the code for this?
                else if (UhRunetext == "F12")
                    key = VK_F12;

                System.Diagnostics.Process process = System.Diagnostics.Process.GetProcessesByName("Tibia").FirstOrDefault();
                var r = PostMessage(process.MainWindowHandle, WM_KEYDOWN, key, 0);
                
            }
            //--HP Potion Heal
            if (currentHp <= Helper.HpPotionHealth)
            {
                var text = Helper.HpPotiontext;

                var HpPotiontext = Helper.HpPotiontext;

                int key = 0;


                if (HpPotiontext == "F1")
                    key = VK_F1;


                else if (HpPotiontext == "F2")
                    key = VK_F2;


                else if (HpPotiontext == "F3")
                    key = VK_F3;


                else if (HpPotiontext == "F4")
                    key = VK_F4;


                else if (HpPotiontext == "F5")
                    key = VK_F5;


                else if (HpPotiontext == "F6")
                    key = VK_F6;


                else if (HpPotiontext == "F7")
                    key = VK_F7;


                else if (HpPotiontext == "F8")
                    key = VK_F8;

                else if (HpPotiontext == "F9")
                    key = VK_F9;


                else if (HpPotiontext == "F10")
                    key = VK_F10;


                else if (HpPotiontext == "F11")
                    key = VK_F11;

                
                else if (HpPotiontext == "F12")
                    key = VK_F12;

                System.Diagnostics.Process process = System.Diagnostics.Process.GetProcessesByName("Tibia").FirstOrDefault();
                var r = PostMessage(process.MainWindowHandle, WM_KEYDOWN, key, 0);

            }

            if (currentMana <= Helper.ManapotionHealth)
            {
                //var text = Helper.ManaPotion;

                var ManaPotiontext = Helper.ManaPotiontext;

                int key = 0;


                if (ManaPotiontext == "F1")
                    key = VK_F1;


                else if (ManaPotiontext == "F2")
                    key = VK_F2;


                else if (ManaPotiontext == "F3")
                    key = VK_F3;


                else if (ManaPotiontext == "F4")
                    key = VK_F4;


                else if (ManaPotiontext == "F5")
                    key = VK_F5;


                else if (ManaPotiontext == "F6")
                    key = VK_F6;


                else if (ManaPotiontext == "F7")
                    key = VK_F7;


                else if (ManaPotiontext == "F8")
                    key = VK_F8;

                else if (ManaPotiontext == "F9")
                    key = VK_F9;


                else if (ManaPotiontext == "F10")
                    key = VK_F10;


                else if (ManaPotiontext == "F11")
                    key = VK_F11;


                else if (ManaPotiontext == "F12")
                    key = VK_F12;

                System.Diagnostics.Process process = System.Diagnostics.Process.GetProcessesByName("Tibia").FirstOrDefault();
                var r = PostMessage(process.MainWindowHandle, WM_KEYDOWN, key, 0);
                


            }
            }
            catch (Exception)
            {

                //throw;
            }
        }




       


        public static void TimerTick(object sender, EventArgs e)
        {
            ReadValuesFromMemory();
            
        }
       

    }

    }

