
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows;
using Tibiafuskdotnet.BL;
using Tibia.Objects;
using Tibia.Constants;
using Tibiafuskdotnet.MVVM.ViewModel;
using System.Runtime.CompilerServices;
using Tibia;
using System.Diagnostics;
using Tibiafuskdotnet.Config;

namespace Tibiafuskdotnet
{

    public sealed class MemoryReader
    {
        public static MemoryReader Instance { get; } = new MemoryReader();

        private MemoryReader()
        {
        }

        // Window helpers
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public IntPtr GetWindowHandle(string windowTitle)
        {
            IntPtr hWnd = IntPtr.Zero;
            foreach (Process p in Process.GetProcesses())
            {
                if (p.MainWindowTitle.Contains(windowTitle))
                {
                    hWnd = p.MainWindowHandle;
                    break;
                }
            }
            return hWnd;
        }


        // Runtime state
        private Timer timer;
      

        private const int PROCESS_WM_READ = 0x0010;

        private int baseAddress;
        public string Bc1;
        public int currentHp;
        public int maxHp;
        public int currentMana;
        public int maxMana;
        public int xor;
        public int Attackmode;
        public int Followmode;
        public string chatt;
        public int light;
        public int Odenialight;
        public int maxlight;
        
        public int WaypointsTestZ;
        public int WaypointsTestX;
        public int WaypointsTestY;

        public int maxHpValue;
        public int maxManaValue;
        public int Odeniamaxlight;
        public int BattleListconvert;
        public int manaValue;
        public int hpValue;
        public string bc;
        //character 
        public string Charactername;

        // Address resolution helpers
        private const int DefaultModuleBase = 0x400000;

        private int ResolveAddress(uint absoluteAddress)
        {
            return unchecked((int)(absoluteAddress - DefaultModuleBase + baseAddress));
        }

        private int ResolveAddressOrZero(uint absoluteAddress)
        {
            return absoluteAddress == 0 ? 0 : ResolveAddress(absoluteAddress);
        }
        // Input helpers
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



        // Runtime tuning
        private double manaPercentInput;
        private double hpPercentLightHealInput;
        private double hpPercentIntenseHealInput;


        // Process memory imports
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess,
          int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress,
        byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);


        public void Start(double _manaPercentInput, double _hpPercentLightHealInput, double _hpPercentIntenseHealInput)
        {
            //this.lb = lb;
            manaPercentInput = _manaPercentInput;
            hpPercentLightHealInput = _hpPercentLightHealInput;
            hpPercentIntenseHealInput = _hpPercentIntenseHealInput;
            

            timer = new Timer();
            timer.Interval = 50;
            timer.Elapsed += new ElapsedEventHandler(TimerTick);
            timer.Start();

            
            //ReadValuesFromMemory();
        }

        // Session objects
        public BattleList battleList = null;
        
        public Client client = null;
        public Creature creature = null;
        /// <summary>
        /// Dennis gjort
        /// </summary>
        public Client.PlayerHelper playerHelper = null;
        public Inventory inventory = null;

