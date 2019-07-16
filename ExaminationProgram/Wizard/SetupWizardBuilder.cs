using ExaminationProgram.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProgram.Wizard
{
    public class SetupWizardBuilder
    {        
        protected SetupWizard setupWizard {get; set;}

        public SetupWizardBuilder()
        {
            setupWizard = new SetupWizard() { WizardSteps = new ObservableCollection<BaseWizardStep>() };
           
        }


        public SetupWizardBuilder AddStep(BaseWizardStep baseWizardStep)
        {
            setupWizard.WizardSteps.Add(baseWizardStep);
            return this;
        }

        public SetupWizardBuilder ConfigureWizard()
        {
            Configure(setupWizard.WizardSteps, setupWizard.WizardSteps[1]);
            return this;
        }
        public void Configure(IList<BaseWizardStep> bases, BaseWizardStep nstep)
        {
            int k;            
            for (int i = 0; i < bases.Count; i++)
            {
                
                if (bases[i] is WizardStepGroup group)
                {  
                    if (bases.GetType() == typeof(ObservableCollection<BaseWizardStep>) && i < bases.Count - 1) { nstep = bases[i+1]; }
                    else if (bases.GetType() == typeof(ObservableCollection<BaseWizardStep>) && i == bases.Count - 1) { nstep = null; }
                    group.HasChildren = true;
                    bases[i].NextStep = group.Children[0];
                    group.Children[0].PrevStep = bases[i];                   
                    if (i > 0)
                    {
                        bases[i].PrevStep = bases[i-1];
                    }
                    if (i > 0 && i < bases.Count-1)
                    {
                        bases[i].NextStep = bases[i+1];
                    }                                       
                    for (int j = 0; j < group.Children.Count; j++)
                    {
                        group.Children[j].Parent = group;
                    }
                    Configure(group.Children, nstep);
                }
                else if (bases[i] is ExecutableWizardStep step)
                {
                    if (bases.Count == 1)
                    {
                        step.NextStep = nstep;
                    }
                    if (i > 0 && i < bases.Count-1 && bases.Count != 1)
                    {
                        step.PrevStep = bases[i-1];
                        step.NextStep = bases[i+1];
                    }
                    else if (i == 0 && i < bases.Count && bases.Count != 1)
                    {
                        step.NextStep = bases[i+1];
                    }
                    else if (i > 0 && i == bases.Count - 1)
                    {
                        step.PrevStep = bases[i-1];
                        step.NextStep = nstep;
                    }
                }
            }
            setupWizard.SelectedStep = bases[0];
        }                                     
        public SetupWizard Build()
        {
            return setupWizard;
        }
    }
}
