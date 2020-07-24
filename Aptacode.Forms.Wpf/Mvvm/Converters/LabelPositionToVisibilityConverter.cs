using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Wpf.Mvvm.Converters
{
    public class LabelPositionToVisibilityConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value is LabelPosition labelPosition && labelPosition != LabelPosition.Hidden
                ? Visibility.Visible
                : Visibility.Collapsed;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        #endregion Implementation of IValueConverter
    }
}