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
            if (value is ControlElement.VerticalAlignment verticalAlignment)
            {
                switch (verticalAlignment)
                {
                    case ControlElement.VerticalAlignment.Top:
                        return VerticalAlignment.Top;
                    case ControlElement.VerticalAlignment.Bottom:
                        return VerticalAlignment.Bottom;
                    case ControlElement.VerticalAlignment.Center:
                        return VerticalAlignment.Center;
                }
            }

            return VerticalAlignment.Center;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        #endregion Implementation of IValueConverter
    }
}