using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AssistToPurchase.Converters
{
    class RadioBoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (CheckNull(value,parameter))
                return false;

            string checkValue = value.ToString();
            string targetValue = parameter.ToString();
            return checkValue.Equals(targetValue,
                     StringComparison.InvariantCultureIgnoreCase);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (CheckNull(value, parameter))
                return null;

            bool useValue = (bool)value;
            string targetValue = parameter.ToString();
            return GetReturnValue(targetValue,useValue);
        }

        public bool CheckNull(object value , object parameter)
        {
            if (value == null || parameter == null)
                return true;
            return false;
        }

        public object GetReturnValue(string targetValue, bool useValue)
        {
            if (targetValue.Equals("Optional"))
                targetValue = "";
            if (useValue)
                return targetValue;

            return null;
        }
    }
}
