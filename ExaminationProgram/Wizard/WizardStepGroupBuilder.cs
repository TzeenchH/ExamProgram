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
            executedWizardStep = new WizardStepGroup();
        }
        public WizardStepGroupBuilder AddChildren (BaseWizardStep childWizardStep)
        {
            executedWizardStep.Children.Add(childWizardStep);
            return this;
        }
        
        public WizardStepGroupBuilder Configure()
        {
            for (int i=0; i<=executedWizardStep.Children.Count; i++)
            {                
                executedWizardStep.Children[i].NextStep = executedWizardStep.Children[++i];
                executedWizardStep.Children[i].PrevStep = executedWizardStep.Children[--i];
                if (i == 0)
                { executedWizardStep.Children[0].PrevStep = null; }
                if (i == executedWizardStep.Children.Count)
                { executedWizardStep.Children[i].NextStep = null; }
            }
        }

        public WizardStepGroup Build()
        {
            return executedWizardStep;
        }

    }
}
