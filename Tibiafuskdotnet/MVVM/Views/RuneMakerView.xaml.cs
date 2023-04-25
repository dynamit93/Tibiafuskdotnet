using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tibiafuskdotnet.MVVM.ViewModel;

namespace Tibiafuskdotnet.MVVM.Views
{
    public partial class RuneMakerView : Window
    {
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
                runeaaa.TargetWindow = MainMenu.CharacterWindows[MemoryReader.c.Player.Id];

                await Task.Run(() =>
                {
                    while (!runeaaa.RuneMakerCancellationTokenSource.Token.IsCancellationRequested)
                    {
                        if (MemoryReader.c.Player.Mana >= runeaaa.RuneMakerManaverb)
                        {
                            runeaaa.RuneMaker(runeaaa.TargetWindow);
                        }

                        Thread.Sleep(1000);
                    }
                });
            }
        }




        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ViewModel.RuneMakerViewModel runeaaa = DataContext as ViewModel.RuneMakerViewModel;
            runeaaa.RuneMakerCancellationTokenSource.Cancel();
        }


    }
}
