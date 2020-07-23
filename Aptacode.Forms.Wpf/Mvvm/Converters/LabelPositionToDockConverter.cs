using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Wpf.Mvvm.Converters
{
    public class LabelPositionToDockConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ElementLabel.LabelPosition labelPosition)
            {
                switch (labelPosition)
                {
                    case ElementLabel.LabelPosition.Above:
                        return Dock.Top;
                    case ElementLabel.LabelPosition.Below:
                        return Dock.Bottom;
                    case ElementLabel.LabelPosition.Left:
                        return Dock.Left;
                    case ElementLabel.LabelPosition.Right:
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