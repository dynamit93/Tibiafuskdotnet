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

namespace Tibiafuskdotnet
{
    /// <summary>
    /// Interaction logic for TargetMenu.xaml
    /// </summary>
    public partial class TargetMenu : INotifyPropertyChanged
    {
        
        public TargetMenu()
        {
            
            DataContext = this;
            InitializeComponent();
            List<Targeting> ListTargeting = new List<Targeting>()
                {

                new Targeting()
                {
                    Name = "john"
                }
            };
            this.listBoxTargettingName.ItemsSource = ListTargeting;
            
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
            String ListOrderstring = ListOrder.ToString();
            String HealthTargetstring = HealthTarget.ToString();         
            String ProximityTargetstring = ProximityTarget.ToString();
            String DangerTargetstring = RandomTarget.ToString();
            String RandomTargetstring = RandomTarget.ToString();
            String StickTargetstring = StickTarget.ToString();
            String ReachableTargetstring = ReachableTarget.ToString();
            String ShootableTargetstring = ShootableTarget.ToString();

            MessageBox.Show( "ListOrder = " + ListOrderstring + "\n" + "HealthTarget = " + HealthTargetstring + "\n" + "ProximityTarget  = " + ProximityTargetstring + "\n" + "DangerTarget  = " + DangerTargetstring + "\n" + "RandomTarget  = " + RandomTargetstring + "\n" + "StickTarget  = " + StickTargetstring + "\n" + "ReachableTarget = " + ReachableTargetstring + "\n" + "ShootableTarget = " + ShootableTargetstring + "\n");


        }


    }

    public class Targeting
    {

        public string Name { get; set; }
        public override string ToString()
        {
            return this.Name;
        }


        
    }
    
}
