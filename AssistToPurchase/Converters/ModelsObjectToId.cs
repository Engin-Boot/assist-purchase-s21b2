using AssistToPurchase.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace AssistToPurchase.Converters
{
    class ModelsObjectToId : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var model = (ModelsSpecification)value;
            if (model != null)
            {
                return model.Id;
            }
            return 0;
        }
    }
}
