using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Aptacode.Forms.Wpf.Mvvm.Converters
{
    public class ModelToIconConverter : IValueConverter
    {
        public static BitmapImage LoadBitmapFromResource(string pathInApplication, Assembly assembly = null)
        {
            if (assembly == null)
            {
                assembly = Assembly.GetCallingAssembly();
            }

            if (pathInApplication[0] == '/')
            {
                pathInApplication = pathInApplication.Substring(1);
            }

            try
            {
                return new BitmapImage(new Uri(
                    @"pack://application:,,,/Aptacode.Forms.Wpf;component/" + pathInApplication, UriKind.Absolute));
            }
            catch { }

            return null;
        }

        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            LoadBitmapFromResource($"Resources/Icons/{value?.GetType().Name}.png");

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        #endregion Implementation of IValueConverter
    }
}