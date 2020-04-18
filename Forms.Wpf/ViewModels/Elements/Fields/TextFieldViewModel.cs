using System.ComponentModel;
using Aptacode.Forms.Elements.Fields;

namespace Aptacode.Forms.Wpf.ViewModels.Elements.Fields
{
    public class TextFieldViewModel : FormFieldViewModel
    {
        private string _content;
        public TextField TextField;

        public TextFieldViewModel(TextField textField) : base(textField)
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
                UpdateValidationMessage();
            }
        }
    }
}