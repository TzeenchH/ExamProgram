using System.Windows.Input;
using ExaminationProgram.Helpers;
using System.Collections.Generic;
using ExaminationProgram.Interfaces;
using ExaminationProgram.Abstractions;
using System.Collections.ObjectModel;
using System;

namespace ExaminationProgram.Modules.SettingsModule
{
    public class SettingsViewModel : BaseViewModel
    {
        private string findSetting;
        private ICommand clearCommand;
        private ICommand addValueCommand;
        public IList<BaseGroup> groups;
        private ISetting selectedSetting;
        private IList<ISetting> addedSettings;
        private ValueType vall;

        public ICommand ClearCommand
        {
            get => clearCommand;
            set => SetValue(ref clearCommand, value);
        }

        public ICommand AddValueCommand
        {
            get => addValueCommand;
            set => SetValue(ref addValueCommand, value);
        }

        public ValueType Vall
        {
            get => vall;
            set =>SetValue(ref vall, value);
        }
        public IList<BaseGroup> Groups
        {
            get => groups;
            set => SetValue(ref groups, value);
        }
        public IList<ISetting> AddedSettings
        {
            get => addedSettings;
            set => SetValue(ref addedSettings, value);
        }
        public SettingsViewModel(string title, string iconName, ContextMediator contextMediator, IList<BaseGroup> _groups) : base(title, iconName, contextMediator)
        {
            Groups = _groups;
            AddedSettings = new ObservableCollection<ISetting>();
            ClearCommand = new DelegateCommand(() =>
            FindSetting = null);
            AddValueCommand = new DelegateCommand(() =>
            {
                
            });
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
