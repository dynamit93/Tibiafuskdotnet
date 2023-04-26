using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tibiafuskdotnet.MVVM.ViewModel;
using Tibiafuskdotnet.ViewModel;
using System.Media;
using System.Windows;
using System.Windows.Threading;
using Tibia.Objects;
using Tibia.Exceptions;


namespace Tibiafuskdotnet.MVVM.Views
{
    public partial class RuneMakerView : Window
    {
        public RuneMakerView()
        {
            InitializeComponent();
            DataContext = new RuneMakerViewModel();
            Player.SoundLocation = @"../../sounds/monster.wav";
            Player.Load();
        }



        private uint? _lastPlayerX = null;
        private uint? _lastPlayerY = null;

        private CancellationTokenSource _monitorPlayerPositionCancellationTokenSource;

        private SoundPlayer Player = new SoundPlayer();
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


        private readonly object _soundLock = new object();
        private bool _isPlayingSound = false;

        private async Task MonitorPlayerPositionAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                uint currentPlayerX = MemoryReader.c.Player.X;
                uint currentPlayerY = MemoryReader.c.Player.Y;

                if (_lastPlayerX.HasValue && (currentPlayerX != _lastPlayerX.Value || currentPlayerY != _lastPlayerY.Value) && Alert.IsChecked == true)
                {
                    await Dispatcher.InvokeAsync(() =>
                    {
                        lock (_soundLock)
                        {
                            if (!_isPlayingSound)
                            {
                                _isPlayingSound = true;
                                Player.Stop();
                                Player.PlayLooping();
                            }
                        }
                    });
                }
                else
                {
                    lock (_soundLock)
                    {
                        if (_isPlayingSound)
                        {
                            _isPlayingSound = false;
                            Player.Stop();
                        }
                    }
                }

                _lastPlayerX = currentPlayerX;
                _lastPlayerY = currentPlayerY;
                await Task.Delay(1000);
            }
        }







        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ViewModel.RuneMakerViewModel runeaaa = DataContext as ViewModel.RuneMakerViewModel;
            runeaaa.RuneMakerCancellationTokenSource.Cancel();
        }




        private void Alert_Checked(object sender, RoutedEventArgs e)
        {
            _monitorPlayerPositionCancellationTokenSource = new CancellationTokenSource();
            MonitorPlayerPositionAsync(_monitorPlayerPositionCancellationTokenSource.Token);
        }

        private void Alert_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_monitorPlayerPositionCancellationTokenSource != null)
            {
                _monitorPlayerPositionCancellationTokenSource.Cancel();
            }
            Player.Stop();
        }


    }
}
