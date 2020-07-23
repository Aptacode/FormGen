using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Wpf.Mvvm.Converters
{
    public class FormVerticalAlignmentToWpfVerticalAlignment : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Forms.Shared.Enums.VerticalAlignment alignment)
            {
                switch (alignment)
                {
                    case Forms.Shared.Enums.VerticalAlignment.Top:
                        return VerticalAlignment.Top;
                    case Forms.Shared.Enums.VerticalAlignment.Bottom:
                        return VerticalAlignment.Bottom;
                    case Forms.Shared.Enums.VerticalAlignment.Center:
                        return VerticalAlignment.Center;
                    case Forms.Shared.Enums.VerticalAlignment.Stretch:
                        return VerticalAlignment.Stretch;
                }
            }

            return VerticalAlignment.Stretch;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        #endregion Implementation of IValueConverter
    }
}