        public Player pp = null;
        public Client c;
        public Creature C;


        
        public bool AppRunning(string appName = null)
        {

            string targetName = string.IsNullOrWhiteSpace(appName) ? TibiaConfig.ProcessName : appName;
            System.Diagnostics.Process[] localByName = System.Diagnostics.Process.GetProcessesByName(targetName);
            //Process[] ProcessList = Process.GetProcesses();
           
            foreach (System.Diagnostics.Process p in localByName)
            {
                //System.Console.WriteLine(p.ProcessName);
                if (p.ProcessName.Contains(targetName))
                {

                    c = new Client(p);
                    battleList = new BattleList(c);
                    
                    inventory = new Inventory(c);
                    
                    playerHelper = new Client.PlayerHelper(c);

                   

                    timer.Start();
                    TibiaConfig.ApplyVersion(p);
                    Tibia.Objects.Client.GetClients();
                    System.Console.WriteLine(Tibia.Objects.Client.GetClients()); 

                    foreach (Creature C in battleList.GetCreatures())
                    {
                        //System.Console.WriteLine("Creature: " + C.Name + "ID: " + C.Id);
                        
                    }

                    // Dennis gjort Skriver ut alla backpacks finns med id + namn + Vilket nummer backpackn finns
                    foreach (Container MyC in inventory.GetContainers())
                    {
                        
                       // System.Console.WriteLine( MyC.Id +" "+ MyC.Name + " " + MyC.Number );
                    }


                    // PRINT OUT THE LOCATION OF THE PLAYER
                    // System.Console.WriteLine(c.PlayerLocation);

                    // do something with SpriteReader to find magicwall i guess.
                    // System.Console.WriteLine("Magic wall info " + Tibia.Util.SpriteReader.GetSpriteImage(c,2129));
                    ///Tibia.Objects.ItemLocation.FromLocation();
                    ///

                  

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
                    
                    MessageBox.Show($"start {targetName}");
                    
                    return false;
                }
               
            }
            
            return false;
        }
       
        public void playerwalk() 
        {
            Waypoints gwt = new Waypoints();
            Tibia.Objects.Player p = client.GetPlayer();
            //p.GoTo = Location();

        }
        private static Creature[] NewMethod()
        {
            return new Creature[30];
        }

        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;

        public void WriteValuesToMemory(uint address, byte[] buffer)

        {
            var tibia = TibiaConfig.GetProcess();
            if (tibia == null)
            {
                MessageBox.Show($"Could Not Find {TibiaConfig.ProcessName}");
                return;
            }else
            { 
            

           
            baseAddress = tibia.MainModule.BaseAddress.ToInt32();
            TibiaConfig.ApplyVersion(tibia);
            IntPtr processHandle = OpenProcess(PROCESS_VM_WRITE | PROCESS_VM_OPERATION, false, tibia.Id);

            int bytesWritten = 0;
            int resolvedAddress = ResolveAddress(address);
            WriteProcessMemory((int)processHandle, resolvedAddress, buffer, buffer.Length, ref bytesWritten);
            //System.Console.WriteLine(bytesWritten);

            int attackmodeuint = ResolveAddress(Tibia.Addresses.Client.AttackMode);
            WriteProcessMemory((int)processHandle, attackmodeuint, buffer, buffer.Length, ref bytesWritten);
            Attackmode = BitConverter.ToInt32(buffer, 0);

            int Followmodeuint = ResolveAddress(Tibia.Addresses.Client.FollowMode);
            WriteProcessMemory((int)processHandle, Followmodeuint, buffer, buffer.Length, ref bytesWritten);
            Followmode = BitConverter.ToInt32(buffer, 0);

            }

        }
        public void OdeniaWriteToMemory(int address, byte[] buffer)

        {

            var tibia = TibiaConfig.GetProcess();

            if (tibia == null)
            {
                MessageBox.Show($"Could Not Find {TibiaConfig.ProcessName}");
                return;
            }
            else { 
            baseAddress = tibia.MainModule.BaseAddress.ToInt32();
            TibiaConfig.ApplyVersion(tibia);
            IntPtr processHandle = OpenProcess(PROCESS_VM_WRITE | PROCESS_VM_OPERATION, false, tibia.Id);

            int bytesWritten = 0;
            WriteProcessMemory((int)processHandle, address, buffer, buffer.Length, ref bytesWritten);
            //System.Console.WriteLine(bytesWritten);

            int attackmodeuint = ResolveAddress(Tibia.Addresses.Client.AttackMode);
            WriteProcessMemory((int)processHandle, attackmodeuint, buffer, buffer.Length, ref bytesWritten);
            Attackmode = BitConverter.ToInt32(buffer, 0);

            int Followmodeuint = ResolveAddress(Tibia.Addresses.Client.FollowMode);
            WriteProcessMemory((int)processHandle, Followmodeuint, buffer, buffer.Length, ref bytesWritten);
            Followmode = BitConverter.ToInt32(buffer, 0);



            }



        }






