using ExaminationProgram.Helpers;
using ExaminationProgram.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ExaminationProgram.Wizard
{
    public class WizardStepGroup : BaseWizardStep, IHasChildren<BaseWizardStep>
    {
        private IList<BaseWizardStep> children;
        private bool hasChildren;
        private int stepsCount;
        private bool isCompleted;
        private string hasError;

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
        public new bool IsCompleted
        {
            get => isCompleted;
            set
            {
                if (this.Children.All(s => s.IsCompleted == true))
                    isCompleted = true;
                else isCompleted = false;
                OnPropertyChanged(nameof(isCompleted));
                OnPropertyChanged(nameof(this.Children));
            }
        }

        public new string HasError
        {
            get => hasError;
            set
            {
                if (this.Children.Any(s => string.IsNullOrEmpty(s.HasError) == false))
                    hasError = "Error";
                OnPropertyChanged(nameof(hasError));
                OnPropertyChanged(nameof(this.Children));
            }
        }

        public static WizardStepGroupBuilder CreateBuilder()
        {
            return new WizardStepGroupBuilder();
        }


    }
}
