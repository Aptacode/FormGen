using Aptacode.Forms.Shared.Elements.Fields;

namespace Aptacode.Forms.Wpf.ViewModels.Elements.Fields
{
    public class TextFieldViewModel : FormFieldViewModel
    {
        public TextFieldViewModel(TextField textField) : base(textField)
        {
            TextField = textField;
            DefaultContent = textField.DefaultContent;
            Content = textField.DefaultContent;
        }

        #region Properties

        public TextField TextField { get; set; }

        private string _content;

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

        private string _defaultContent;

        public string DefaultContent
        {
            get => _defaultContent;
            set
            {
                SetProperty(ref _defaultContent, value);
                TextField.DefaultContent = _defaultContent;
                Content = _defaultContent;
            }
        }

        #endregion
    }
}