using ExaminationProgram.Interfaces;
using ExaminationProgram.Helpers;
using System;

namespace ExaminationProgram.Wizard
{
    public class WizardStep : ObservableBase, IHasIconName, IHasName, IHasDescription, IActive, ISelectable, IHasError, ICompleted
    {
        private string iconName;
        private string name;
        private string description;
        private bool isActive;
        private bool isSelected;
        private string isError;
        private bool isCompleted;

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
        public bool IsActive
        {
            get => isActive;
            set => SetValue(ref isActive, value);
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
            set => SetValue (ref isCompleted, value);
        }
        public Action<WizardStep, ContextMediator> ExecuteWizard { get; set; }
    }
}
