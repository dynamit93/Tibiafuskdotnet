using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Media;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tibiafuskdotnet.BL;
using Tibia;
using Tibia.Objects;
using System.Linq;

namespace Tibiafuskdotnet
{
    /// <summary>
    /// Interaction logic for TargetMenu.xaml
    /// </summary>
    public partial class TargetMenu : INotifyPropertyChanged
    {

        List<string> ListActions = new List<string>() {"Do Nothing", "Attack", "Follow" };
        List<string> listStanceMode = new List<string>() { "No Movemnet", "Melee - Approach" };

       
        List<Targeting> ListTargeting = new List<Targeting>();
        private string SelectedItemName = null;

        public TargetMenu()
        {

            DataContext = this;
            InitializeComponent();

            //ListTargeting.Add(new Targeting() { Name = "Trainer" });
            //listBoxTargettingName.ItemsSource = ListTargeting;
            //StanceMode.ItemsSource = listStanceMode;
            //ActionMode.ItemsSource = ListActions;




            Targeting obj = new Targeting()
            {
                MinHp = 0,
                Name = "abc",
                MaxHp = 100
                
        };
           // ListTargeting.Add(new Targeting() { Name = "Trainer" });
           // listBoxTargettingName.ItemsSource = ListTargeting;
           listBoxTargettingName.ItemsSource = obj.Name;
          TargetNameTextBox.Text = listBoxTargettingName.ItemsSource.ToString();
            System.Console.WriteLine(TargetNameTextBox.Text);
            StanceMode.ItemsSource = listStanceMode;
            ActionMode.ItemsSource = ListActions;


           
            DataContext = obj;



            OnPropertyChanged();

        }



        private void listBoxTargettingName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SelectedItemName = (e.AddedItems[0] as Targeting).Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            OnPropertyChanged();
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

            // this one works its remove everything.
            //ListTargeting.Clear();


            var index = ListTargeting.FindIndex(x => x.Name == SelectedItemName);
            ListTargeting.RemoveAt(index);
            this.listBoxTargettingName.Items.Refresh();



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

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
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
       int TargetHPBar;
        
        

        public void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

            
            

            foreach (var item in listBoxTargettingName.Items)
            {
                foreach (Creature C in MemoryReader.battleList.GetCreatures())
                {
                    TargetHPBar = C.HPBar;
                    if (item.ToString() == C.Name)
                    {
                        System.Console.WriteLine(TargetHPBar);
                        if (ActionMode.SelectedItem == "Attack") 
                                                
                        { 
                        if (TargetHPBar <= Helper.TargetingHpMin && TargetHPBar >= Helper.TargetingHpMax)
                            {
                                C.Attack();
                            }
                        }
                        else if (ActionMode.SelectedItem == "Follow")
                        {
                            if (TargetHPBar <= Helper.TargetingHpMin && TargetHPBar >= Helper.TargetingHpMax)

                            {
                                C.Follow();
                            }
                        }
                        if (StanceMode.ItemsSource == "Melee - Approach")

                        {
                            if (TargetHPBar <= Helper.TargetingHpMin && TargetHPBar >= Helper.TargetingHpMax)
                            {
                                C.Approach();
                            }
                            else { System.Console.WriteLine(StanceMode.ItemsSource); }
                        }





                        /* switch (ActionMode.SelectedItem)
                         {
                             case "Attack": 
                             case int TargetHPBar when (TargetHPBar <= Helper.TargetingHpMin && TargetHPBar >= Helper.TargetingHpMax):
                                 C.Attack();
                                 break;
                             case "Follow":
                                 C.Follow();
                                 break;
                         }*/
                    }
                }
            }
        }

        private void ActionMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Console.WriteLine("change action mode");
            

        }

        private void HpMinRange_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {

        }

        private void TargetingHpMin_TextChanged(object sender, TextChangedEventArgs e)
        {
            Helper.TargetingHpMin = Convert.ToInt32(TargetingHpMin.Text);
        }

        private void TargetingHpMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            Helper.TargetingHpMax = Convert.ToInt32(TargetingHpMax.Text);
        }

        private void ReachableCheckBox_Checked(object sender, RoutedEventArgs e)
        {
          
        }

        private void StanceMode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StanceMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }




    
}
