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

            UhRuneHealth.Text = data.UhRuneHealth.ToString();
            SpellLoHealth.Text = data.SpellLoHealth.ToString();
            SpellHiHealth.Text = data.SpellHiHealth.ToString();
            SpellHiMana.Text = data.SpellHiMana.ToString();
            SpellLoMana.Text = data.SpellLoMana.ToString();
            cmbHotkey.ItemsSource = Helper.GetKeys();
            cmbHotkey.SelectedItem= data.SpellHitext;
            cmb2Hotkey.ItemsSource = Helper.GetKeys();
            cmb2Hotkey.SelectedItem = data.SpellLotext;
            cmb3Hotkey.ItemsSource = Helper.GetKeys();
            cmb3Hotkey.SelectedItem = data.UhRunetext;
           // cmb4hotkey.SelectedItem = Helper.TempHpPotiontext;
           // cmb4Hotkey.SelectedItem = data.TempHpPotiontext;
            cmb5Hotkey.ItemsSource = Helper.GetKeys();
            cmb5Hotkey.SelectedItem = data.ManaPotiontext;

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

            Helper.TempSpellHiHealth = Convert.ToInt32(SpellHiHealth.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                SpellHiHealth.Text = "0";
            }
        }

        private void SpellHiMana_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

            
            Helper.TempSpellHiMana = Convert.ToInt32(SpellHiMana.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                Helper.TempSpellHitext = cmbHotkey.SelectedItem as string;
                Helper.TempSpellLotext = cmb2Hotkey.SelectedItem as string;
                Helper.TempUhRunetext = cmb3Hotkey.SelectedItem as string;
               // Helper.TempHpPotiontext = (string)cmb4Hotkey;
                Helper.TempManaPotiontext = (string)cmb5Hotkey.SelectedItem;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SpellLohealth_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                Helper.TempSpellLoHealth = Convert.ToInt32(SpellLoHealth.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                SpellLoHealth.Text = "0";
            }
        }

        private void SpellLoMana_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {


                Helper.TempSpellLoMana = Convert.ToInt32(SpellLoMana.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                SpellLoMana.Text = "0";
            }
        }

        private void UHRuneHealth_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                Helper.TempUhRuneHealth = Convert.ToInt32(UhRuneHealth.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                UhRuneHealth.Text = "0";
            }
        }

        private void HPPotionHealth_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ManapotionText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {


                Helper.TempManaPotion = Convert.ToInt32(ManapotionText.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ManapotionText.Text = "0";
            }
        }
    }
}