using System.Windows;
using Aptacode.Forms.Wpf.Demo.ViewModels;

namespace Aptacode.Forms.Wpf.Demo
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
        }
    }
}