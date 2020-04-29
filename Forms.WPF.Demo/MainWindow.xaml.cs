using System.Windows;
using Aptacode.Forms.Wpf.FormDesigner.ViewModels;

namespace Aptacode.Forms.Wpf.FormDesigner
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