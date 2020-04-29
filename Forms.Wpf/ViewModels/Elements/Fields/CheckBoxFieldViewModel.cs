using Aptacode.Forms.Elements.Fields;

namespace Aptacode.Forms.Wpf.ViewModels.Elements.Fields
{
    public class CheckBoxFieldViewModel : FormFieldViewModel
    {
        public CheckBoxFieldViewModel(CheckBoxField checkBoxField) : base(checkBoxField)
        {
            CheckBoxField = checkBoxField;
            Content = checkBoxField.Content;
            IsChecked = CheckBoxField.DefaultIsChecked;
            DefaultIsChecked = CheckBoxField.DefaultIsChecked;
        }

        #region Properties

        public CheckBoxField CheckBoxField { get; set; }

        private bool _isChecked;

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

        private bool _defaultIsChecked;

        public bool DefaultIsChecked
        {
            get => _defaultIsChecked;
            set
            {
                SetProperty(ref _defaultIsChecked, value);
                CheckBoxField.DefaultIsChecked = _defaultIsChecked;
                IsChecked = _defaultIsChecked;
            }
        }

        private string _content;

        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        #endregion
    }
}