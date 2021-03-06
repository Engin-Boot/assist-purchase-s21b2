﻿using AssistToPurchase.Model;
using System;
using System.Globalization;
using System.Windows.Data;

namespace AssistToPurchase.Converters
{
    class SalesRepresentativeObjectToIdConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var salesRep = (SalesRepresentative)value;
            if (salesRep != null)
            {
                return salesRep.Id;
            }
            return "";
        }
    }
}
