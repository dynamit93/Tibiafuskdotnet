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
using Tibiafuskdotnet.BL;

namespace Tibiafuskdotnet
{

    public partial class HealingMenu : Window
    {
       
        public HealingMenu()
        {
            InitializeComponent();
            this.DataContext = this;
            var data = Helper.ReadFromFile();
            if (data == null)
                data = new Cheat();
            Helper.SpellHiHealth = data.SpellHiHealth;
            Helper.SpellHiMana = data.SpellHiMana;
            Helper.SpellHitext = data.SpellHitext;

        }


        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public void Healingkey_TextChanged(object sender, TextChangedEventArgs e)
        {
            Helper.SpellHitext = Convert.ToInt32(SpellHitext.Text);
        }

        private void SpellHiHealth_TextChanged(object sender, TextChangedEventArgs e)
        {
            Helper.SpellHiHealth = Convert.ToInt32(SpellHiHealth.Text);
        }

        private void SpellHiMana_TextChanged(object sender, TextChangedEventArgs e)
        {
            Helper.SpellHiMana = Convert.ToInt32(SpellHiMana.Text);
        }

        private void lost(object sender, RoutedEventArgs e)
        {
            Helper.WriteToFile();
        }
    }
}
