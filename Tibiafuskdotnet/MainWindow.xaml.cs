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
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=test1;user=root;Pwd=benny123;SslMode=none");
            //Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;

        }


        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {

            string username = UsernameText.Text;
            string password = PasswordText.Text;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM account where username='" + UsernameText.Text + "' AND password='" + PasswordText.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (Class1.appRunning())
                {

                    MainMenu Menu = new MainMenu();
                    Menu.Show();
                }
                else
                {
                    MessageBox.Show("Start tibia first");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
            con.Close();
        }

        private void Forgotten_btn_Click(object sender, RoutedEventArgs e)
        {
            Forgottenpassword forgottenpassword = new Forgottenpassword();
            forgottenpassword.Show();
            this.Close();
        }
 
    
    }
}
