using System.Windows.Input;
using System.Collections.Generic;
using ExaminationProgram.Abstractions;
using ExaminationProgram.Helpers;
using LiveCharts.Wpf;

namespace ExaminationProgram.Modules.MeasurementsModule
{
    public class MeasurementsViewModel : BaseViewModel
    {
        private IList<BaseGroup> settings;
        private IList<string> connectedInstruments;
        private TestData _testData;       
        public TestData TestData
        {
            get => _testData;
            set => SetValue(ref _testData, value);
        }
        public IList<string> ConnectedInstruments
        {
            get => connectedInstruments;
            set => SetValue(ref connectedInstruments, value);
        }
        public IList<BaseGroup> SettingsList
        {
            get => settings;
            set => SetValue(ref settings, value);
        }
        public ICommand StopCommand { get; set; }
        public ICommand StartCommand {get; set; }
        public ICommand ResetCommand { get; set; }
        public MeasurementsViewModel(string title, string iconName, ContextMediator contextMediator, TestData testData) : base(title, iconName, contextMediator)
        {
            TestData = testData;
            StartCommand = new DelegateCommand(() =>
            {
                TestData.AddData(TestData.TestCollection1);
                TestData.Series.Add(new LineSeries { Title = "T1", Values = TestData.TestCollection1 });
                TestData.AddData(TestData.TestCollection2);
                TestData.Series.Add(new LineSeries { Title = "T2", Values = TestData.TestCollection2 });
                TestData.AddData(TestData.TestCollection3);
                TestData.Series.Add(new LineSeries { Title = "T3", Values = TestData.TestCollection3 });
                TestData.AddData(TestData.TestCollection4);
                TestData.Series.Add(new LineSeries { Title = "T4", Values = TestData.TestCollection4 });
            });
            StopCommand = new DelegateCommand(() =>
            {
                TestData.IsStop = true;
            });
            ResetCommand = new DelegateCommand(() =>
            {
                TestData.Series.Clear();
                TestData.TestCollection1.Clear();
                TestData.TestCollection2.Clear();
                TestData.TestCollection3.Clear();
                TestData.TestCollection4.Clear();
                TestData.IsStop = false;
            });
        }


    }
}
