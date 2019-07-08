using ExaminationProgram.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProgram.Wizard
{
    public class Wizard : ObservableBase
    {
        private WizardStep selectedStep;

        public ObservableCollection<WizardStep> WizardSteps { get; set; }

        public Wizard(ContextMediator contextMediator)
        {
            WizardSteps = new ObservableCollection<WizardStep>();
        }

        WizardStep SelectedStep
        { get => selectedStep; set => selectedStep = value; }

    }
}
