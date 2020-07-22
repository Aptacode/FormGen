using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Aptacode.Forms.Wpf.Mvvm.Converters {
    public class BoolToVisibilityConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value is bool boolValue ? Visibility.Visible : Visibility.Collapsed;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        #endregion Implementation of IValueConverter
    }
}