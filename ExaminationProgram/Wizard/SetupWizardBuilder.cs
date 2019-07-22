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
            if (setupWizard.WizardSteps.Count == 1)
                Configure(setupWizard.WizardSteps, null);
            else if (setupWizard.WizardSteps.Count > 1)
                Configure(setupWizard.WizardSteps, setupWizard.WizardSteps[1]);
            return this;
        }
           public BaseWizardStep pstep = null;
        public void Configure(IList<BaseWizardStep> bases, BaseWizardStep nstep)
        {
            for (int i = 0; i < bases.Count; i++)
            {                
                if (bases[i] is WizardStepGroup group)
                {
                    var nextStep = i == bases.Count - 1 ? nstep : bases[i + 1] ;
                    group.StepsCount = group.Children.Count;
                    group.HasChildren = true;                  
                    bases[i].PrevStep = pstep;
                    bases[i].NextStep = group.Children[0];
                    group.Children[0].PrevStep = bases[i];
                    if (i > 0)
                    {
                        bases[i].PrevStep = bases[i-1];
                    }
                    for (int j = 0; j < group.Children.Count; j++)
                    {
                        group.Children[j].Parent = group;
                    }
                    Configure(group.Children, nextStep);
                }
                else if (bases[i] is ExecutableWizardStep step)
                {
                   if (step.Parent == null)
                        step.PrevStep = pstep;
                    if (bases.Count == 1)
                    {
                        step.NextStep = nstep;
                        if (step.Parent == null)
                            step.PrevStep = pstep;
                        pstep = step;
                    }
                    if (i > 0 && i < bases.Count-1 && bases.Count != 1)
                    {
                        step.NextStep = bases[i+1];
                        if (bases[i - 1] is WizardStepGroup)
                            step.PrevStep = pstep;
                        else
                        step.PrevStep = bases[i-1];
                    }
                    else if (i == 0 && i < bases.Count && bases.Count != 1)
                    {
                        step.NextStep = bases[i + 1];                      
                    }
                    else if (i > 0 && i == bases.Count - 1)
                    {
                        if (bases[i - 1] is WizardStepGroup)
                            step.PrevStep = pstep;
                        else
                            step.PrevStep = bases[i - 1];
                        pstep = step;
                        if (step.IsLast)
                            step.NextStep = null;
                        else
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
