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
                SelectedStep = SelectedStep.NextStep;
            }, () => SelectedStep.NextStep != null);
            PreviousStepCommand = new DelegateCommand(() =>
            {
                SelectedStep = SelectedStep.PrevStep;
            }, () => SelectedStep.PrevStep != null);
        }

        public BaseWizardStep SelectedStep
        {
            get => selectedStep;
            set => SetValue(ref selectedStep, value);
        }
        //public void Configure (IList<BaseWizardStep> bases)
        //{
        //    int count = bases.Count;
        //    for (int i = 0; i <= count; i++)
        //    {
        //        if (bases[i] is WizardStepGroup group)
        //        {
        //            Configure(group.Children);
        //        }
        //        else
        //        {
        //            if (i == 0)
        //            {
        //                bases[i].PrevStep = null;
        //                bases[i].NextStep = bases[++i];
        //            }
        //            else if (i == bases.Count)
        //            {
        //                bases[i].PrevStep = bases[--i];
        //                bases[i].NextStep = null;
        //            }
        //            else
        //            { 
        //                bases[i].PrevStep = bases[--i];
        //                bases[i].NextStep = bases[++i];
        //            }
        //        }
                    

        //    }
        //}

        public static SetupWizardBuilder CreateBuilder()
        {
            return new SetupWizardBuilder();
        }

    }
}
