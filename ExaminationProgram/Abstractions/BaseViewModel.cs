using ExaminationProgram.Helpers;
using ExaminationProgram.Interfaces;

namespace ExaminationProgram.Abstractions
{
    public abstract class BaseViewModel : ObservableBase, IViewModel
    {
        protected ContextMediator contextMediator;
        private string title;
        private string iconName;

        public string Title
        {
            get => title;
            set => SetValue(ref title, value);
        }
        public string IconName
        {
            get => iconName;
            set => SetValue( ref iconName, value);
        }
        public BaseViewModel(string title, string iconName, ContextMediator contextMediator)
        {
            Title = title;
            IconName = iconName;
            this.contextMediator = contextMediator;
        }
           
    }
}
