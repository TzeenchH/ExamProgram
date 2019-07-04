using System;
using ExaminationProgram.Helpers;

namespace ExaminationProgram.Abstractions
{
    public abstract class BaseInstrument : ObservableBase
    {
        private bool isConnected;
        private string address;
        private string name;
        private string description;
        private Uri imageSourse;

        public string Description
        {
            get => description;
            set => SetValue(ref description, value);
        }
        public string Name
        {
            get => name;
            set => SetValue(ref name, value);
        }

        public string Address
        {
            get => address;
            set => SetValue(ref address, value);
        }

        public bool IsConnected
        {
            get => isConnected;
            set => SetValue(ref isConnected, value);
        }

        public Uri ImageSourse
        {
            get => imageSourse;
            set => SetValue(ref imageSourse, value);
        }

       

    }
}
