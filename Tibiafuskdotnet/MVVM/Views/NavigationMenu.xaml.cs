using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Tibia.Constants;
using Tibia.Objects;
using Tibiafuskdotnet.MVVM.ViewModel;


namespace Tibiafuskdotnet.MVVM.Views
{
    /// <summary>
    /// Interaction logic for NavigationMenu.xaml
    /// </summary>
    public partial class NavigationMenu : Window
    {

        NavigationMenuViewModel.Host host = new NavigationMenuViewModel.Host { Clientip = "127.0.0.1", Clientport = 1302 };
        
        public NavigationMenu()
        {
            InitializeComponent();


        }
        
        Waypoints waypoints = new Waypoints();


        // NavigationMenuViewModel NavigationMenuViewModel = new NavigationMenuViewModel();
        private void Button_Click(object sender, RoutedEventArgs e)
        {


        //connection:
            try
            {
                TcpClient client = new TcpClient(host.Clientip, host.Clientport);
                //string messageToSend = Convert.ToString("waypoint x "+waypoints.waypointx + " waypoint y " + waypoints.waypointy + " waypoint z " +waypoints.waypointz);
                string messageToSend = Convert.ToString(":x:" + MemoryReader.c.Player.X + ":y:" + MemoryReader.c.Player.Y + ":z:" + MemoryReader.c.Player.Z);
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
                string response = sr.ReadLine();
                System.Console.WriteLine(response);

                stream.Close();
                client.Close();
                
            }
            catch (Exception ea)
            {
                System.Console.WriteLine("failed to connect...");
                //goto connection;
            }
        }
    }
}