        public void ReadValuesFromMemory()
        {

            try
            {


                //var tibia = Process.GetProcesses().ToList().Where(x=>x.ProcessName.ToLower().Contains("ti")).ToList();
                var tibia = TibiaConfig.GetProcess();
                if (tibia == null)
                {
                    MessageBox.Show($"Could Not Find {TibiaConfig.ProcessName}");
                    return;
                }else
                {

                
                baseAddress = tibia.MainModule.BaseAddress.ToInt32();
                TibiaConfig.ApplyVersion(tibia);
                IntPtr handle = OpenProcess(PROCESS_WM_READ, false, tibia.Id);

                int bytesRead = 0;
                byte[] buffer = new byte[30];
                int attackmodeuint = ResolveAddress(Tibia.Addresses.Client.AttackMode);

                ReadProcessMemory((int)handle, attackmodeuint, buffer, buffer.Length, ref bytesRead);
                Attackmode = BitConverter.ToInt32(buffer, 0);


                int xorAddress = ResolveAddressOrZero(Tibia.Addresses.Custom.XorKey);
                if (xorAddress != 0)
                {
                    ReadProcessMemory((int)handle, xorAddress, buffer, buffer.Length, ref bytesRead);
                    xor = BitConverter.ToInt32(buffer, 0);
                }
                else
                {
                    xor = 0;
                }

                ReadProcessMemory((int)handle, ResolveAddress(Tibia.Addresses.Player.Health), buffer, buffer.Length, ref bytesRead);
                currentHp = BitConverter.ToInt32(buffer, 0);

                //  ReadProcessMemory((int)handle, ResolveAddressOrZero(Tibia.Addresses.Custom.CharacterName), buffer, buffer.Length, ref bytesRead);
                //  Charactername = BitConverter.ToString(buffer, 0);

                ReadProcessMemory((int)handle, ResolveAddress(Tibia.Addresses.Player.Mana), buffer, buffer.Length, ref bytesRead);
                currentMana = BitConverter.ToInt32(buffer, 0);

                ReadProcessMemory((int)handle, ResolveAddress(Tibia.Addresses.Player.HealthMax), buffer, buffer.Length, ref bytesRead);
                maxHp = BitConverter.ToInt32(buffer, 0);

                ReadProcessMemory((int)handle, ResolveAddress(Tibia.Addresses.Player.ManaMax), buffer, buffer.Length, ref bytesRead);
                maxMana = BitConverter.ToInt32(buffer, 0);


                int chatAddress = ResolveAddressOrZero(Tibia.Addresses.Custom.ChatText);
                if (chatAddress != 0)
                {
                    ReadProcessMemory((int)handle, chatAddress, buffer, buffer.Length, ref bytesRead);
                    chatt = BitConverter.ToString(buffer, 0);
                    ReadProcessMemory((int)handle, chatAddress, buffer, buffer.Length, ref bytesRead);
                }
                //  int * data =(int32*)BitConverter.ToInt32(buffer, 0);


                ReadProcessMemory((int)handle, ResolveAddress(Tibia.Addresses.Map.FullLightAdr), buffer, buffer.Length, ref bytesRead);
                light = BitConverter.ToInt32(buffer, 0);


                /* ReadProcessMemory((int)handle, Tibia.Version, buffer, buffer.Length, ref bytesRead);
                 WaypointsTestZ = BitConverter.ToInt32(buffer, 0);
                */





                ReadProcessMemory((int)handle, ResolveAddress(Tibia.Addresses.Player.X), buffer, buffer.Length, ref bytesRead);
                WaypointsTestX = BitConverter.ToInt32(buffer, 0);

                ReadProcessMemory((int)handle, ResolveAddress(Tibia.Addresses.Player.Y), buffer, buffer.Length, ref bytesRead);
                WaypointsTestY = BitConverter.ToInt32(buffer, 0);

                ReadProcessMemory((int)handle, ResolveAddress(Tibia.Addresses.Player.Z), buffer, buffer.Length, ref bytesRead);
                WaypointsTestZ = BitConverter.ToInt32(buffer, 0);




                AppRunning();


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

                    chatt = "Healing";
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

                    System.Diagnostics.Process process = TibiaConfig.GetProcess();
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

                    System.Diagnostics.Process process = TibiaConfig.GetProcess();
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

                    System.Diagnostics.Process process = TibiaConfig.GetProcess();
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

                    System.Diagnostics.Process process = TibiaConfig.GetProcess();
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

                    System.Diagnostics.Process process = TibiaConfig.GetProcess();
                    var r = PostMessage(process.MainWindowHandle, WM_KEYDOWN, key, 0);



                }
                }
            }
            catch (Exception e)
            {


                MessageBox.Show("Cannot found Tibia" + e);
                System.Windows.Application.Current.Shutdown();

                // System.Windows.Application.Current.Shutdown();
                //throw;
            }

