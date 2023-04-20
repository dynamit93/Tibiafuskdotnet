using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tibiafuskdotnet.BL
{

    class Program
    {
        private const int AllocationGranularity = 64 * 1024;

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, int dwLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);


        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);



        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_BASIC_INFORMATION
        {
            public IntPtr BaseAddress;
            public IntPtr AllocationBase;
            public AllocationProtect AllocationProtect;
            public IntPtr RegionSize;
            public uint State;
            public AllocationProtect Protect;
            public uint Type;
        }

        [Flags]
        public enum AllocationProtect : uint
        {
            PAGE_EXECUTE = 0x00000010,
            PAGE_EXECUTE_READ = 0x00000020,
            PAGE_EXECUTE_READWRITE = 0x00000040,
            PAGE_EXECUTE_WRITECOPY = 0x00000080,
            PAGE_NOACCESS = 0x00000001,
            PAGE_READONLY = 0x00000002,
            PAGE_READWRITE = 0x00000004,
            PAGE_WRITECOPY = 0x00000008,
            PAGE_GUARD = 0x00000100,
            PAGE_NOCACHE = 0x00000200,
            PAGE_WRITECOMBINE = 0x00000400
        }

        public const uint MEM_COMMIT = 0x00001000;
        const int WM_CHAR = 0x0102;
        const int PROCESS_VM_READ = 0x0010;

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_INFO
        {
            public ushort processorArchitecture;
            ushort reserved;
            public uint pageSize;
            public IntPtr minimumApplicationAddress;
            public IntPtr maximumApplicationAddress;
            public IntPtr activeProcessorMask;
            public uint numberOfProcessors;
            public uint processorType;
            public uint allocationGranularity;
            public ushort processorLevel;
            public ushort processorRevision;
        }

       public static void Main()
        {

            // Replace "Odenia Online" with the correct window title of the application
            IntPtr hWnd = FindWindow(null, "Odenia Online - Loka v1.3");

            if (hWnd == IntPtr.Zero)
            {
                Console.WriteLine("Cannot find the Odenia Online window. Make sure it is running.");
                return;
            }
            SetForegroundWindow(hWnd);

            string textToSend = "HelloHelloHelloHelloHelloHelloHelloHelloHello";
            foreach (char c in textToSend)
            {
                SendMessage(hWnd, WM_CHAR, (IntPtr)c, IntPtr.Zero);
                Thread.Sleep(100); // Add a small delay between sending each character
            }

            string processName = "Odenia Online";
            string searchString = "HelloHelloHelloHelloHelloHelloHelloHelloHello";

            Process[] processes = Process.GetProcessesByName(processName);

            Console.WriteLine($"Found {processes.Length} processes with the name '{processName}'");

            foreach (Process process in processes)
            {
                Console.WriteLine($"Checking process: {process.ProcessName}");

                FindStringInProcessMemory(process, searchString);
            }

            Console.WriteLine("Press any key to exit...");
            
        }
        public static List<long> foundAddresses = new List<long>();
        public static IntPtr foundAddress = IntPtr.Zero;

        public static string TempHex;
        public static int inttemphex;
        private static void FindStringInProcessMemory(Process process, string searchString)
        {
            if (process == null || string.IsNullOrEmpty(searchString))
            {
                return;
            }

            GetSystemInfo(out SYSTEM_INFO systemInfo);
            IntPtr currentAddress = new IntPtr(AllocationGranularity);

            byte[] searchStringBytes = Encoding.UTF8.GetBytes(searchString);
            MEMORY_BASIC_INFORMATION memInfo = new MEMORY_BASIC_INFORMATION();

            while (currentAddress != IntPtr.Zero)
            {
                VirtualQueryEx(process.Handle, currentAddress, out memInfo, Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));

                if (memInfo.Protect == AllocationProtect.PAGE_READWRITE && memInfo.State == MEM_COMMIT)
                {
                    byte[] buffer = new byte[memInfo.RegionSize.ToInt32()];
                    ReadProcessMemory(process.Handle, memInfo.BaseAddress, buffer, memInfo.RegionSize.ToInt32(), out _);

                    for (int i = 0; i < buffer.Length - searchStringBytes.Length; i++)
                    {
                        if (buffer[i] == searchStringBytes[0])
                        {
                            bool match = true;

                            for (int j = 1; j < searchStringBytes.Length; j++)
                            {
                                if (buffer[i + j] != searchStringBytes[j])
                                {
                                    match = false;
                                    break;
                                }
                            }
                            //List<long> foundAddresses = new List<long>();
                            if (match)
                            {
                                foundAddress = new IntPtr(memInfo.BaseAddress.ToInt64() + i);
                                //Console.WriteLine("Found '{0}' at address 0x{1:X}", searchString, memInfo.BaseAddress.ToInt64() + i);
                                long address = memInfo.BaseAddress.ToInt64() + i;
                                Console.WriteLine("Found '{0}' at address 0x{1:X}", searchString, address);

                                int decimalValue = Convert.ToInt32(address);
                                string hexValue = decimalValue.ToString("X");
                                Console.WriteLine("adsasdasd"+ hexValue); // Output: "FF"
                                TempHex = hexValue;
                                Console.WriteLine("ERIK SÄGER DENNA " + address);
                                foundAddresses.Add(address);

                            }
                        }
                    }
                }

                try
                {
                    checked
                    {
                        currentAddress = new IntPtr(currentAddress.ToInt64() + AllocationGranularity);
                    }
                }
                catch (OverflowException)
                {
                    break;
                }
            }
            foreach (var address in foundAddresses)
            {
                Console.WriteLine($"MEMORY ADRESSSS USE TO SEND TEXT: {currentAddress}");
            }
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, UIntPtr nSize, out IntPtr lpNumberOfBytesWritten);

        const uint PROCESS_VM_WRITE = 0x0020;
        const uint PROCESS_VM_OPERATION = 0x0008;
        public static void writetoOdenia (int inttemphex, string exura)
        {
            Process[] processes = Process.GetProcessesByName("Odenia Online");
            if (processes.Length == 0)
            {
                Console.WriteLine("Odenia Online process not found.");
                return;
            }

            Process odeniaOnlineProcess = processes[0];
            IntPtr processHandle = OpenProcess(PROCESS_VM_WRITE | PROCESS_VM_OPERATION, false, odeniaOnlineProcess.Id);

            if (processHandle == IntPtr.Zero)
            {
                Console.WriteLine("Failed to open process.");
                return;
            }

            
            byte[] exuraBytes = Encoding.ASCII.GetBytes(exura);

            IntPtr memoryAddress = new IntPtr(inttemphex);
            IntPtr bytesWritten;

            bool result = WriteProcessMemory(processHandle, memoryAddress, exuraBytes, (UIntPtr)exuraBytes.Length, out bytesWritten);

            if (result)
            {
                Console.WriteLine("Exura has been written to memory address 0x27C19D8.");
            }
            else
            {
                Console.WriteLine("Failed to write Exura to memory address 0x27C19D8.");
            }
        }

    }
}
