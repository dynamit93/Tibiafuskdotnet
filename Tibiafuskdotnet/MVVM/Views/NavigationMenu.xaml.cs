using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tibiafuskdotnet.MVVM.ViewModel;



namespace Tibiafuskdotnet.MVVM.Views
{
    /// <summary>
    /// Interaction logic for NavigationMenu.xaml
    /// </summary>
    public partial class NavigationMenu : Window
    {

        



        public NavigationMenu()
        {
            InitializeComponent();

            string text = Cleintportfail.Text;
            int naviPort = Convert.ToInt32(text);
            string naviip = Clientip.Text; 
        }
        

        NavigationMenuViewModel host = new NavigationMenuViewModel { Clientip = "127.0.0.1", Clientport = 1302 };
        Waypoints waypoints = new Waypoints();
        
        
        NavigationMenuViewModel NavigationMenuViewModel = new NavigationMenuViewModel();


        //NavigationMenuViewModel host = new NavigationMenuViewModel();
        // NavigationMenuViewModel NavigationMenuViewModel = new NavigationMenuViewModel();
        private void Button_Click(object sender, RoutedEventArgs e)
        {


        //connection:
            try
            {
                TcpClient client = new TcpClient(host.Clientip, host.Clientport);
                string messageToSend = Convert.ToString(
                      
                      MemoryReader.c.Player.Id
                    + "Playerid:"
                    + MemoryReader.c.Player.TargetId
                    + "TargetId:"
                    + MemoryReader.c.Player.Health
                    + "Health:"
                    + MemoryReader.c.Player.Mana
                    + "Mana:"
                    + MemoryReader.c.Player.Capacity
                    + "Capacity:"
                    + MemoryReader.c.Player.Stamina
                    + "Stamina:"
                    + MemoryReader.c.Player.MagicLevel
                    + "MagicLevel:"
                    + MemoryReader.c.Player.Fist
                    + "Fist:"
                    + MemoryReader.c.Player.Club
                    + "Club:"
                    + MemoryReader.c.Player.Sword
                    + "Sword:"
                    + MemoryReader.c.Player.Axe
                    + "Axe:"
                    + MemoryReader.c.Player.Distance
                    + "Distance:"
                    + MemoryReader.c.Player.Shielding
                    + "Shielding:"
                    + MemoryReader.c.Player.X
                    + "X:"
                    + MemoryReader.c.Player.Y
                    + "Y:"
                    + MemoryReader.c.Player.Z
                    + "Z:");


                //int byteCount2 = Encoding.ASCII.GetByteCount(messageToSend2 + 1);
                //byte[] sendData2 = Encoding.ASCII.GetBytes(messageToSend2);
                int byteCount = Encoding.ASCII.GetByteCount(messageToSend + 1);
                byte[] sendData = Encoding.ASCII.GetBytes(messageToSend);
                System.Console.WriteLine(messageToSend);
                NetworkStream stream = client.GetStream();
                stream.Write(sendData, 0, sendData.Length);
                //stream.Write(sendData2, 0, sendData2.Length);
                System.Console.WriteLine("sending data to server...");

                StreamReader sr = new StreamReader(stream);
                NavigationMenuViewModel.Response = sr.ReadLine();
                System.Console.WriteLine(NavigationMenuViewModel.Response + " Data Recive from server");
                NavigationMenuViewModel.NaviPlayer naviPlayer = new NavigationMenuViewModel.NaviPlayer();
                stream.Close();
                client.Close();
                NavigationMenuViewModel.Main();
                System.Console.WriteLine(naviPlayer.Mana);
            }
            catch (Exception ea)
            {
                MessageBox.Show("failed to connect..." + ea.Message);
                System.Console.WriteLine();
                //goto connection;
            }
        }
    }
}
