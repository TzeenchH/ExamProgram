using System;
using System.Threading;
using System.Threading.Tasks;
using LiveCharts;
using ExaminationProgram.Helpers;

namespace ExaminationProgram.Modules.MeasurementsModule
{
    public class TestData : ObservableBase
    {
        public async void AddData(ChartValues<int> cw)
        {
            await Task.Run(() => _AddData(cw));
        }
        private void _AddData(ChartValues<int> vs)
        {
            for (int i = 0; i < 10; i++)
            {
                vs.Add(rand.Next(0, 12));
                if (isStop)
                break;
                Thread.Sleep(1000);
            }

        }
        private ChartValues<int> testCollection1;
        private ChartValues<int> testCollection2;
        private ChartValues<int> testCollection3;
        private ChartValues<int> testCollection4;
        private bool isStop;

        public Random rand { get; set; }
        public bool IsStop
        {
            get => isStop;
            set => SetValue(ref  isStop, value);
        }
        public ChartValues<int> TestCollection1
        {
            get => testCollection1;
            set => SetValue(ref testCollection1, value);
        }
        public ChartValues<int> TestCollection2
        {
            get => testCollection2;
            set => SetValue(ref testCollection2, value);
        }
        public ChartValues<int> TestCollection3
        {
            get => testCollection3;
            set => SetValue(ref testCollection3, value);
        }
        public ChartValues<int> TestCollection4
        {
            get => testCollection4;
            set => SetValue(ref testCollection4, value);
        }
        public SeriesCollection Series { get; set; }
        public TestData()
        {
            rand = new Random();
            TestCollection1 = new ChartValues<int>();
            TestCollection2 = new ChartValues<int>();
            TestCollection3 = new ChartValues<int>();
            TestCollection4 = new ChartValues<int>();
            Series = new SeriesCollection();
        }
    }
}
