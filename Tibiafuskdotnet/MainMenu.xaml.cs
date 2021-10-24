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
using Tibiafuskdotnet;


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




        /// TODO make so its opening the window again when pressing ALT F12
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


        private void Extras_btn_Click_1(object sender, RoutedEventArgs e)
        {
            ExtrasMenu Extraskey = new ExtrasMenu();
            Extraskey.Show();
        }

        private void hpValue_Click(object sender, RoutedEventArgs e)
        {
            //fix it so its working
           // MemoryReader.readValuesFromMemory.hpValue();
            MessageBox.Show("hpValue");
        }

        private void Help_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The main panel has several subsections that contain settings related to them within.This panel can be brought at any time by pressing 'Shift+F12'.A lighthack is also available to you and can be toggled by pressing 'Shift+F11'.When changing settings, it is IMPORTANT that you realise that you need to hit the 'Save' button on the main panel for them to apply and become active in game.Also, each character has 5 save slots available to him.There isn't just 5 slots for all your characters.Some bot function work straight from the interface, but for most others you will have to operate them through hotkeys and shortkeys.There is a wizard for creating those and you can also visit the forums and website for more examples.");
        }
    }
}
