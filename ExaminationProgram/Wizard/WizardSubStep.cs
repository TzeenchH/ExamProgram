using ExaminationProgram.Helpers;
using ExaminationProgram.Interfaces;

namespace ExaminationProgram.Wizard
{
    public class WizardSubStep : ObservableBase,
                 ISelectable, ICompleted, IReadOnly,
                 IHasName, IHasError, IHasDescription
    {
        private string name;
        private string description;
        private bool isReadOnly;
        private bool isCompleted;
        private bool isSelected;
        private string isError;

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
        public bool IsCompleted
        {
            get => isCompleted;
            set => SetValue(ref isCompleted, value);
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
    }
}
