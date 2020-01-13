using ExaminationProgram.Abstractions;

namespace ExaminationProgram.Modules.SettingsModule.Settings
{
    class IntSetting:BaseSetting<int>
    {
        public override object Clone()
        {
            var cloned = new IntSetting()
            {
                Dimention = Dimention,
                Name = Name,
                Value = Value,
                Visible = Visible,
            };
            return cloned;
        }
    }
}
