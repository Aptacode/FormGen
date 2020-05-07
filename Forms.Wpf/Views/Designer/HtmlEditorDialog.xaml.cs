using System.Windows;
using Aptacode.Forms.Wpf.ViewModels.Designer;

namespace Aptacode.Forms.Wpf.Views.Designer
{
    /// <summary>
    /// Interaction logic for HtmlEditorDialog.xaml
    /// </summary>
    public partial class HtmlEditorDialog : Window
    {
        public HtmlEditorDialog(string content)
        {
            InitializeComponent();
            DataContext = ViewModel = new HtmlEditorDialogViewModel(content);

        }
        public HtmlEditorDialogViewModel ViewModel { get; set; }

        public string HtmlContent => ViewModel.Content;

    }
}
