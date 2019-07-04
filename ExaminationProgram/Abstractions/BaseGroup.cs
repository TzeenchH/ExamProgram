using System.Collections.Generic;
using ExaminationProgram.Interfaces;
using ExaminationProgram.Helpers;

namespace ExaminationProgram.Abstractions
{
    public abstract class BaseGroup : ObservableBase, IHasName, IFiltering 
    {
        private IList<ISetting> settings;
        private string name;
        public string Name
        {
            get => name;
            set => SetValue(ref name, value);
        }
        public IList<ISetting> Settings
        {
            get => settings;
            set => SetValue(ref settings, value);
        }
        public BaseGroup(string name)
            => Name = name;
        public void FindSetting(string key)
        {
            foreach (var Setting in Settings)
            {
                if (string.IsNullOrEmpty(key))
                {
                    Setting.Visible = true;
                }
                else if (!Setting.Name.ToLowerInvariant().Contains(key.ToLowerInvariant()))
                {
                    Setting.Visible = false;
                }
            }
        }

    }
}
