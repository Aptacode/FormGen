using System;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Aptacode.Forms.Wpf.Mvvm.Converters
{
    public class ModelToIconConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            LoadBitmapFromResource($"Resources/Icons/{value?.GetType().Name}.png");

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        #endregion Implementation of IValueConverter


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
            return new BitmapImage(new Uri(@"pack://application:,,,/" + assembly.GetName().Name + ";component/" + pathInApplication, UriKind.Absolute));
        }
    }
}