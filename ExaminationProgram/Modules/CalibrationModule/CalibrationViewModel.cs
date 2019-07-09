using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using ExaminationProgram.Helpers;
using ExaminationProgram.Abstractions;
using ExaminationProgram.Modules.InstrumentalModule;
namespace ExaminationProgram.Modules.CalibrationModule
{
    public class CalibrationViewModel : BaseViewModel
    {
        private ICommand nextStepCommand;
        private ICommand previousStepCommand;
        public ICommand NextStepCommand
        {
            get => nextStepCommand;
            set => SetValue(ref nextStepCommand, value);
        }
        public ICommand PreviousStepCommand
        {
            get => previousStepCommand;
            set => SetValue(ref previousStepCommand, value);
        }
        public CalibrationViewModel(string title, string iconName, ContextMediator contextMediator) : base(title, iconName, contextMediator)
        {      
        }



    }
}
