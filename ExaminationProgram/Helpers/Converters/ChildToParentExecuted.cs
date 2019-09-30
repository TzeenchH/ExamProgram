using System;
using System.Globalization;
using System.Windows.Data;
using MahApps.Metro.IconPacks;

namespace ExaminationProgram.Helpers.Converters
{
    public class ChildToParentExecuted : IMultiValueConverter
    {      
        PackIconMaterialKind Success { get; set; }
        PackIconMaterialKind Error { get; set; }
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool ChildrenExecuted = true;
            foreach (var child in values)
            {
                ChildrenExecuted ^= (bool)child;
            }
            if (ChildrenExecuted)
                return Success;
            else return Error;
        }
        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}