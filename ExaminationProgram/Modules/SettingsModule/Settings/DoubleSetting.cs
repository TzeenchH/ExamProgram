using ExaminationProgram.Abstractions;

namespace ExaminationProgram.Modules.SettingsModule.Settings
{
    class DoubleSetting : BaseSetting<double>
    {
        public override object Clone()
        {
            var cloned = new DoubleSetting()
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
