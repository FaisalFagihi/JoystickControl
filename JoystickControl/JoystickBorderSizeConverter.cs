using System;
using System.Globalization;
using System.Windows.Data;

namespace JoystickControl
{
    public class JoystickBorderSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                return (doubleValue * 0.8 );
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
