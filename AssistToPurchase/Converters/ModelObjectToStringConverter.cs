using AssistToPurchase.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AssistToPurchase.Converters
{
    class ModelObjectToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var models = (ObservableCollection<ModelsSpecification>)value;
            if(CheckNull(value,models))
            {
                return null;
            }

            List<string> result = new List<string>();
            foreach(var model in models)
            {
                result.Add($"{model.ProductName} {model.ProductKey}");
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public bool CheckNull(object value, ObservableCollection<ModelsSpecification> models)
        {
            if (value == null || models == null || models.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
