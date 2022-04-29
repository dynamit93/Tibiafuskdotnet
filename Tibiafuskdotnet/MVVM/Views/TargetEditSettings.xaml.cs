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
            this .DataContext = this;
        }

        private void MultiBinding_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MultiBinding_DpiChanged(object sender, DpiChangedEventArgs e)
        {

        }

        private void LoadTargetingbtn_Click(object sender, RoutedEventArgs e)
        {

            Targeting monster = TargetMenuViewModel.AddNewMonster();
            //Dennis att göra
            monster.Name = TargetEditSettingsViewModel.Loadtaragetscript(TargetEditSettingsViewModel.temppath,"Name",0);
            monster.Count = Int32.Parse(TargetEditSettingsViewModel.Loadtaragetscript(TargetEditSettingsViewModel.temppath, "Count", 0));
            string yes = "True"; // https://stackoverflow.com/questions/49590754/convert-string-to-boolean-in-c-sharp
            monster.Loot = Boolean.Parse(TargetEditSettingsViewModel.Loadtaragetscript(TargetEditSettingsViewModel.temppath, "LootMonster", 0));
            monster.Alarm = Boolean.Parse(TargetEditSettingsViewModel.Loadtaragetscript(TargetEditSettingsViewModel.temppath, "PlayAlarm", 0));
            monster.Setting = Int32.Parse(TargetEditSettingsViewModel.Loadtaragetscript(TargetEditSettingsViewModel.temppath, "Setting", 0));
            monster.MinHp = Int32.Parse(TargetEditSettingsViewModel.Loadtaragetscript(TargetEditSettingsViewModel.temppath, "Hpmin", 0));
            monster.MaxHp = Int32.Parse(TargetEditSettingsViewModel.Loadtaragetscript(TargetEditSettingsViewModel.temppath, "Hpmax", 0));
            monster.MonsterAttackMode = TargetEditSettingsViewModel.Loadtaragetscript(TargetEditSettingsViewModel.temppath, "MonsterAttacks", 0);
            monster.DangerLevel = Int32.Parse(TargetEditSettingsViewModel.Loadtaragetscript(TargetEditSettingsViewModel.temppath, "Danger", 0));
            monster.StanceMode = TargetEditSettingsViewModel.Loadtaragetscript(TargetEditSettingsViewModel.temppath, "Stance", 0);
            monster.ActionMode = TargetEditSettingsViewModel.Loadtaragetscript(TargetEditSettingsViewModel.temppath, "ActionAttack", 0);
            monster.ActionModeSpell = TargetEditSettingsViewModel.Loadtaragetscript(TargetEditSettingsViewModel.temppath, "ActionSpell", 0);
            monster.AttackMode = TargetEditSettingsViewModel.Loadtaragetscript(TargetEditSettingsViewModel.temppath, "AttackMode", 0);
            monster.Ring = TargetEditSettingsViewModel.Loadtaragetscript(TargetEditSettingsViewModel.temppath, "Ring", 0);




        }
    }
}
