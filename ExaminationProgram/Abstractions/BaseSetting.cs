using System.Collections.Generic;
using ExaminationProgram.Helpers;
using ExaminationProgram.Interfaces;

namespace ExaminationProgram.Abstractions
{
    public abstract class BaseSetting<T> : ObservableBase, ISetting
    {
        private List<T> _value;
        private string name;
        private string dimention;
        private bool visible;

        public bool Visible
        {
            get => visible;
            set => SetValue(ref visible, value);      
        } 
        public List<T> Value
        {
            get => _value;
            set => SetValue(ref _value, value);
        }


        public string Name
        {
            get => name;
            set => SetValue(ref name, value);
        }

        public string Dimention
        {
            get => dimention;
            set => SetValue(ref dimention, value);
        }


    }
}
