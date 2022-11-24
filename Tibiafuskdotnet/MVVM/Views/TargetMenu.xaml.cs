using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tibiafuskdotnet.BL;
using Tibiafuskdotnet.ViewModel;
using System.IO;


namespace Tibiafuskdotnet.MVVM.Views
{
    /// <summary>
    /// Interaction logic for TargetMenu.xaml
    /// </summary>
    public partial class TargetMenu : Window
    {
        public TargetMenu()
        {
            InitializeComponent();





            // If folder TibiaCheat Under MyDocuments Dossen't exist it will create one.
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "TibiaCheat"))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TibiaCheat"));
            };

         
            // Find Files in Direcotry with fileformat .txt
            string[] fileArray = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TibiaCheat\\" + "*.txt.");
            //string[] fileArray = Directory.GetFiles(@"D:\Test\", "*.txt");
            // found Files Array moved into Listview (LoadTargetscript.ItemsSource)


            LoadTargetscriptlistview.ItemsSource = fileArray;

            
        }

        private void ReachableCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void Reachable_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void TargetNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TargetNameTextBox.Text=="<New Monster>")
            {
                TargetNameTextBox.Text = "";
            }
        }


        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
           
          
        }

        private void playAlram_Unchecked(object sender, RoutedEventArgs e)
        {
           // Player.Stop();
        }

        private void TargetingHpMin_TextChanged(object sender, TextChangedEventArgs e)
        {
            int.TryParse(TargetingHpMin.Text, out Helper.TargetingHpMax);

        }

        private void TargetingHpMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            int.TryParse(TargetingHpMax.Text, out Helper.TargetingHpMax);
        }

        private void StanceMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ActionMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CommonServiceLocator.ServiceLocator.Current.GetInstance<TargetMenuViewModel>().txtTargetName=this.TargetNameTextBox;
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void targeteditBtn_Click(object sender, RoutedEventArgs e)
        {
            MVVM.Views.TargetEditSettings tG = new MVVM.Views.TargetEditSettings();
            tG.ShowDialog();
            
        }

        private void LoadTargetingBtn_Click(object sender, RoutedEventArgs e)
        {
            //Load Selected Targeting Script from file Located fileArray
            string ReadTargetscriptseltectedpath = LoadTargetscriptlistview.SelectedItem.ToString();
            string path = ReadTargetscriptseltectedpath;
            string ReadTargetscript = System.IO.File.ReadAllText(path);
            MVVM.ViewModel.TargetEditSettingsViewModel.Loadtaragetscript<string>(path, "text", 0);
               
        }

        private void LoadTargetscript_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
