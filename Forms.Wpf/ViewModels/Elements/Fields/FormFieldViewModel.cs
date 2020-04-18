using Aptacode.Forms.Elements.Fields;

namespace Aptacode.Forms.Wpf.ViewModels.Elements.Fields
{
    public abstract class FormFieldViewModel : FormElementViewModel
    {
        private bool _isValid;
        private string _validationMessage;

        protected FormFieldViewModel(FormField field) : base(field)
        {
            Field = field;
        }

        public FormField Field { get; }

        public string ValidationMessage
        {
            get => _validationMessage;
            set => SetProperty(ref _validationMessage, value);
        }

        public bool IsValid
        {
            get => _isValid;
            set => SetProperty(ref _isValid, value);
        }

        public void UpdateValidationMessage()
        {
            IsValid = Field.IsValid();
            ValidationMessage = Field.GetValidationMessage();
        }
    }
}