using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using Tibiafuskdotnet.BL;

namespace Tibiafuskdotnet
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        Memory.Mem m = new Memory.Mem();
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
         

                Helper.Initialize();
            var data = Helper.ReadFromFile();
            data = data ?? new Cheat();
            data.SpellHitext = data.SpellHitext ?? "";
            
            Helper.SpellHiHealth = data.SpellHiHealth;
            Helper.SpellHiMana = data.SpellHiMana;
            Helper.SpellHitext = data.SpellHitext;
            con = new MySqlConnection("Server=localhost;Database=test1;user=root;Pwd=benny123;SslMode=none");
            //Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;

            

          
        }
      


        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            // TODO add premium checker.
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
            cmd.CommandText = "SELECT * FROM account where username='" + UsernameText.Text + "' AND password='" + PasswordText.Text + "'";

            // cmd.CommandText = "SELECT '" + premiumdays + "' FROM account where username='" + UsernameText.Text + "' AND password='" + PasswordText.Text + "'";
            //cmd.CommandText = "SELECT * FROM account where username='" + UsernameText.Text + "' AND password='" + PasswordText.Text + "' AND premium='" + premiumdays + "'"; 
            dr = cmd.ExecuteReader();
            
            if (dr.Read())
            {
                // if ((premiumdays) >=1) { 


              if (MemoryReader.appRunning())

               
                {

                    MainMenu Menu = new MainMenu();
                        Menu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Start tibia first");
                    }
                    this.Close();
               /* }
                else
                {
                    MessageBox.Show("No Premium Days");
                }*/
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
            con.Close();

            new MemoryReader(0, 0, 0);
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
    }
}
