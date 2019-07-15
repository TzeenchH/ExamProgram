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
            Configure(setupWizard.WizardSteps);
            return this;
        }
        public void Configure(IList<BaseWizardStep> bases)
        {
            int k;
            for (int i = 0; i < bases.Count; i++)               
            {
                k = i;
                if (bases[i] is WizardStepGroup group)
                {
                    group.HasChildren = true;
                    bases[i].NextStep = group.Children[0];
                    group.Children[0].PrevStep =bases[i];
                    if (i>0)
                    {
                        bases[k].PrevStep = bases[--k];
                    }
                    if (i >0 && i < bases.Count )
                    {
                        bases[k].NextStep = bases[++k];
                    }
                    for (int j =0; j<group.Children.Count; j++)
                    {
                        group.Children[j].Parent = group;                       
                    }

                    Configure(group.Children);
                }
                else if (bases[i] is ExecutableWizardStep step) 
                {         
                        if (i > 0 && i < bases.Count && bases.Count != 1)
                        {
                            step.PrevStep = bases[--k];
                            step.NextStep = bases[++k];
                        }
                        else if (i == 0 && i < bases.Count && bases.Count != 1)
                        {

                        step.NextStep = bases[++k];
                        }
                        else if (i > 0 && i == bases.Count-1)
                        {
                        step.PrevStep = bases[--k];                           
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
