using System.Windows.Input;
using ExaminationProgram.Helpers;
using System.Collections.ObjectModel;

namespace ExaminationProgram.Wizard
{
    public class SetupWizard : ObservableBase
    {
        private WizardStep selectedStep;
        private ICommand nextStepCommand;
        private ICommand previousStepCommand;

        public ObservableCollection<WizardStep> WizardSteps { get; set; }
        public ICommand NextStepCommand
        {
            get => nextStepCommand;
            set => SetValue(ref nextStepCommand, value);
        }
        public ICommand PreviousStepCommand
        {
            get => previousStepCommand;
            set => SetValue(ref previousStepCommand, value);
        }
        public SetupWizard(ContextMediator contextMediator, params WizardStep[] wizardSteps )
        {
            WizardSteps = new ObservableCollection<WizardStep>(wizardSteps);
            //if (WizardSteps.Count==0)
            //{
            //    return;
            //}
            SelectedStep = WizardSteps[0];
            NextStepCommand = new DelegateCommand(() =>
            {
                SelectedStep = SelectedStep.NextStep;
            }, () => SelectedStep.NextStep != null);
            PreviousStepCommand = new DelegateCommand(() =>
            {
                SelectedStep = SelectedStep.PrevStep;
            }, () => SelectedStep.PrevStep != null);
        }

        public WizardStep SelectedStep
        {
            get => selectedStep;
            set => SetValue(ref selectedStep, value);
        }
    }
}
