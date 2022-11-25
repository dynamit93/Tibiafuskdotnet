using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;


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


        private string _Response;

        public string Response
        {
            get { return _Response; }
            set { _Response = value; }
        }

        NaviPlayer naviPlayer = new NaviPlayer();


        public void Main()
        {
            string request = Response;
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string text = request;
            string[] words = text.Split(delimiterChars);
            System.Console.WriteLine($"{words.Length} words in text:");

            foreach (var word in words)
            {

                //Takeing out The "varibale String" From recived Data(from Client) Splitting the word from the string
                string Recivestring = string.Empty;

                for (int i = 0; i < word.Length; i++)
                {
                    if (Char.IsLetter(word[i]))
                        Recivestring += word[i];
                }


                //Takeing Out Value from Client(Splitting the int from the string)
                string str2 = string.Empty;
                int Reciveint = 0;
                //Console.WriteLine($"String with number: {word}");
                for (int i = 0; i < word.Length; i++)
                {
                    if (Char.IsDigit(word[i]))
                        str2 += word[i];
                }
                if (str2.Length > 0)
                {
                    Reciveint = int.Parse(str2);
                    Console.WriteLine($"Extracted Number: {Reciveint}");
                }
                //Insert Value To Variable from reviced Data
                if (Recivestring.Length > 0)
                {
                    System.Console.WriteLine(Recivestring);
                    if (Recivestring == "Playerid")
                    {
                        naviPlayer.Playerid = Reciveint;
                    }
                    if (Recivestring == "TargetId")
                    {
                        naviPlayer.TargetId = Reciveint;
                    }
                    if (Recivestring == "Health")
                    {
                        naviPlayer.Health = Reciveint;
                    }
                    if (Recivestring == "Mana")
                    {
                        naviPlayer.Mana = Reciveint;

                    }
                    if (Recivestring == "Capacity")
                    {
                        naviPlayer.Capacity = Reciveint;

                    }
                    if (Recivestring == "Stamina")
                    {
                        naviPlayer.Stamina = Reciveint;

                    }
                    if (Recivestring == "MagicLevel")
                    {
                        naviPlayer.MagicLevel = Reciveint;

                    }
                    if (Recivestring == "Fist")
                    {
                        naviPlayer.Fist = Reciveint;


                    }
                    if (Recivestring == "Club")
                    {
                        naviPlayer.Club = Reciveint;

                    }
                    if (Recivestring == "Sword")
                    {
                        naviPlayer.Sword = Reciveint;

                    }
                    if (Recivestring == "Axe")
                    {
                        naviPlayer.Axe = Reciveint;

                    }
                    if (Recivestring == "Distance")
                    {
                        naviPlayer.Distance = Reciveint;

                    }
                    if (Recivestring == "Shielding")
                    {
                        naviPlayer.Shielding = Reciveint;

                    }
                    if (Recivestring == "X")
                    {
                        naviPlayer.X = Reciveint;

                    }
                    if (Recivestring == "Y")
                    {
                        naviPlayer.Y = Reciveint;

                    }
                    if (Recivestring == "Z")
                    {
                        naviPlayer.Z = Reciveint;

                    }
                }

                /*
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

        public class NaviPlayer
        {

            public string Name { get; set; }
            public Int32 Playerid { get; set; }
            public Int32 TargetId { get; set; }
            public Int32 Health { get; set; }
            public Int32 Mana { get; set; }
            public Int32 Capacity { get; set; }
            public Int32 Stamina { get; set; }
            public Int32 MagicLevel { get; set; }
            public Int32 Fist { get; set; }
            public Int32 Club { get; set; }
            public Int32 Sword { get; set; }
            public Int32 Axe { get; set; }
            public Int32 Distance { get; set; }
            public Int32 Shielding { get; set; }
            public Int32 X { get; set; }
            public Int32 Y { get; set; }
            public Int32 Z { get; set; }

        }
    }
}
