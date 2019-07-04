using ExaminationProgram.Abstractions;

namespace ExaminationProgram.Instruments
{
    public class SignalAnalyzer: BaseInstrument
    {
      public SignalAnalyzer() 

        {
            Name = "Анализатор Сигналов FieldFox N9917A";
            Address = "TCPIP0::192.168.30.99::INSTR";
            Description = "First 50 GHz handheld microwave analyzer Cable and antenna analyzer DTF and TDR in a single sweep Vector network analyzer Dynamic range up to 100 dB Spectrum analyzer Absolute amplitude accuracy ± 0.5 dB";
            ImageSourse = new System.Uri("pack://application:,,,/ExaminationProgram;component/Resources/Images/SignalAnalyzer.png");
        }
    }
}
