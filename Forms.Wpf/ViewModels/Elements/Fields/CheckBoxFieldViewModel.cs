using System.ComponentModel;
using Aptacode.Forms.Elements.Fields;

namespace Aptacode.Forms.Wpf.ViewModels.Elements.Fields
{
    public class CheckBoxFieldViewModel : FormFieldViewModel
    {
        private string _content;
        private bool _isChecked;
        public CheckBoxField CheckBoxField;

        public CheckBoxFieldViewModel(CheckBoxField checkBoxField) : base(checkBoxField)
        {
            CheckBoxField = checkBoxField;
            Content = checkBoxField.Content;
            IsChecked = CheckBoxField.DefaultIsChecked;
        }

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                SetProperty(ref _isChecked, value);
                CheckBoxField.IsChecked = _isChecked;
                UpdateValidationMessage();
            }
        }

        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }
    }
}