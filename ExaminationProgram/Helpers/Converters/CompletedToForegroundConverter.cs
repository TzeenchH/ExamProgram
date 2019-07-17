using System;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;

namespace ExaminationProgram.Helpers.Converters
{
    public class CompletedToForegroundConverter : IValueConverter
    {
        public Brush True { get; set; }
        public Brush False { get; set; }
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
