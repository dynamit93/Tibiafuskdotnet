using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tibia_Bot_Project;

namespace Tibiafuskdotnet
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : INotifyPropertyChanged
    {

        private readonly RoutedCommand command = new RoutedCommand();
        public MainMenu()
        {

            DataContext = this;
            InitializeComponent();
            //this.KeyDown += new KeyEventHandler(BankView_KeyDown);
            CommandBinding cb = new CommandBinding(command, OnCommand);
            this.CommandBindings.Add(cb);

            KeyBinding kb = new KeyBinding(command, Key.F12, ModifierKeys.Alt);
            this.InputBindings.Add(kb);
        }




        /// TODO gör att den öppnar Fönstret när man klickar igen ALT F12
        private void OnCommand(object sender, EventArgs e)
        {
            MainMenu window = new MainMenu();

            if (window.ShowActivated)
            {
                this.Hide();

            }
            else
            {
                window.Show();
            }
        }



       

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }

        

        private int _maxhp = 1;
        public int Maxhp


        {
            get { return _maxhp; }
            set
            {
                if (_maxhp != value)
                {
                    _maxhp = value;
                    OnPropertyChanged();
                }
            }
        }

    

        private void Healing_btn_Click(object sender, RoutedEventArgs e)
        {
            HealingMenu Healingkey = new HealingMenu();
            Healingkey.Show();
        }

        private void Extras_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Extras_btn_Click_1(object sender, RoutedEventArgs e)
        {
            ExtrasMenu Extraskey = new ExtrasMenu();
            Extraskey.Show();
        }
    }
}
