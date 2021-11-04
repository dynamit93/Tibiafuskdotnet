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

            SpellLoHealth.Text = data.SpellLoHealth.ToString();
            SpellHiHealth.Text = data.SpellHiHealth.ToString();
            SpellHiMana.Text = data.SpellHiMana.ToString();
            SpellLoMana.Text = data.SpellLoMana.ToString();
            cmbHotkey.ItemsSource = Helper.GetKeys();
            cmbHotkey.SelectedItem= data.SpellHitext;
            cmb2Hotkey.ItemsSource = Helper.GetKeys();
            cmb2Hotkey.SelectedItem = data.SpellLotext;

        }


        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public void Healingkey_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void SpellHiHealth_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

            Helper.SpellHiHealth = Convert.ToInt32(SpellHiHealth.Text);
                Helper.WriteToFile();

            }
            catch (Exception ex)
            {
                SpellHiHealth.Text = "0";
            }
        }

        private void SpellHiMana_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

            
            Helper.SpellHiMana = Convert.ToInt32(SpellHiMana.Text);
                Helper.WriteToFile();

            }
            catch (Exception ex)
            {
                SpellHiMana.Text = "0";
            }
        }

        private void lost(object sender, RoutedEventArgs e)
        {
           // Helper.WriteToFile();
        }

        private void Healingkey_TextChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                Helper.SpellHitext = cmbHotkey.SelectedItem as string;
                Helper.SpellLotext = cmb2Hotkey.SelectedItem as string;
                Helper.WriteToFile();

            }
            catch (Exception ex)
            {

            }
        }

        private void SpellLohealth_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                Helper.SpellLoHealth = Convert.ToInt32(SpellLoHealth.Text);
                Helper.WriteToFile();

            }
            catch (Exception ex)
            {
                SpellLoHealth.Text = "0";
            }
        }

        private void SpellLoMana_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {


                Helper.SpellLoMana = Convert.ToInt32(SpellLoMana.Text);
                Helper.WriteToFile();

            }
            catch (Exception ex)
            {
                SpellLoMana.Text = "0";
            }
        }
    }
}