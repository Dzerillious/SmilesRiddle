﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace RiddleSolve.Converters
{
    public class BooleanConverter : MarkupExtension, IValueConverter
    {
        public object TrueValue { get; set; }
        public object FalseValue { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue && boolValue) return TrueValue;
            return FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}