using Aptacode.Forms.Elements;

namespace Aptacode.Forms.Wpf.ViewModels.Elements
{
    public class ButtonElementViewModel : FormElementViewModel
    {
        private string _content;

        public ButtonElementViewModel(ButtonElement buttonElement) : base(buttonElement)
        {
            ButtonElement = buttonElement;
            Content = buttonElement.Content;
        }

        public ButtonElement ButtonElement { get; }

        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }
    }
}