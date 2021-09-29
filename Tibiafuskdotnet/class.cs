using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tibiafuskdotnet
{
    public class Class1
    {

        /*static void Main(string[] args)
        {

            appRunning("Tibia");

        }*/

        public static bool appRunning(string appName =  "Tibia")
        {
            Process[] localByName = Process.GetProcessesByName("Tibia");
            //Process[] ProcessList = Process.GetProcesses();

            foreach(Process p in localByName)
            {
                Console.WriteLine(p.ProcessName);
                if(p.ProcessName.Contains(appName))
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


    }
}
