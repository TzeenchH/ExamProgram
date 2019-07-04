using ExaminationProgram.Helpers;
using ExaminationProgram.Abstractions;
using ExaminationProgram.Modules.LogsModule;
using ExaminationProgram.Modules.SettingsModule;
using ExaminationProgram.Modules.DataBaseModule;
using ExaminationProgram.Modules.InstrumentalModule;
using ExaminationProgram.Modules.MeasurementsModule;

namespace ExaminationProgram
{
    public class ContextMediator : ObservableBase
    {
        private InstrumentalViewModel instrumentalViewModel;
        private SettingsViewModel settingsViewModel;
        private MeasurementsViewModel measurementsViewModel;
        private DataBaseViewModel dataBaseViewModel;
        private LogsViewModel logsViewModel;

        public InstrumentalViewModel InstrumentalViewModel
        {
            get => instrumentalViewModel;
            set => SetValue(ref instrumentalViewModel,  value);
        }
        public SettingsViewModel SettingsViewModel
        {
            get => settingsViewModel;
            set => SetValue(ref settingsViewModel, value);
        }
        public MeasurementsViewModel MeasurementsViewModel
        {
            get => measurementsViewModel;
            set => SetValue(ref measurementsViewModel, value);
        }
        public DataBaseViewModel DataBaseViewModel
        {
            get => dataBaseViewModel;
            set => SetValue(ref dataBaseViewModel, value);
        }
        public LogsViewModel LogsViewModel
        {
            get => logsViewModel;
            set => SetValue(ref logsViewModel, value);
        }

        public void SendInstrument (InstrumentalViewModel instrumentalViewModel)
        {
            if (instrumentalViewModel.SelectedInstrument.IsConnected)
            {
                MeasurementsViewModel.ConnectedInstruments.Add(InstrumentalViewModel.SelectedInstrument.Name);
            }
        }
    }
}
