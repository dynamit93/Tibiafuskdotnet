
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tibiafuskdotnet.MVVM.ViewModel;

namespace Tibiafuskdotnet.MVVM.Views
{
    /// <summary>
    /// Interaction logic for RuneMakerView.xaml
    /// </summary>
    public partial class RuneMakerView : Window
    {
        //public int RuneMakerManaverb { get; set; }
        //public int RuneMakerManaverb = 0;
        public RuneMakerView()
        {
            InitializeComponent();
            DataContext = new RuneMakerViewModel();
        }

        private async void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ViewModel.RuneMakerViewModel runeaaa = DataContext as ViewModel.RuneMakerViewModel;
            CheckBox checkBox = sender as CheckBox;

            if (checkBox.IsChecked == true)
            {
                runeaaa.RuneMakerCancellationTokenSource = new CancellationTokenSource();

                await Task.Run(() =>
                {
                    while (!runeaaa.RuneMakerCancellationTokenSource.Token.IsCancellationRequested)
                    {
                        if (MemoryReader.c.Player.Mana >= runeaaa.RuneMakerManaverb)
                        {
                            runeaaa.RuneMaker();
                        }

                        Thread.Sleep(1000);
                    }
                });
            }
            else
            {
                runeaaa.RuneMakerCancellationTokenSource.Cancel();
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var runeaaa = DataContext as ViewModel.RuneMakerViewModel;
            runeaaa.RuneMakerSpell = "";
        }
    }
}