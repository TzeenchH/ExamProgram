using ExaminationProgram.Helpers;

namespace ExaminationProgram.Abstractions
{
    public abstract class BaseViewModel : ObservableBase, IHasTitle
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
