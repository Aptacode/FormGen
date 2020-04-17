using Aptacode.Forms.Elements.Fields;

namespace Aptacode.Forms.Wpf.ViewModels.Elements.Fields
{
    public class CheckBoxFieldViewModel : FormFieldViewModel
    {
        private bool _isChecked;
        public CheckBoxField CheckBoxField;

        public CheckBoxFieldViewModel(CheckBoxField checkBoxField) : base(checkBoxField)
        {
            CheckBoxField = checkBoxField;
            IsChecked = CheckBoxField.DefaultIsChecked;
        }

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                SetProperty(ref _isChecked, value);
                UpdateValidationMessage();
            }
        }
    }
}