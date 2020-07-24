using System;
using System.Globalization;
using System.Windows.Data;
using Aptacode.Forms.Shared.Enums;

namespace Aptacode.Forms.Wpf.Mvvm.Converters
{
    public class FormHorizontalAlignmentToWpfHorizontalAlignment : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is HorizontalAlignment alignment)
            {
                switch (alignment)
                {
                    case HorizontalAlignment.Left:
                        return System.Windows.HorizontalAlignment.Left;
                    case HorizontalAlignment.Right:
                        return System.Windows.HorizontalAlignment.Right;
                    case HorizontalAlignment.Center:
                        return System.Windows.HorizontalAlignment.Center;
                    case HorizontalAlignment.Stretch:
                        return System.Windows.HorizontalAlignment.Stretch;
                }
            }

            return System.Windows.HorizontalAlignment.Stretch;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        #endregion Implementation of IValueConverter
    }
}