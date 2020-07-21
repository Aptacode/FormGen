using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class HtmlEditorDialogViewModel : BindableBase
    {
        public HtmlEditorDialogViewModel(string htmlContent)
        {
            Content = htmlContent;
        }

        #region Properties

        private string _content;

        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        #endregion
    }
}