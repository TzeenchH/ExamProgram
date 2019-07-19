using ExaminationProgram.Helpers;
using ExaminationProgram.Interfaces;
using System.Collections.Generic;

namespace ExaminationProgram.Wizard
{
    public class WizardStepGroup : BaseWizardStep, IHasChildren<BaseWizardStep>
    {
        private IList<BaseWizardStep> children;
        private bool hasChildren;
        private int stepsCount;
        private string executedCounts;
        private int i = 0;

        public string ExecutedCounts
        {
            get => executedCounts;
            set
            {
                executedCounts = $" {i}/3";
                SetValue(ref executedCounts, value);
            }
        }

        public int StepsCount
        {
            get => stepsCount;
            set => SetValue(ref stepsCount, value);
        }
        public IList<BaseWizardStep> Children
        {
            get => children;
            set => SetValue(ref children, value);
        }
        public bool HasChildren
        {
            get => hasChildren;
            set => SetValue(ref hasChildren, value);
        }
        public static WizardStepGroupBuilder CreateBuilder()
        {
            return new WizardStepGroupBuilder();
        }


    }
}
