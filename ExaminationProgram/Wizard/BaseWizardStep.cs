using ExaminationProgram.Interfaces;
using ExaminationProgram.Helpers;
using System;

namespace ExaminationProgram.Wizard
{
    public abstract class BaseWizardStep : ObservableBase,
                    IHasIconName, IHasName, IHasDescription,
                    IReadOnly, ISelectable, IHasError, ICompleted,
                    ILinledInstance<BaseWizardStep>, IHasParent
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
        public string IsError
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
