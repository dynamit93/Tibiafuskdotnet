using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Media;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tibiafuskdotnet.BL;

namespace Tibiafuskdotnet
{
    /// <summary>
    /// Interaction logic for TargetMenu.xaml
    /// </summary>
    public partial class TargetMenu : INotifyPropertyChanged
    {



        List<Targeting> ListTargeting = new List<Targeting>();

        public TargetMenu()
        {
            
            DataContext = this;
            InitializeComponent();

            ListTargeting.Add(new Targeting() { Name = "Monster" });
            listBoxTargettingName.ItemsSource = ListTargeting;
        }

 

        private void listBoxTargettingName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        
        private void TargetNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.listBoxTargettingName.Items.Refresh();
        }


        

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        

        private int _ListOrder;
        public int ListOrder
        {
            get { return _ListOrder; }
            set
            {
                if (_ListOrder != value)
                {
                    _ListOrder = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _HealthTarget;
        public int HealthTarget
        {
            get { return _HealthTarget; }
            set
            {
                if (_HealthTarget != value)
                {
                    _HealthTarget = value;
                    OnPropertyChanged();
                }
            }
        }


        private int _ProximityTarget;
        public int ProximityTarget
        {
            get { return _ProximityTarget; }
            set
            {
                if (_ProximityTarget != value)
                {
                    _ProximityTarget = value;
                    OnPropertyChanged();
                }
            }
        }


        private int _DangerTarget;
        public int DangerTarget
        {
            get { return _DangerTarget; }
            set
            {
                if (_DangerTarget != value)
                {
                    _DangerTarget = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _RandomTarget;
        public int RandomTarget
        {
            get { return _RandomTarget; }
            set
            {
                if (_RandomTarget != value)
                {
                    _RandomTarget = value;
                    OnPropertyChanged();
                }
            }
        }


        private int _StickTarget;
        public int StickTarget
        {
            get { return _StickTarget; }
            set
            {
                if (_StickTarget != value)
                {
                    _StickTarget = value;
                    OnPropertyChanged();
                }
            }
        }




        private int _ReachableTarget;
        public int ReachableTarget
        {
            get { return _ReachableTarget; }
            set
            {
                if (_ReachableTarget != value)
                {
                    _ReachableTarget = value;
                    OnPropertyChanged();
                }
            }
        }


        private int _ShootableTarget;
        public int ShootableTarget
        {
            get { return _ShootableTarget; }
            set
            {
                if (_ShootableTarget != value)
                {
                    _ShootableTarget = value;
                    OnPropertyChanged();
                }
            }
        }


        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {



            //ListTargeting<Targeting>.Items.RemoveAt(ListTargeting.SelectedIndex);
            /// ListTargeting.Remove(new Targeting() { Name = ListTargeting.selectedItems });


            /*String ListOrderstring = ListOrder.ToString();
            String HealthTargetstring = HealthTarget.ToString();         
            String ProximityTargetstring = ProximityTarget.ToString();
            String DangerTargetstring = RandomTarget.ToString();
            String RandomTargetstring = RandomTarget.ToString();
            String StickTargetstring = StickTarget.ToString();
            String ReachableTargetstring = ReachableTarget.ToString();
            String ShootableTargetstring = ShootableTarget.ToString();
            MessageBox.Show( "ListOrder = " + ListOrderstring + "\n" + "HealthTarget = " + HealthTargetstring + "\n" + "ProximityTarget  = " + ProximityTargetstring + "\n" + "DangerTarget  = " + DangerTargetstring + "\n" + "RandomTarget  = " + RandomTargetstring + "\n" + "StickTarget  = " + StickTargetstring + "\n" + "ReachableTarget = " + ReachableTargetstring + "\n" + "ShootableTarget = " + ShootableTargetstring + "\n");
            */

        }

        private SoundPlayer Player = new SoundPlayer();

        private void  CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            Player.SoundLocation = @"./sounds/monster.wav";
            Player.PlayLooping();
        }

        private void playAlram_Unchecked(object sender, RoutedEventArgs e)
        {
            Player.Stop();
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            ListTargeting.Add(new Targeting() { Name = TargetNameTextBox.Text });
            this.listBoxTargettingName.Items.Refresh();
        }
    }




   /* public class Targeting
    {

        public string Name { get; set; }
        public override string ToString()
        {
            return this.Name;
        }


        
    }*/
    
}
