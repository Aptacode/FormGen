using Aptacode.Forms.Fields.Inputs;

namespace Aptacode.Forms.Wpf.ViewModels.Elements.Fields.Inputs
{
    public class TextFieldInputViewModel : FormFieldInputViewModel
    {
        private string _content;
        public TextField TextField;

        public TextFieldInputViewModel(TextField textField) : base(textField)
        {
            TextField = textField;
        }

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