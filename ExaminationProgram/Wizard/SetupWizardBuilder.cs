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

        public void ConfigureWizard()
        {
            Configure(setupWizard.WizardSteps);
        }
        public void Configure(IList<BaseWizardStep> bases)
        {
            
            for (int i = 0; i < bases.Count; i++)
            {
                if (bases[i] is WizardStepGroup group)
                {
                    Configure(group.Children);
                }
                else
                {
                    if (i == 0 && bases.Count!=1)
                    {
                        bases[i].PrevStep = null;
                        bases[i].NextStep = bases[++i];
                    }
                    else if (i>0 && i == bases.Count)
                    {
                        bases[i].PrevStep = bases[--i];
                        bases[i].NextStep = null;
                    }
                    else if (i>0 && i<bases.Count)
                    {
                        bases[i].PrevStep = bases[--i];
                        bases[i].NextStep = bases[++i];
                    }
                }                  
            }
        }       
    }
}
