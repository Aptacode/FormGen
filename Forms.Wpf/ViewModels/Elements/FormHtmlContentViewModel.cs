using Aptacode.Forms.Fields;

namespace Aptacode.Forms.Wpf.ViewModels.Elements
{
    public class FormHtmlContentViewModel : FormElementViewModel
    {
        private string _content;

        public FormHtmlContentViewModel(FormHtmlContent htmlContent) : base(htmlContent)
        {
            HtmlContent = htmlContent;
            Content = htmlContent.Content;
        }

        public FormHtmlContent HtmlContent { get; }

        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }
    }
}