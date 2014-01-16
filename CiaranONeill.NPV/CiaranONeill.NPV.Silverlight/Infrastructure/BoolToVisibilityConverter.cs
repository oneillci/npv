using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CiaranONeill.NPV.Silverlight.Infrastructure
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = ((value != null) && (value is bool)) && (bool)value;
            if ((parameter != null) && (parameter.Equals("Not")))
            {
                boolValue = !boolValue;
            }

            switch (boolValue)
            {
                case true:
                    return Visibility.Visible;
                case false:
                    return Visibility.Collapsed;
                default:
                    return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
