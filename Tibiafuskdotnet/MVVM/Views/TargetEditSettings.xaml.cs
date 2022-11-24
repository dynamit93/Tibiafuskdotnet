using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tibiafuskdotnet.BL;
using Tibiafuskdotnet.ViewModel;
using Tibiafuskdotnet.MVVM.ViewModel;




namespace Tibiafuskdotnet.MVVM.Views
{
    /// <summary>
    /// Interaction logic for TargetEditSettings.xaml
    /// </summary>
    public partial class TargetEditSettings : Window
    {
        public TargetEditSettings()
        {
            InitializeComponent();
            this.DataContext = this;
            
        }

        private void MultiBinding_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MultiBinding_DpiChanged(object sender, DpiChangedEventArgs e)
        {

        }

         

        public void LoadTargetingbtn_Click(object sender, RoutedEventArgs e)
        {


            Targeting monster = TargetMenuViewModel.AddNewMonster();

            monster.Name = TargetEditSettingsViewModel.Loadtaragetscript<string>(TargetEditSettingsViewModel.temppath, "Name", 0);
            monster.Count = TargetEditSettingsViewModel.Loadtaragetscript<string>(TargetEditSettingsViewModel.temppath, "Count", 0);
            monster.Loot = TargetEditSettingsViewModel.Loadtaragetscript<bool>(TargetEditSettingsViewModel.temppath, "LootMonster", 0);
            monster.Alarm = TargetEditSettingsViewModel.Loadtaragetscript<bool>(TargetEditSettingsViewModel.temppath, "PlayAlarm", 0);
            monster.Setting = TargetEditSettingsViewModel.Loadtaragetscript<Int32>(TargetEditSettingsViewModel.temppath, "Setting", 0);
            monster.MinHp = TargetEditSettingsViewModel.Loadtaragetscript<Int32>(TargetEditSettingsViewModel.temppath, "Hpmin", 0);
            monster.MaxHp = TargetEditSettingsViewModel.Loadtaragetscript<Int32>(TargetEditSettingsViewModel.temppath, "Hpmax", 0);
            monster.MonsterAttackMode = TargetEditSettingsViewModel.Loadtaragetscript<string>(TargetEditSettingsViewModel.temppath, "MonsterAttacks", 0);
            monster.DangerLevel = TargetEditSettingsViewModel.Loadtaragetscript<Int32>(TargetEditSettingsViewModel.temppath, "Danger", 0);
            monster.StanceMode = TargetEditSettingsViewModel.Loadtaragetscript<string>(TargetEditSettingsViewModel.temppath, "Stance", 0);
            monster.ActionMode = TargetEditSettingsViewModel.Loadtaragetscript<string>(TargetEditSettingsViewModel.temppath, "ActionAttack", 0);
            monster.ActionModeSpell = TargetEditSettingsViewModel.Loadtaragetscript<string>(TargetEditSettingsViewModel.temppath, "ActionSpell", 0);
            monster.AttackMode = TargetEditSettingsViewModel.Loadtaragetscript<string>(TargetEditSettingsViewModel.temppath, "AttackMode", 0);
            monster.Ring = TargetEditSettingsViewModel.Loadtaragetscript<string>(TargetEditSettingsViewModel.temppath, "Ring", 0);


            TargetMenuViewModel.AddToList(monster);

/*
            foreach (var target in TargetMenuViewModel.)
            {
                TargetMenuViewModel.AddToList(monster);
            }
*/
        }

    }
}