            // DOssnt work yet its should find magic wall object on ground. 




            foreach (Tile tile in c.Map.GetTiles())
            {

                //Check if the tile has an item on the ground
                if (tile.Ground != null)
                {

                    //Check if the item's id matches the item id you are searching for
                    if (tile.Ground.Id == 2129)
                    {
                        //The item was found, do something with it
                        System.Console.WriteLine("MAGICWALLLLLLLLLL");
                        break;
                    }
                    else if (tile.Ground.Id == 2128)
                    {
                        //The item was found, do something with it
                        System.Console.WriteLine("MAGICWALLLLLLLLLL");
                        break;
                    }
                    else if (tile.Ground.Id == 3079)
                    {
                        System.Console.WriteLine("BOHHHHHHHHHHH");
                    }
                    else if (tile.Ground.Id == 2123)
                    {
                        System.Console.WriteLine("FIREBOMB");
                    }

                }
            }

        }

        public void OdeniaOnlineLight() 
        {
            var tibia = TibiaConfig.GetProcess();
            if (tibia == null)
            {
            


                MessageBox.Show($"Could Not Find {TibiaConfig.ProcessName}");
                return;
            }
            else
            {
                baseAddress = tibia.MainModule.BaseAddress.ToInt32();
                TibiaConfig.ApplyVersion(tibia);
                IntPtr handle = OpenProcess(PROCESS_WM_READ, false, tibia.Id);

                int bytesRead = 0;
                byte[] buffer = new byte[30];

                int lightLowAddress = ResolveAddressOrZero(Tibia.Addresses.Custom.OdeniaLightLow);
                int lightHighAddress = ResolveAddressOrZero(Tibia.Addresses.Custom.OdeniaLightHigh);
                if (lightLowAddress == 0 || lightHighAddress == 0)
                {
                    return;
                }

                ReadProcessMemory((int)handle, lightLowAddress, buffer, buffer.Length, ref bytesRead);
                light = BitConverter.ToInt32(buffer, 0);
           


            if (lightHighAddress != 0 && lightLowAddress != 0)
            {
                OdeniaWriteToMemory(lightHighAddress, BitConverter.GetBytes(43));
                OdeniaWriteToMemory(lightLowAddress, BitConverter.GetBytes(100));

            }
            }
            /*else
            {
                OdeniaWriteToMemory(ResolveAddress(Tibia.Addresses.Map.FullLightAdr), BitConverter.GetBytes(0));

            }*/
            


        }

        public void changeOdeniaTitle()
        {
            if (Tibia.Version.CurrentVersionString == "7.72")
            {
                
               // runeMakerViewModel.SetUniqueTitleToWindow("Odenia Online - Loka v1.3", $"Odenia Online - Loka v1.3 - {c.Player.Id}");
            }
        }

        public void TimerTick(object sender, EventArgs e)
        {
            
            //ReadValuesFromMemory();
            //System.Console.WriteLine("attackmode " + Attackmode);
            OdeniaOnlineLight();
            changeOdeniaTitle();


        }
       
        

    }


    }

