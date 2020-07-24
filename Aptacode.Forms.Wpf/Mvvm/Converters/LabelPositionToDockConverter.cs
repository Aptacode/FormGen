using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using Aptacode.Forms.Shared.Enums;

namespace Aptacode.Forms.Wpf.Mvvm.Converters
{
    public class LabelPositionToDockConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is LabelPosition labelPosition)
            {
                switch (labelPosition)
                {
                    case LabelPosition.Above:
                        return Dock.Top;
                    case LabelPosition.Below:
                        return Dock.Bottom;
                    case LabelPosition.Left:
                        return Dock.Left;
                    case LabelPosition.Right:
                        return Dock.Right;
                }
            }

            return Dock.Left;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        #endregion Implementation of IValueConverter
    }
}