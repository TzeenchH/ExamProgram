using System.Windows.Input;
using System.Collections.Generic;
using System;
using ExaminationProgram.Abstractions;
using ExaminationProgram.Helpers;
namespace ExaminationProgram.Modules.MeasurementsModule
{
    public class MeasurementsViewModel : BaseViewModel
    {
        private IList<BaseGroup> settings;
        private IList<string> connectedInstruments;

        public IList<string> ConnectedInstruments
        {
            get => connectedInstruments;
            set => SetValue( ref connectedInstruments, value);
        }        
        public IList<BaseGroup> SettingsList
        {
            get => settings;
            set => SetValue(ref settings, value);
        }
        public MeasurementsViewModel(string title, string iconName, ContextMediator contextMediator) : base(title, iconName, contextMediator)
        {
           
        }


    }
}
