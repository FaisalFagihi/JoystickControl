using System;
using System.Globalization;
using System.Windows.Data;

namespace JoystickControl
{
    public class JoystickHeadLocationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                return (doubleValue / 2)  - (doubleValue * 0.1)  - ((doubleValue - (doubleValue * 0.1)) * 0.2)/2; 
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
