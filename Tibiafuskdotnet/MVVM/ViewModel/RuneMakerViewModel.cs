using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Tibia.Constants;
using Tibia.Objects;
using Tibiafuskdotnet.BL;
using Tibiafuskdotnet;
using GalaSoft.MvvmLight;
using System.Runtime.InteropServices;
using System.Windows.Documents;

namespace Tibiafuskdotnet.MVVM.ViewModel
{
    public class RuneMakerViewModel : ViewModelBase
    {
        public CancellationTokenSource RuneMakerCancellationTokenSource { get; set; }
        public IntPtr TargetWindow { get; set; }

        public int RuneMakerManaverb { get; set; }
        public string RuneMakerSpell { get; set; }
        public ICommand RuneMakerCommand { get; set; }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct INPUT
        {
            [FieldOffset(0)]
            public int type;
            [FieldOffset(4)]
            public KEYBDINPUT ki;
        }

        public IntPtr FindClientWindow(string uniqueTitle)
        {
            IntPtr hWnd = FindWindow(null, uniqueTitle);
            return hWnd;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetWindowText(IntPtr hwnd, string lpString);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        public const uint WM_KEYDOWN = 0x100;
        public const uint WM_KEYUP = 0x101;
        public const uint WM_CHAR = 0x102;
        private Client client;
        public RuneMakerViewModel()
        {
            client = MemoryReader.c;
            Tibia.Version.SetVersion772();
            RuneMakerCancellationTokenSource = new CancellationTokenSource();
            RuneMakerManaverb = 0;
            RuneMakerSpell = "";
            RuneMakerCommand = new RelayCommand(_ => RuneMaker());
        }

        // Add this new overload of the RuneMaker method
        public void RuneMaker()
        {
            RuneMaker(TargetWindow);
        }

        public class RelayCommand : ICommand
        {
            private readonly Action<object> _execute;
            private readonly Predicate<object> _canExecute;

            public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute(parameter);
            }

            public void Execute(object parameter)
            {
                _execute(parameter);
            }
        }

        


        public static string temptemp = "0x";
        public string TempHex = temptemp + BL.Program.TempHex;
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hObject);

        const uint PROCESS_VM_WRITE = 0x0020;
        const uint PROCESS_VM_OPERATION = 0x0008;
        const string processName = "Odenia Online";

        public void SetUniqueTitleToWindow(string originalTitle, string uniqueTitle)
        {
            IntPtr hWnd = FindWindow(null, originalTitle); if (hWnd != IntPtr.Zero)
            {
                SetWindowText(hWnd, uniqueTitle);
            }
        }

        public void sayTextOdenia(string valueToWrite)
        {
            string targetAddressString = BL.Program.TempHex;

            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                Process targetProcess = processes[0];
                IntPtr processHandle = targetProcess.Handle;

                long targetAddressLong = Convert.ToInt64(targetAddressString, 16);
                IntPtr targetAddress = new IntPtr(targetAddressLong);

                byte[] buffer = Encoding.Unicode.GetBytes(valueToWrite);

                WriteProcessMemory(processHandle, targetAddress, buffer, (uint)buffer.Length, out UIntPtr bytesWritten);
            }
        }

        public void SendRuneMakerSpell(string stext)
        {
            byte[] array_ascci = Encoding.ASCII.GetBytes(stext);

            IntPtr hWnd = FindClientWindow($"Odenia Online - Loka v1.3 - {MemoryReader.c.Player.Id}");
            if (hWnd == IntPtr.Zero)
            {
                return;
            }

            foreach (byte b in array_ascci)
            {
                SendMessage(hWnd, WM_KEYDOWN, b - 0x20, 0);
                SendMessage(hWnd, WM_CHAR, b, 0);
                SendMessage(hWnd, WM_KEYUP, b - 0x20, 0);
            }

            SendMessage(hWnd, WM_KEYDOWN, 0xD, 0);
            SendMessage(hWnd, WM_CHAR, 0xD, 0);
            SendMessage(hWnd, WM_KEYUP, 0xD, 0);
        }

       

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern ushort VkKeyScan(char ch);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public const int VK_ENTER = 0x0D;



        public void RuneMaker(IntPtr targetWindow)
        {
            if (!string.IsNullOrEmpty(RuneMakerSpell))
            {
                if (targetWindow != IntPtr.Zero)
                {
                    IntPtr foregroundWindow = GetForegroundWindow();

                    if (foregroundWindow != targetWindow)
                    {
                        SetForegroundWindow(targetWindow);
                    }

                    foreach (char c in RuneMakerSpell)
                    {
                        char lowerChar = char.ToLower(c);
                        ushort scanCode = VkKeyScan(lowerChar);
                        PostMessage(targetWindow, WM_CHAR, (IntPtr)scanCode, IntPtr.Zero);
                    }

                    PostMessage(targetWindow, WM_CHAR, (IntPtr)VK_ENTER, IntPtr.Zero);

                    if (foregroundWindow != targetWindow)
                    {
                        SetForegroundWindow(foregroundWindow);
                    }
                }
            }
        }








    }
}