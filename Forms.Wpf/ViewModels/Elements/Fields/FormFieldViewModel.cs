using System.ComponentModel;
using Aptacode.Forms.Elements.Fields;

namespace Aptacode.Forms.Wpf.ViewModels.Elements.Fields
{
    public abstract class FormFieldViewModel : FormElementViewModel, IDataErrorInfo
    {
        private bool _isValid;
        private string _validationMessage;

        protected FormFieldViewModel(FormField field) : base(field)
        {
            Field = field;
        }

        #region Properties

        public FormField Field { get; }

        #endregion

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

        public string this[string columnName] => Field.GetValidationMessage();

        public string Error { get; }

        public void UpdateValidationMessage()
        {
            IsValid = Field.IsValid();
            ValidationMessage = Field.GetValidationMessage();
        }
    }
}