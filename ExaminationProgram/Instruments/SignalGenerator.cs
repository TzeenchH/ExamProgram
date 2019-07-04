using ExaminationProgram.Abstractions;

namespace ExaminationProgram.Instruments
{
    public class SignalGenerator : BaseInstrument
    {
        public SignalGenerator()
        {
            
            Name = "Аналоговый Генератор Сигналов N5183B";
            Address = "TCPIP0::192.168.30.30::INSTR";
            ImageSourse = new System.Uri("pack://application:,,,/ExaminationProgram;component/Resources/Images/SignalGererator.jpg");
            Description = "Time from receipt of SCPI command or trigger signal to amplitude settled within 0.2 dB. Specification does not apply when switching to or from frequencies < 5 MHz, or when ALC level is < 0 dBm, or when frequency crosses 0.002, 0.02, 0.1, 2.0, 3.2, 5.0, 6.4, 8, 10, 12.8, 16, 20, 25.6, or 32 GHz.";
        }
    }
}
