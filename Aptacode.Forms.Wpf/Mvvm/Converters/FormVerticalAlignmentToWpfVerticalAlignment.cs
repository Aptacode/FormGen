using System;
using System.Globalization;
using System.Windows.Data;
using Aptacode.Forms.Shared.Enums;

namespace Aptacode.Forms.Wpf.Mvvm.Converters
{
    public class FormVerticalAlignmentToWpfVerticalAlignment : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is VerticalAlignment alignment)
            {
                switch (alignment)
                {
                    case VerticalAlignment.Top:
                        return System.Windows.VerticalAlignment.Top;
                    case VerticalAlignment.Bottom:
                        return System.Windows.VerticalAlignment.Bottom;
                    case VerticalAlignment.Center:
                        return System.Windows.VerticalAlignment.Center;
                    case VerticalAlignment.Stretch:
                        return System.Windows.VerticalAlignment.Stretch;
                }
            }

            return System.Windows.VerticalAlignment.Stretch;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        #endregion Implementation of IValueConverter
    }
}