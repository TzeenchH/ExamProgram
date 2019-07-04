using System.Collections.Generic;
using System.Collections.ObjectModel;
using ExaminationProgram.Helpers;

namespace ExaminationProgram
{
    public class Shell : ObservableBase
    {
        private string appName;

        public string AppName
        {
            get => appName;
            set => SetValue(ref appName, value);
        }
        public Shell(string appName)
        {
            AppName = appName;
            Views = new ObservableCollection<object>();
        }
            

        public IList<object> Views { get; set; }

        public Shell AddView(object view)
        {
            Views.Add(view);
            return this;
        }
    }
}
