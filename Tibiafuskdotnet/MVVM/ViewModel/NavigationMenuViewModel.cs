using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Tibia;

namespace Tibiafuskdotnet.MVVM.ViewModel
{
    public class NavigationMenuViewModel : ViewModelBase
    {

        private string _Clientip;

        public string Clientip
        {
            get { return _Clientip; }
            set { _Clientip = value; }
        }


        public int _Clientport;

        public int Clientport
        {
            get { return _Clientport; }
            set { _Clientport = value; }
        }



        public void Main()
        {/*
        connection:
            try
            {
                TcpClient client = new TcpClient(Clientip, Clientport);
                string messageToSend = "LALALALLALALALALALALLALAAL";
                int byteCount = Encoding.ASCII.GetByteCount(messageToSend + 1);
                byte[] sendData = Encoding.ASCII.GetBytes(messageToSend);

                NetworkStream stream = client.GetStream();
                stream.Write(sendData, 0, sendData.Length);
                Console.WriteLine("sending data to server...");

                StreamReader sr = new StreamReader(stream);
                string response = sr.ReadLine();
                Console.WriteLine(response);

                stream.Close();
                client.Close();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("failed to connect...");
                goto connection;
            }*/
        }


    }
    /*
    public class Host
    {



        private string _Clientip;

        public string Clientip
        {
            get { return _Clientip; }
            set { _Clientip = value; }
        }


        public int _Clientport;

        public int Clientport
        {
            get { return _Clientport; }
            set { _Clientport = value; }
        }


    }*/
}
