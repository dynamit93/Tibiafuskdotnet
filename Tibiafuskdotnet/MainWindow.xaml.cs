﻿using System;
using System.Windows;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using Tibiafuskdotnet.BL;
using Tibia.Util;
using System.Net;
using System.Diagnostics;

namespace Tibiafuskdotnet
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;



        public MainWindow()
        {

            DataContext = this;
            InitializeComponent();
/*
            WebClient webClient = new WebClient();

            try
            { 
                if (!webClient.DownloadString("https://pastebin.com/raw/gTZGA5rp").Contains("1.5.0"))
                {
                    if (System.Windows.Forms.MessageBox.Show("Looks like there is an update! Do you want to download it?", "Updater", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        using (var client = new WebClient())
                        {
                           // Directory.CreateDirectory(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Updates"));
                           // string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Updates\\";
                            // Directory.CreateDirectory(filepath);
                            //Environment.GetFolderPath(Environment.SpecialFolder.Personal + "sdfsdf");
                            
                            Process.Start("updatecore.exe");
                            this.Close();
                                                       
                        }                    
                }
            }
            catch
            {
                
                MessageBox.Show("error");
            }*/
            
            MemoryReader.Start(0, 0, 0);

            Helper.Initialize();
            var data = Helper.ReadFromFile();
            data = data ?? new Cheat();
            data.SpellHitext = data.SpellHitext ?? "";

            Helper.SpellHiHealth = data.SpellHiHealth;
            Helper.SpellHiMana = data.SpellHiMana;
            Helper.SpellHitext = data.SpellHitext;
            Helper.SpellLoHealth = data.SpellLoHealth;
            Helper.UhRuneHealth = data.UhRuneHealth;
            Helper.HpPotionHealth = data.HpPotionHealth;
            Helper.SpellLoMana = data.SpellLoMana;
            Helper.SpellLotext = data.SpellLotext;
            con = new MySqlConnection("Server=localhost;Database=test1;user=root;Pwd=benny123;SslMode=none");
            //Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;

            System.Diagnostics.Process[] localByName = System.Diagnostics.Process.GetProcessesByName("Tibia");
            //Process[] ProcessList = Process.GetProcesses();
            /*
                        foreach (System.Diagnostics.Process p in localByName)
                        {
                            System.Console.WriteLine(p.ProcessName);
                            if (p.ProcessName.Contains("Tibia"))
                            {
                                Client c = new Client(p);
                                BattleList bc = new BattleList(c);
                                // Version.Set(client.Version, client.Process);
                                Tibia.Version.SetVersion860();

                                foreach (Creature C in bc.GetCreatures())
                                {
                                    System.Console.WriteLine("Creature " + C.Name);
                                }
                                System.Console.WriteLine(bc.GetCreatures()); 
                            }
                        }
                        */

        }



        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {

            string username = UsernameText.Text;
            string password = PasswordText.Text;



            cmd = new MySqlCommand();
            /*   
               var dbversion = Convert.ToInt32(cmd.ExecuteScalar());
               try
               {
                   // Open the text file using a stream reader.
                   using (var sr = new StreamReader("version.txt"))
                      // sr = Convert.ToInt32(sr);
                   {
                       // Read the stream as a string, and write the string to the console.
                       // check if dbversion is bigger then sr.ReadToEnd
                       if ((dbversion) > (sr.ReadToEnd()))
                       //((dbversion) > (sr.ReadToEnd))
                       {
                           MessageBox.Show("Update needed!" + "Download from: http://appbot.com/Downloads");
                       }
                   }
               }
               catch (IOException ex)
               {
                   Console.WriteLine("The file could not be read:");
                   Console.WriteLine(ex.Message);
               }*/





            try
            {
                con.Open();
            }
            catch (Exception)
            {

                MessageBox.Show("can't reach Database");
                //exit Appliaction
                Environment.Exit(0);

            }
            cmd.Connection = con;
            cmd.CommandText = "SELECT premium FROM account where username='" + UsernameText.Text + "' AND password='" + PasswordText.Text + "'";

            //cmd.CommandText = "SELECT * FROM account where username='" + UsernameText.Text + "' AND password='" + PasswordText.Text + "'";
            //SELECT premium FROM account WHERE username ='123' and password='123'
            // cmd.CommandText = "SELECT '" + premium + "' FROM account where username='" + UsernameText.Text + "' AND password='" + PasswordText.Text + "'";
            //var prem = (int)cmd.ExecuteScalar();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                // checking Prmeium days
                /// but its checking the number NOT DATE!
                int premiumdays = dr.GetInt32(0);
                if ((premiumdays) >= 1)
                {

                    if (MemoryReader.AppRunning())
                    {
                        MainMenu Menu = new MainMenu();
                        Menu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Start tibia first");
                        System.Windows.Application.Current.Shutdown();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No Premium Days");
                }
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
            con.Close();

            //new MemoryReader(0, 0, 0);
        }

        private void Forgotten_btn_Click(object sender, RoutedEventArgs e)
        {
            Forgottenpassword forgottenpassword = new Forgottenpassword();
            forgottenpassword.Show();
            this.Close();
        }

        private void d(object sender, KeyEventArgs e)
        {

        }

        private void Testbutton_Click(object sender, RoutedEventArgs e)
        {
            ClientChooserWPF ClientChooser = new ClientChooserWPF();
            ClientChooser.Show();


        }
    }
}
