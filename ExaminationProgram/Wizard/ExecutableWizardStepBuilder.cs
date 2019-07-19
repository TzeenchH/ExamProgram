using ExaminationProgram.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProgram.Wizard
{
    public class ExecutableWizardStepBuilder : WizardStepBuilder<ExecutableWizardStep, ExecutableWizardStepBuilder>
    {
        
        public ExecutableWizardStepBuilder()
        {
            executedWizardStep = new ExecutableWizardStep();
        }

        public ExecutableWizardStepBuilder SetNextStep(BaseWizardStep nextStep)
        {
            executedWizardStep.NextStep = nextStep;
            return this;
        }
        public ExecutableWizardStepBuilder SetPrevStep(BaseWizardStep prevStep)
        {
            executedWizardStep.PrevStep = prevStep;
            return this;
        }
        public ExecutableWizardStepBuilder Last(bool last)
        {
            executedWizardStep.IsLast = last;
            return this;
        }

        public ExecutableWizardStep Build()
        {
            return executedWizardStep;
        }
        public static ExecutableWizardStepBuilder CreateBuilder()
        {
            return new ExecutableWizardStepBuilder();
        }
    }
}
