using System;
using System.Windows;
using System.Globalization;
using System.Windows.Data;

namespace ExaminationProgram.Helpers.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public Visibility True { get; set; }
        public Visibility False { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolean = (bool)value;
            if (boolean)
                return True;
            else
                return False;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

