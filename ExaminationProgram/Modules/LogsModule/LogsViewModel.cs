using ExaminationProgram.Abstractions;

namespace ExaminationProgram.Modules.LogsModule
{
    public class LogsViewModel : BaseViewModel
    {
        public LogsViewModel(string title, string iconName, ContextMediator contextMediator) : base(title, iconName, contextMediator)
        {
        }
    }
}
