using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Wpf.Mvvm.Converters
{
    public class FormHorizontalAlignmentToWpfHorizontalAlignment : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Forms.Shared.Enums.HorizontalAlignment alignment)
            {
                switch (alignment)
                {
                    case Forms.Shared.Enums.HorizontalAlignment.Left:
                        return HorizontalAlignment.Left;
                    case Forms.Shared.Enums.HorizontalAlignment.Right:
                        return HorizontalAlignment.Right;
                    case Forms.Shared.Enums.HorizontalAlignment.Center:
                        return HorizontalAlignment.Center;
                    case Forms.Shared.Enums.HorizontalAlignment.Stretch:
                        return HorizontalAlignment.Stretch;
                }
            }

            return HorizontalAlignment.Stretch;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        #endregion Implementation of IValueConverter
    }
}