using ExaminationProgram.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProgram.Helpers
{
    public static class SettingsHelpers
    {
        public static IList<ISetting> CloneSettings(IList<ISetting> source)
        {
            var clonedSettings = new List<ISetting>();

            foreach (var setting in source)
                clonedSettings.Add((ISetting)setting.Clone());

            return clonedSettings;
        }
    }
}
