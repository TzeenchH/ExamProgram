using System.Linq;
using System.Windows.Input;
using ExaminationProgram.Helpers;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;
using ExaminationProgram.Interfaces;

namespace ExaminationProgram.Wizard
{
    public class SetupWizard : ObservableBase
    {
        private BaseWizardStep selectedStep;
        private ICommand nextStepCommand;
        private ICommand previousStepCommand;

        public static string ExecutedCounts = "1/3";
        private ICommand executeCommand;
        ContextMediator contextMediator;

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
        public ICommand ExecuteCommand
        {
            get => executeCommand;
            set => SetValue(ref executeCommand, value);
        }
        public SetupWizard()
        {

            NextStepCommand = new DelegateCommand(() =>
            {
                
                SelectedStep = SelectedStep.NextStep;
            }, () => SelectedStep.NextStep != null);
            PreviousStepCommand = new DelegateCommand(() =>
            {
                
                SelectedStep = SelectedStep.PrevStep;
            }, () => SelectedStep.PrevStep != null);

            ExecuteCommand = new DelegateCommand(()=>
            {
                try
                {
                    (SelectedStep as IExecutable<BaseWizardStep, ContextMediator, object>).ExecuteStep.Invoke(SelectedStep, contextMediator , null);
                    SelectedStep.IsCompleted = true;
                }
                catch (Exception)
                {
                    SelectedStep.IHasError = "sdddfde";
                    throw;
                }

            },()=> SelectedStep is ExecutableWizardStep);
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
