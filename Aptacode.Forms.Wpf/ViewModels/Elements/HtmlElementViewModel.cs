using Aptacode.Forms.Shared.Elements;

namespace Aptacode.Forms.Wpf.ViewModels.Elements
{
    public class HtmlElementViewModel : FormElementViewModel
    {
        private string _content;

        public HtmlElementViewModel(HtmlElement htmlContent) : base(htmlContent)
        {
            HtmlContent = htmlContent;
            Content = htmlContent.Content;
        }

        public HtmlElement HtmlContent { get; }

        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }
    }
}