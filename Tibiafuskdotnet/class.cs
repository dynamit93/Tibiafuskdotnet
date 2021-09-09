using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibiafuskdotnet
{
    class Class1
    {

        static void Main(string[] args)
        {

            appRunning("Tibia");

        }

        static void appRunning(string appName = "optinal")
        {
            Process[] localByName = Process.GetProcessesByName("Tibia");
            //Process[] ProcessList = Process.GetProcesses();

            foreach(Process p in localByName)
            {
                Console.WriteLine(p.ProcessName);
                if(p.ProcessName.Contains(appName))
                {
                    ///lägg in program
                    
                }
                /*else
                {
                    Console.WriteLine("start tibia");
                }*/
                
            }
            Console.ReadLine();
        }


    }
}
