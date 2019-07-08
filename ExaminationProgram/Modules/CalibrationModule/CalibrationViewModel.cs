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
        private IList<BaseCalibrationStep> calibrationSteps;

        public IList<BaseCalibrationStep> CalibrationSteps
        {
            get => calibrationSteps;
            set => SetValue(ref calibrationSteps, value);
        }

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
        public CalibrationViewModel(string title, string iconName, ContextMediator contextMediator, params BaseCalibrationStep[] calibrationSteps) : base(title, iconName, contextMediator)
        {
            CalibrationSteps = calibrationSteps;
            //foreach (string instrName in contextMediator.GetModule<InstrumentalViewModel>().Instruments.Select(instr => instr.Name))
            //{
            //    ConnectedInstruments.Add(instrName);
            //}
            //foreach (string settName in contextMediator.GetModule<SettingsModule.SettingsViewModel>().groups.Select(sett => sett.Settings.Select(name => name.Name)))
            //{

            //}

            
        }



    }
}
