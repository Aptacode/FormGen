using System;
using System.Globalization;
using System.Windows.Data;
using WpfRichText;

namespace Aptacode.Forms.Wpf.Mvvm.Converters
{
    public class HtmlToXamlValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    return HtmlToXamlConverter.ConvertHtmlToXaml((string) value, false);
                }
            }
            catch
            {
                // ignored
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}