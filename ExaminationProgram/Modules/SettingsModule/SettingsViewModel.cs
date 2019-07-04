using System.Windows.Input;
using ExaminationProgram.Helpers;
using System.Collections.Generic;
using ExaminationProgram.Interfaces;
using ExaminationProgram.Abstractions;

namespace ExaminationProgram.Modules.SettingsModule
{
    public class SettingsViewModel : BaseViewModel
    {
        private string findSetting;
        private ICommand clearCommand;
        public IList<BaseGroup> groups;
        private ISetting selectedSetting;

        public ICommand ClearCommand
        {
            get => clearCommand;
            set => SetValue(ref clearCommand, value);
        }

        public IList<BaseGroup> Groups
        {
            get => groups;
            set => SetValue(ref groups, value);
        }

        public SettingsViewModel(string title, string iconName, ContextMediator contextMediator) : base(title, iconName, contextMediator)
        {
            ClearCommand = new DelegateCommand(() =>
            FindSetting = null);
        }

        public ISetting SelectedSetting
        {
            get => selectedSetting;
            set 
            {
                SetValue(ref selectedSetting, value);               
            }
        }
        public string FindSetting
        {
            get => findSetting;
            set
            {
                findSetting = value;
                foreach (var item in Groups)
                {
                    item.FindSetting(findSetting);
                }
                OnPropertyChanged();
            }
        }
    }
}
