using ExaminationProgram.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProgram.Wizard
{
    public class WizardStepGroupBuilder : WizardStepBuilder<WizardStepGroup, WizardStepGroupBuilder>
    {
        public WizardStepGroupBuilder()
        {
            executedWizardStep = new WizardStepGroup() { Children = new List<BaseWizardStep>(), BoundedSteps = new List<BaseWizardStep>() };
        }
        public WizardStepGroupBuilder AddChildren (BaseWizardStep childWizardStep)
        {
            executedWizardStep.Children.Add(childWizardStep);
            return this;
        }             
        public WizardStepGroup Build()
        {
            return executedWizardStep;
        }

    }
}
