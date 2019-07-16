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
<<<<<<< HEAD
                    group.HasChildren = true;
                    bases[i].NextStep = group.Children[0];
                    group.Children[0].PrevStep =bases[i];
                    if (i>0)
=======
                    Configure(group.Children);
                }
                else
                {
                    if (i == 0 && bases.Count!=1)
>>>>>>> 5194a59741eb7b90daa0a4dbeed2a34d78e45247
                    {
                        bases[k].PrevStep = bases[--k];
                    }
<<<<<<< HEAD
                    if (i >0 && i < bases.Count )
=======
                    else if (i>0 && i == bases.Count)
>>>>>>> 5194a59741eb7b90daa0a4dbeed2a34d78e45247
                    {
                        bases[k].NextStep = bases[++k];
                    }
<<<<<<< HEAD
                    for (int j =0; j<group.Children.Count; j++)
=======
                    else if (i>0 && i<bases.Count)
>>>>>>> 5194a59741eb7b90daa0a4dbeed2a34d78e45247
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
