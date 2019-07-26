using System;
using System.Globalization;
using System.Windows.Data;
using MahApps.Metro.IconPacks;

namespace ExaminationProgram.Helpers.Converters
{
    public class StatusToIconConverter :  IMultiValueConverter
    {
        public PackIconMaterialKind Success { get; set; }
        
        public PackIconMaterialKind Error { get; set; }
        public PackIconMaterialKind Skipped { get; set; }
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {

            string err = values[0] as string;
            bool compl = (bool)values[1];
            if (string.IsNullOrEmpty(err) && compl)
                return Success;
            else if (!string.IsNullOrEmpty(err))
                return Error;
            else return Skipped;
        }
        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
