using Aptacode.Forms.Fields.Inputs;

namespace Aptacode.Forms.Wpf.ViewModels
{
    public class TextFieldInputViewModel : FormFieldInputViewModel
    {
        public TextBaseField TextField;
        public TextFieldInputViewModel(TextBaseField textBaseField) : base(textBaseField)
        {
            TextField = textBaseField;
        }

        private string _content;

        public string Content
        {
            get => _content;
            set
            {
                SetProperty(ref _content, value);
                TextField.Content = _content;
                UpdateMessage();
            }
        }
    }
}