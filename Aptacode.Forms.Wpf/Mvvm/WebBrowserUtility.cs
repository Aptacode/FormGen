using System.Windows;
using System.Windows.Controls;

namespace Aptacode.Forms.Wpf.Mvvm
{
    public static class WebBrowserUtility
    {
        public static readonly DependencyProperty BindableSourceProperty =
            DependencyProperty.RegisterAttached("BindableSource", typeof(string),
                typeof(WebBrowserUtility), new UIPropertyMetadata(null,
                    BindableSourcePropertyChanged));

        public static string GetBindableSource(DependencyObject obj) => (string) obj.GetValue(BindableSourceProperty);

        public static void SetBindableSource(DependencyObject obj, string value)
        {
            obj.SetValue(BindableSourceProperty, value);
        }

        public static void BindableSourcePropertyChanged(DependencyObject o,
            DependencyPropertyChangedEventArgs e)
        {
            var webBrowser = (WebBrowser) o;
            var content = string.IsNullOrEmpty(e.NewValue.ToString()) ? " " : e.NewValue.ToString();
            webBrowser.NavigateToString(content);
        }
    }
}