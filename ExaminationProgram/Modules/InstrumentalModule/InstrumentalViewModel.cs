using System.Windows.Input;
using ExaminationProgram.Helpers;
using ExaminationProgram.Interfaces;
using System.Collections.ObjectModel;
using ExaminationProgram.Abstractions;

namespace ExaminationProgram.Modules.InstrumentalModule
{
    public class InstrumentalViewModel : BaseViewModel , IHasIconName
    {
        private BaseInstrument selectedInstrument;
        private ICommand connectCommand;
        private ObservableCollection<BaseInstrument> instruments;
        private ICommand disconnectCommand;

        public ICommand ConnectCommand
        {
            get => connectCommand;
            set => SetValue(ref connectCommand, value);
        }
        public ICommand DisconnectCommand
        {
            get => disconnectCommand;
            set => SetValue( ref disconnectCommand, value);
        }

        public ObservableCollection<BaseInstrument> Instruments
        {
            get => instruments;
            set => SetValue(ref instruments, value);
        }

        public InstrumentalViewModel(string title, string iconName, ContextMediator contextMediator, params BaseInstrument[] instruments)
            : base(title, iconName, contextMediator)
        {
            Instruments = new ObservableCollection<BaseInstrument>(instruments);
            SelectedInstrument = instruments[0];
            ConnectCommand = new DelegateCommand(() =>
            {
                SelectedInstrument.IsConnected = true;
                contextMediator.SendInstrument(this);
                IconName = "appbar_connect";
               
            });

            DisconnectCommand = new DelegateCommand(() =>
            {
                SelectedInstrument.IsConnected = false;
                IconName = "appbar_disconnect";
            });           
        }
        

        public BaseInstrument SelectedInstrument
        {
            get => selectedInstrument;
            set => SetValue(ref selectedInstrument, value);
        } 
        

    }
}
