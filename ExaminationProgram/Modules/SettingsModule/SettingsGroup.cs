using System;
using System.Collections.Generic;
using ExaminationProgram.Interfaces;
using ExaminationProgram.Abstractions;
using System.Linq;

namespace ExaminationProgram.Modules.SettingsModule
{
   public  class SettingsGroup : BaseGroup
   {
       
        public SettingsGroup(string name, params ISetting[] settings) : base(name)
        {
            Name = name;
            Settings = new List<ISetting>(settings);
        }

    }
}
