using System.Collections.Generic;
using ExaminationProgram.Interfaces;
using ExaminationProgram.Helpers;
using ExaminationProgram.Abstractions;

namespace ExaminationProgram.Modules.SettingsModule
{
    public class SettingsGroupsContainer : ObservableBase, IFiltering
    {
        private IList<BaseGroup> settingsGroups;

        public IList<BaseGroup> SettingsGroups
        {
            get => settingsGroups;
            set => SetValue(ref settingsGroups, value);
        }

        public SettingsGroupsContainer( params BaseGroup[] groupssettings )
        {
            SettingsGroups = new List<BaseGroup>(groupssettings);
        }

        public void FindSetting(string key)
        {
            foreach (var sg in SettingsGroups)
            {
                sg.FindSetting(key);
            }
        }
    }
}
