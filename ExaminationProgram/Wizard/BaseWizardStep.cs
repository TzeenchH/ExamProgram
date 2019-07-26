using ExaminationProgram.Interfaces;
using ExaminationProgram.Helpers;
using System.Collections.Generic;

namespace ExaminationProgram.Wizard
{
    public abstract class BaseWizardStep : ObservableBase,
                    IHasIconName, IHasName, IHasDescription,
                    IReadOnly, ISelectable, ICanHasError, ICompleted,
                    ILinkedInstance<BaseWizardStep>, IHasParent,
                    IHasBoundedSteps
    {
        private string iconName;
        private string name;
        private string description;
        private bool isReadOnly;
        private bool isSelected;
        private string isError;
        private bool isCompleted;
        private BaseWizardStep prevStep;
        private BaseWizardStep nextStep;
        private object parent;
        private IList<BaseWizardStep> boundedSteps;

        public IList<BaseWizardStep> BoundedSteps
        {
            get => boundedSteps;
            set => SetValue(ref boundedSteps, value);
        }
        public string IconName
        {
            get => iconName;
            set => SetValue(ref iconName, value);
        }
        public string Name
        {
            get => name;
            set => SetValue(ref name, value);
        }
        public string Description
        {
            get => description;
            set => SetValue(ref description, value);
        }
        public bool IsReadOnly
        {
            get => isReadOnly;
            set => SetValue(ref isReadOnly, value);
        }
        public bool IsSelected
        {
            get => isSelected;
            set => SetValue(ref isSelected, value);
        }
        public string IHasError
        {
            get => isError;
            set => SetValue(ref isError, value);
        }
        public bool IsCompleted
        {
            get => isCompleted;
            set => SetValue(ref isCompleted, value);
        }

        public BaseWizardStep PrevStep
        {
            get => prevStep;
            set => SetValue(ref prevStep, value);
        }
        public BaseWizardStep NextStep
        {
            get => nextStep;
            set => SetValue(ref nextStep, value);
        }

        public object Parent
        {
            get => parent;
            set => SetValue(ref parent, value);
        }
    }
}
