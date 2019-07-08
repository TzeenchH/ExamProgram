using ExaminationProgram.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProgram.Abstractions
{
    public abstract class BaseCalibrationStep : ObservableBase
    {
        private string name;
        private IList<string> calibratedParemetres;

        string Name
        {
            get => name;
            set => SetValue(ref name, value);
        }

        public IList<string> CalibratedParemetres
        {
            get => calibratedParemetres;
            set => SetValue (ref calibratedParemetres, value);
        }

        public BaseCalibrationStep(string name)
            => Name = name;
    }
}
