using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace LightsOutWpf.Helper
{
    public class LightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
            {
                throw new Exception("Wrong parameter type.");
            }

            var booleanValue = (bool)value;

            if (parameter is string s && s == "negate")
            {
                booleanValue = !booleanValue;
            }

            if (targetType == typeof(Brush))
            {
                if (booleanValue)
                {
                    return new SolidColorBrush(Colors.Yellow);
                }
                else
                {
                    return new SolidColorBrush(Colors.Black);
                }
            }
            else
            {
                if (booleanValue)
                {
                    return "ON";
                }
                else
                {
                    return "OFF";
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
