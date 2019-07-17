using System.Linq;
using System.Windows.Input;
using ExaminationProgram.Helpers;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace ExaminationProgram.Wizard
{
    public class SetupWizard : ObservableBase
    {
        private BaseWizardStep selectedStep;
        private ICommand nextStepCommand;
        private ICommand previousStepCommand;

        public ObservableCollection<BaseWizardStep> WizardSteps { get; set; }
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
        public SetupWizard()
        {
            NextStepCommand = new DelegateCommand(() =>
            {
                SelectedStep.IsCompleted = true;
                SelectedStep = SelectedStep.NextStep;
            }, () => SelectedStep.NextStep != null);
            PreviousStepCommand = new DelegateCommand(() =>
            {
                SelectedStep.IsCompleted = false;
                SelectedStep = SelectedStep.PrevStep;
            }, () => SelectedStep.PrevStep != null);
        }

        public BaseWizardStep SelectedStep
        {
            get => selectedStep;
            set => SetValue(ref selectedStep, value);
        }
        
        public static SetupWizardBuilder CreateBuilder()
        {
            return new SetupWizardBuilder();
        }

    }
}
